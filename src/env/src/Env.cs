//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using Windows;

    [ApiHost]
    public class Env
    {
        static AppSettings AppSettings => AppSettings.Default;

        public static IDbArchive root()
            => AppSettings.EnvRoot();

        public static EnvId id()
            => EnvId;
        
        public static EnvId id(EnvId src)
        {
            EnvId = src;
            return EnvId;
        }

        static EnvId EnvId 
        {
            get => var(EnvVarKind.Process, EnvTokens.EnvId, x => new EnvId(x));
            set => apply(new EnvVar(EnvTokens.EnvId, value.Format()), EnvVarKind.Process);
        }

        public static IDbArchive ShellData => AppSettings.EnvDb().Scoped("shells");

        public static IEnvDb db(FolderPath root)
            => new EnvDb(root);

        public static IEnvDb db()
            => AppSettings.EnvDb();

        public static ProcessId pid() 
            => ProcessId.current();

        public static uint cpucore()
            => Kernel32.GetCurrentProcessorNumber();

        public static uint tid()
            => Kernel32.GetCurrentThreadId();

        public static FolderPath cd()
            => new(text.ifempty(Environment.CurrentDirectory, AppSettings.Control().Root.Format()));

        public static FolderPath cd(CmdArgs args)
        {
            if(args.Length == 1)
                Environment.CurrentDirectory = args.First.Value;
            return cd();
        }

        public static void cd(FolderPath dst)
            => Environment.CurrentDirectory = dst.Format(PathSeparator.BS);

        public static EnvPath path(string name, EnvVarKind kind = EnvVarKind.Process)
        {
            var value = Environment.GetEnvironmentVariable(name, (EnvironmentVariableTarget)kind);
            var values = text.split(value,Chars.Semicolon);
            return map(values, FS.dir);
        }

        public static EnvVar<EnvPath> INCLUDE()
            => new (EnvTokens.INCLUDE, path(EnvTokens.INCLUDE));

        public static EnvVar<EnvPath> LIB()
            => new (EnvTokens.LIB, path(EnvTokens.LIB));

        public static EnvVar<EnvPath> PATH()
            => new (EnvTokens.PATH, path(EnvTokens.PATH));

        public static ExecToken<EnvPath> path(IWfChannel channel, EnvPathKind kind, IDbArchive dst, EnvVarKind envkind = EnvVarKind.Process)
        {            
            var name = kind switch {
              EnvPathKind.Bin => EnvTokens.PATH,
              EnvPathKind.Include => EnvTokens.INCLUDE,
              EnvPathKind.Lib => EnvTokens.LIB,
                _ => EmptyString
            };
            var folders = path(name, envkind);
            var data = folders.Delimit(Chars.NL);
            channel.Row(data);
            var emitted = channel.FileEmit(data, dst.Path(FS.file($"paths.{kind}", FileKind.List)));
            return (emitted, folders);
        }

        public static EnvVars vars(FilePath src)
        {
            var k = z16;
            var dst = list<EnvVar>();
            var line = TextLine.Empty;
            var buffer = sys.alloc<char>(1024*4);
            using var reader = src.Utf8LineReader();
            while(reader.Next(out line))
            {
                var content = line.Content;
                var i = SQ.index(content, Chars.Eq);
                if(i == NotFound)
                    continue;
                dst.Add(new (text.left(content,i), text.right(content,i)));
            }
            return dst.ToArray().Sort();
        }

        public static EnvVar<T> var<T>(string name, Func<string,T> parser)
            where T : IEquatable<T>
                => var(EnvVarKind.Process, name, parser);

        public static EnvVar<T> var<T>(EnvVarKind kind, string name, Func<string,T> parser)
            where T : IEquatable<T>
        {
            var dst = EnvVar<T>.Empty;
            var value = Environment.GetEnvironmentVariable(name, (EnvironmentVariableTarget)kind);
            if(nonempty(value))
                dst = new(name,parser(value));
            return dst;
        }

        public static EnvVars vars(EnvVarKind kind)
        {
            var dst = list<EnvVar>();
            foreach(DictionaryEntry kv in Environment.GetEnvironmentVariables((EnvironmentVariableTarget)kind))
                 dst.Add(new EnvVar(kv.Key?.ToString() ?? EmptyString, kv.Value?.ToString() ?? EmptyString));
            return dst.ToArray().Sort();
        }
        
        public static EnvVars machine()
            => vars(EnvVarKind.Machine);

        public static EnvVars user()
            => vars(EnvVarKind.User);

        public static EnvVars process()
            => vars(EnvVarKind.Process);

        public static void apply(EnvVar src, EnvVarKind kind)
            => Environment.SetEnvironmentVariable(src.Name, src.Value, (EnvironmentVariableTarget)kind);

        public static ExecToken context(IWfChannel channel, Timestamp ts, IDbArchive dst)
        {
            EnvReports.emit(channel, dst.Scoped("context"));
            var map = ImageMemory.map();
            channel.FileEmit(map.ToString(), dst.Scoped("context").Path("process.image", FileKind.Map));            
            return emit(channel, Process.GetCurrentProcess(), ts, dst);
        }

        static ExecToken emit(IWfChannel channel, ProcessAdapter src, Timestamp ts, IDbArchive dst)
        {
            var running = channel.Running($"Emiting context for process {src.Id} based at {src.BaseAddress} from {src.Path}");
            modules(channel, src, dst);
            var file = ProcDumpName.path(src, ts, dst);
            var dumping = channel.EmittingFile(file);
            DumpEmitter.dump(src, file);
            channel.EmittedBytes(dumping, file.Size);
            return channel.Ran(running, $"Emitted context for process {src.Id}");   
        }

        public static EnvVars merge(EnvVars a, EnvVars b)
        {
            var dst = a.View.Map(x => (x.Name, x)).ToDictionary();
            iter(b.View, v => {
                var name = v.Name;
                switch(name)
                {
                    case EnvTokens.PATH:
                    case EnvTokens.LIB:
                    case EnvTokens.INCLUDE:
                        dst[name] = new (name,text.join(';',v.Value, dst[name]));
                    break;
                }
            });
            return dst.Values.Array();
        }

        static ExecToken modules(IWfChannel channel, Process src, IDbArchive dst)
            => channel.TableEmit(ImageMemory.modules(src), dst.Scoped("context").Path("process.modules",FileKind.Csv));
    }
}