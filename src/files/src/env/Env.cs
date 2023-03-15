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
        public static IDbArchive ShellData => cd().DbArchive().Scoped(".data");

        static AppSettings AppSettings => AppSettings.Default;

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

        public static EnvReports reports(IWfChannel channel)
            => channel.Channeled<EnvReports>();

        static uint KeySeq = 0;
        
        static ToolKey key(FilePath path)
            => new (inc(ref KeySeq), path);

        public static ToolCatalog tools()
        {
            var paths = path(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            var buffer = dict<ToolKey,LocatedTool>();
            iter(paths, dir => {
                iter(FS.enumerate(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {                
                    var include = path.FolderPath != FS.dir("C:/WINDOWS/System32/");
                    include &= (path.FolderPath != FS.dir("C:/WINDOWS"));
                    if(include)
                    {
                        var k = key(path);
                        buffer.TryAdd(k, new LocatedTool(k));
                    }
                });
            });

            return new (buffer.Values.Array().Sort());
        }

        public static EnvId EnvId 
        {
            get => var(EnvVarKind.Process, nameof(EnvId), x => new EnvId(x));
            set => apply(new EnvVar(nameof(EnvId), value.Format()), EnvVarKind.Process);
        }

        public static FolderPath cd()
            => new(text.ifempty(Environment.CurrentDirectory, AppSettings.Default.Control().Root.Format()));

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
              EnvPathKind.FileSystem => EnvTokens.PATH,
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
        
        public static EnvVars vars(params Pair<string>[] src)
            => src.Map(x => new EnvVar(x.Left,x.Right));

        public static EnvVars machine()
            => vars(EnvVarKind.Machine);

        public static EnvVars user()
            => vars(EnvVarKind.User);

        public static EnvVars process()
            => vars(EnvVarKind.Process);

        public static void apply(EnvVar src, EnvVarKind kind)
            => Environment.SetEnvironmentVariable(src.Name, src.Value, (EnvironmentVariableTarget)kind);
    }
}