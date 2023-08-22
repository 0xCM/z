//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class EnvReports : Stateless<EnvReports>
    {
        readonly struct EnvCfg : IEnvCfg
        {
            public FolderPath Root {get;}

            public EnvCfg(FolderPath root)
            {
                Root = root;
            }            

            public EnvId EnvName
                => Root.FolderName.Format();

            public EnvReport Report(EnvVarKind kind = EnvVarKind.Process)
                => load(EnvName, kind);
        }

        public static IEnumerable<IEnvCfg> GetEnvConfigs()
            => EnvDb.Scoped("cfg").Folders().Map(x => (IEnvCfg)new EnvCfg(x.DbArchive().Root));

        public static IEnvCfg GetEnvConfig(EnvId name)
            => new EnvCfg(EnvDb.Scoped("cfg").Folder(name));

        public static IDbArchive GetCfgRoot(EnvId env)
            => EnvDb.Scoped("cfg").Scoped(env);

        public static FilePath GetSettingsPath(IDbArchive src, EnvId name, EnvVarKind kind)
            => src.Path(FS.file($"{name}.{kind}.settings",FileKind.Csv));

        public static FilePath GetToolCsvPath(IDbArchive src, EnvId name, EnvVarKind kind)
            => src.Path(FS.file($"{name}.{kind}.tools", FileKind.Csv));

        public static FilePath GetToolListPath(IDbArchive src, EnvId name, EnvVarKind kind)
            => src.Path(FS.file($"{name}.{kind}.tools", FileKind.List));

        public static FilePath GetCfgPath(IDbArchive src, EnvId name, EnvVarKind kind)
            => src.Path(FS.file($"{name}.{kind}", FileKind.Cfg));

        public static EnvReport process()
        {
            var vars = Env.vars(EnvVarKind.Process);
            var id = Env.id();
            return new EnvReport(id, vars, Env.tools(), rows(vars, id));
        }

        public static ExecToken context(IWfChannel channel, Timestamp ts, IDbArchive dst)
        {
            emit(channel, dst.Scoped("context"));
            var map = ImageMemory.map();
            channel.FileEmit(map.ToString(), dst.Scoped("context").Path("process.image", FileKind.Map));            
            return emit(channel, Process.GetCurrentProcess(), ts, dst);
        }

        public static ExecToken emit(IWfChannel channel)
        {
            var running = channel.Running();
            var targets = GetCfgRoot(Env.id());
            emit(channel, targets);
            return channel.Ran(running);
        }

        public static ExecToken emit(IWfChannel channel, IDbArchive dst)
        {
            var running = channel.Running();
            var name = Env.id();
            emit(channel, name, EnvVarKind.User, dst);
            emit(channel, name, EnvVarKind.Machine, dst);
            emit(channel, Env.tools(), name, EnvVarKind.Process, dst);            
            emit(channel, name, EnvVarKind.Process, dst);
            return channel.Ran(running);
        }

        public static EnvReport load(EnvId name, EnvVarKind kind)
            => load(EnvDb.Scoped($"cfg/{name}"), name, kind);

        public static EnvReport load(IDbArchive src, EnvId name, EnvVarKind kind)
        {
            var _vars = vars(GetCfgPath(src, name, kind));
            return new EnvReport(name, _vars, tools(GetToolCsvPath(src, name, kind)), rows(_vars, Env.id()));
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

        public static ToolCatalog tools(FilePath src)
        {
            using var reader = src.LineReader(TextEncodingKind.Utf8);
            var keys = list<LocatedTool>();
            reader.Next(out var header);
            var line = TextLine.Empty;
            while(reader.Next(out line))
            {
                var row = text.trim(text.split(line.Content, Chars.Pipe)).ToSeq();
                var i=0;
                DataParser.parse(row[i++], out uint seq);
                DataParser.parse(row[i++], out @string name);
                DataParser.parse(row[i++], out FilePath path);
                keys.Add(new LocatedTool(seq, path));            
            }
            return keys.Array();
        }

        public static ExecToken emit(IWfChannel channel, EnvId name, EnvVarKind kind, EnvVars vars, IDbArchive dst)
        {
            var token = ExecToken.Empty;
            if(vars.IsNonEmpty)
            {
                vars.Iter(v => channel.Write(v.Format()));
                token = emit(channel, name, kind, vars, dst.Root);
            }
            return token;
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

        static ExecToken modules(IWfChannel channel, ProcessAdapter src, IDbArchive dst)
            => channel.TableEmit(src.Modules.Select(x => x.Describe()), dst.Scoped("context").Path("process.modules",FileKind.Csv));

        static void emit(IWfChannel channel, ToolCatalog catalog, EnvId name, EnvVarKind kind, IDbArchive dst)
        {
            var counter = 0u;
            var list = text.emitter();
            var csv = text.emitter();
            foreach(var tool in catalog)
            {               
                list.AppendLine(string.Format("{0,-36} {1}", tool.Name, tool.Path));
                var row = string.Format("{0:D5} | {1,-48} | {2}", tool.Seq, tool.Name, tool.Path);
                csv.AppendLine(row);
                channel.Row(row);
            }

            channel.FileEmit(list.Emit(), GetToolListPath(dst, name, kind));
            channel.FileEmit(csv.Emit(), GetToolCsvPath(dst, name, kind));            
        }

        static ExecToken emit(IWfChannel channel, EnvId name, EnvVarKind kind, IDbArchive dst)
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

            token = emit(channel, name, kind, vars, dst);
            return token;
        }

        static ExecToken emit(IWfChannel channel, EnvId name, EnvVarKind kind, EnvVars src, FolderPath dst)
        {
            var table = dst + FS.file($"{name}.{kind}.settings",FileKind.Csv);
            var env = dst + FS.file($"{name}.{kind}", FileKind.Cfg);
            using var writer = env.AsciWriter();
            for(var i=0; i<src.Count; i++)
                writer.WriteLine(src[i].Format());
            return CsvTables.emit(channel, rows(src, name).View, table, ASCI);
        }

        static ReadOnlySeq<EnvVarRow> rows(EnvVars src, EnvId name)
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