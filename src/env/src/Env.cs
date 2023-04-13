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

        static uint KeySeq = 0;
        
        static ToolKey key(FilePath path)
            => new (inc(ref KeySeq), path);

        public static ToolCatalog tools()
        {
            var paths = path(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            var buffer = dict<ToolKey,LocatedTool>();
            iter(paths, dir => {
                iter(FS.files(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {                
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
        
        public static EnvVars machine()
            => vars(EnvVarKind.Machine);

        public static EnvVars user()
            => vars(EnvVarKind.User);

        public static EnvVars process()
            => vars(EnvVarKind.Process);

        public static void apply(EnvVar src, EnvVarKind kind)
            => Environment.SetEnvironmentVariable(src.Name, src.Value, (EnvironmentVariableTarget)kind);

        public static EnvReport load(IEnvDb src, EnvId id)
            => new EnvReport(id,EnvVarKind.Process, Env.vars(cfgpath(src, id)), tools(toolpath(src, id)));

        public static ExecToken reports(IWfChannel channel, IDbArchive dst)
        {
            var running = channel.Running();
            var targets = cfgroot(dst).Scoped(Env.id());
            emit(channel, EnvVarKind.Process, targets);
            emit(channel, EnvVarKind.User, targets);
            emit(channel, EnvVarKind.Machine, targets);
            tools(channel, targets);
            return channel.Ran(running);
        }

        public static ExecToken context(IWfChannel channel, Timestamp ts, IDbArchive dst)
        {
            Env.reports(channel, dst.Scoped("context"));
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

        public static ExecToken EmitReports(IWfChannel channel, IDbArchive dst)
            => reports(channel, dst);

        public static ExecToken EmitReports(IWfChannel channel)
            => EmitReports(channel, cfgroot(AppSettings.Default.EnvDb()));

        static ExecToken modules(IWfChannel channel, Process src, IDbArchive dst)
            => channel.TableEmit(ImageMemory.modules(src), dst.Scoped("context").Path("process.modules",FileKind.Csv));        

        static FilePath cfgpath(IDbArchive src, EnvId name)
            => cfgroot(src).Scoped(name).Path($"process", FileKind.Cfg);

        static FilePath toolpath(IDbArchive src, EnvId name)
            => cfgroot(src).Scoped(name).Path("tools", FileKind.Csv);

        static IDbArchive cfgroot(IDbArchive src)
            => src.Scoped("cfg");

        static ToolCatalog tools(FilePath src)
        {
            using var reader = src.LineReader(TextEncodingKind.Utf8);
            var keys = list<ToolKey>();
            reader.Next(out var header);
            var line = TextLine.Empty;
            while(reader.Next(out line))
            {
                var row = text.trim(text.split(line.Content, Chars.Pipe)).ToSeq();
                var i=0;
                DataParser.parse(row[i++], out uint seq);
                DataParser.parse(row[i++], out @string name);
                DataParser.parse(row[i++], out FilePath path);
                keys.Add(new ToolKey(seq, path));            
            }
            return keys.Map(x => new LocatedTool(x));            
        }

        static void emit(IWfChannel channel, ToolCatalog src, IDbArchive dst)
        {
            var emitter = text.emitter();
            foreach(var tool in src)
            {               
                var info = string.Format("{0:D5} | {1,-48} | {2}", tool.Seq, tool.Name, tool.Path); 
                emitter.AppendLine(info);
                channel.Row(info);
            }

            channel.FileEmit(emitter.Emit(), dst.Path(FS.file("tools", FileKind.Csv)));
        }

        static void tools(IWfChannel channel, IDbArchive dst)
        {
            var catalog = Env.tools();
            var counter = 0u;
            var emitter = text.emitter();
            foreach(var tool in catalog)
            {               
                var info = string.Format("{0,-36} {1}", tool.Name, tool.Path); 
                emitter.AppendLine(info);
                channel.Row(info);
            }

            channel.FileEmit(emitter.Emit(), dst.Path(FS.file("tools", FileKind.List)));
            emit(channel, catalog, dst);
        }

        static ExecToken emit(IWfChannel channel, EnvVarKind kind, EnvVars vars, IDbArchive dst)
        {
            var token = ExecToken.Empty;
            if(vars.IsNonEmpty)
            {
                vars.Iter(v => channel.Write(v.Format()));
                token = emit(channel, vars, kind, dst.Root);
            }
            return token;
        }

        static ExecToken emit(IWfChannel channel, EnvVarKind kind, IDbArchive dst)
        {
            var vars = EnvVars.Empty;
            var token = ExecToken.Empty;
            switch(kind)
            {
                case EnvVarKind.Machine:
                    vars = Env.machine();
                break;
                case EnvVarKind.Process:
                    vars = Env.process();
                break;
                case EnvVarKind.User:
                    vars = Env.user();
                break;
            }

            token = emit(channel, kind, vars, dst);
            return token;
        }

        static ExecToken emit(IWfChannel channel, EnvVars src, EnvVarKind kind, FolderPath dst)
        {
            var name =  EnumRender.format(kind);
            var table = dst + FS.file($"{name}.settings",FileKind.Csv);
            var env = dst + FS.file($"{name}", FileKind.Cfg);
            using var writer = env.AsciWriter();
            for(var i=0; i<src.Count; i++)
                writer.WriteLine(src[i].Format());
            return CsvTables.emit(channel, rows(src, name).View, table, ASCI);
        }

        static ReadOnlySeq<EnvVarRow> rows(EnvVars src, string name)
        {
            const char Sep = ';';
            var buffer = list<EnvVarRow>();
            var k=0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var v = ref src[i];
                var vName = v.Name;
                var vValue = v.Value;

                if(v.Contains(Sep))
                {
                    var parts = text.split(vValue,Sep).Index();
                    for(var j=0; j<parts.Count; j++)
                    {
                        ref readonly var part = ref parts[j];
                        var dst = new EnvVarRow();
                        dst.Seq = k++;
                        dst.EnvName = name;
                        dst.VarName = vName;
                        dst.VarValue = part;
                        dst.Join = Sep.ToString();
                        buffer.Add(dst);
                    }
                }
                else
                {
                    var dst = new EnvVarRow();
                    dst.Seq = k++;
                    dst.EnvName = name;
                    dst.VarName = vName;
                    dst.VarValue = vValue;
                    dst.Join = EmptyString;
                    buffer.Add(dst);
                }
            }

            return buffer.ToIndex();
        }
    }
}