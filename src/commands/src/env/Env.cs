//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;

    [ApiHost]
    public class Env
    {
        public static IDbArchive ShellData => Env.cd().DbArchive().Scoped(".data");

        public static ProcessId pid() 
            => ProcessId.current();

        public static uint cpucore()
            => Kernel32.GetCurrentProcessorNumber();

        public static uint tid()
            => Kernel32.GetCurrentThreadId();

        public static ReadOnlySeq<EnvReport> reports(IWfChannel channel, IDbArchive dst)
        {
            var flow = channel.Running();
            var src = Env.reports();
            iter(src, report => Env.emit(channel,report, dst));
            channel.Ran(flow);
            return src;
        }

        public static ExecToken report(IWfChannel channel, EnvVarKind kind, IDbArchive dst)
        {
            var token = ExecToken.Empty;
            switch(kind)
            {
                case EnvVarKind.Process:
                     token = Env.emit(channel, kind, dst);
                break;
                case EnvVarKind.User:
                    token = Env.emit(channel, kind, dst);
                break;
                case EnvVarKind.Machine:
                    token = Env.emit(channel, kind, dst);
                break;
            }

            return token;
        }

        static ToolKey key(uint seq, FileName name)
            => new (seq,name);

        public static ToolCatalog tools()
        {
            var paths = Env.path(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            var dst = dict<ToolKey,LocatedTool>();
            var seq = 0u;
            for(var i=0u; i<paths.Count; i++)
            {
                ref readonly var dir = ref paths[i];
                iter(FS.enumerate(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {
                    var k = key(seq++,path.FileName());
                    dst.TryAdd(k, new (seq++, k, path));
                });
            }
            return new (dst);
        }

        public static void tools(IWfChannel channel, IDbArchive dst)
        {
            var buffer = bag<FilePath>();
            var paths = Env.path(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
            iter(paths, dir => {
                iter(FS.enumerate(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {
                    buffer.Add(path);
                });
            }, true);

            var tools = buffer.Array().Sort(new FileNameComparer());
            var counter = 0u;
            var emitter = text.emitter();
            foreach(var tool in tools)
            {               
                var info = string.Format("{0:D5} {1,-36} {2}", counter++, tool.FileName.WithoutExtension, tool); 
                emitter.AppendLine(info);
                channel.Row(info);
            }

            channel.FileEmit(emitter.Emit(), dst.Path(FS.file("tools", FileKind.List)));
        }

        public static EnvId EnvId 
        {
            get => var(EnvVarKind.Process, nameof(EnvId), x => new EnvId(x));
            set => apply(new EnvVar(nameof(EnvId), value.Format()), EnvVarKind.Process);
        }

        public static EnvReport report(EnvVarKind kind)
        {
            var _vars = vars(kind);
            var cfg = CfgBlock.alloc(_vars.Count);
            for(var i=0; i<cfg.Count; i++)
            {
                ref readonly var src = ref _vars[i];
                cfg[i] = new CfgEntry(src.Name, src.Value);
            }
            return new EnvReport(EnvId, kind, cfg, _vars);
        }

        public static ReadOnlySeq<EnvReport> reports()
        {
            var dst = sys.alloc<EnvReport>(3);
            dst[(byte)EnvVarKind.Process] = report(EnvVarKind.Process);
            dst[(byte)EnvVarKind.User] = report(EnvVarKind.User);
            dst[(byte)EnvVarKind.Machine] = report(EnvVarKind.Machine);            
            return dst;        
        }

        public static ExecToken emit(IWfChannel channel, EnvReport src, IDbArchive dst)
            => emit(channel, src.Kind, src.Vars, src.EnvId.IsEmpty ? dst.Scoped("default") : dst.Scoped(src.EnvId));

        public static ExecToken EmitReports(IWfChannel channel, IDbArchive dst)
        {
            var running = channel.Running();
            emit(channel, EnvVarKind.Process, dst);
            emit(channel, EnvVarKind.User, dst);
            emit(channel, EnvVarKind.Machine, dst);
            return channel.Ran(running);
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
            => new (EnvTokens.PATH,path(EnvTokens.PATH));

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

        public static EnvVars vars(FilePath src, char sep = Chars.Eq)
        {
            var k = z16;
            var dst = list<EnvVar>();
            var line = TextLine.Empty;
            var buffer = sys.alloc<char>(1024*4);
            using var reader = src.Utf8LineReader();
            while(reader.Next(out line))
            {
                var content = line.Content;
                var i = SQ.index(content, sep);
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

        public static ExecToken emit(IWfChannel channel, EnvVarKind kind, EnvVars vars, IDbArchive dst)
        {
            var token = ExecToken.Empty;
            if(vars.IsNonEmpty)
            {
                vars.Iter(v => channel.Write(v.Format()));
                token = emit(channel, vars, kind, dst.Root);
            }
            return token;
        }

        public static ExecToken emit(IWfChannel channel, EnvVarKind kind, IDbArchive dst)
        {
            var vars = EnvVars.Empty;
            var token = ExecToken.Empty;
            switch(kind)
            {
                case EnvVarKind.Machine:
                    vars = machine();
                break;
                case EnvVarKind.Process:
                    vars = process();
                break;
                case EnvVarKind.User:
                    vars = user();
                break;
            }

            token = emit(channel, kind, vars, dst);
            return token;
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

        public static ReadOnlySeq<EnvVarRow> rows(EnvVars src, string name)
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

        static ExecToken emit(IWfChannel channel, EnvVars src, EnvVarKind kind, FolderPath dst)
        {
            var name =  $"{ExecutingPart.Name}.{EnumRender.format(kind)}";
            var table = dst + FS.file($"{name}.settings",FileKind.Csv);
            var env = dst + FS.file($"{name}", FileKind.Cfg);
            using var writer = env.AsciWriter();
            for(var i=0; i<src.Count; i++)
                writer.WriteLine(src[i].Format());
            return CsvTables.emit(channel, rows(src, name).View, table, ASCI);
        }
    }
}