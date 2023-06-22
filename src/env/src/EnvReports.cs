//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class EnvReports : Stateless<EnvReports>
    {
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
            var targets = cfgroot(EnvDb).Scoped(Env.id());
            emit(channel, targets);
            return channel.Ran(running);
        }

        public static ExecToken emit(IWfChannel channel, IDbArchive dst)
        {
            var running = channel.Running();
            var name = Env.id();
            emit(channel, name, EnvVarKind.User, dst);
            emit(channel, name, EnvVarKind.Machine, dst);
            save(channel, name, Env.tools(),dst);            
            emit(channel, name, EnvVarKind.Process, dst);
            return channel.Ran(running);
        }

        public static EnvReport load(IDbArchive src, EnvId id)
        {
            var _vars = vars(cfgpath(src, id));
            return new EnvReport(id, _vars, tools(toolpath(src, id)), rows(_vars, Env.id()));
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

        public static void emit(IWfChannel channel, ToolCatalog src, IDbArchive dst)
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

        static ExecToken modules(IWfChannel channel, Process src, IDbArchive dst)
            => channel.TableEmit(ImageMemory.modules(src), dst.Scoped("context").Path("process.modules",FileKind.Csv));

        static void save(IWfChannel channel, EnvId name, ToolCatalog catalog, IDbArchive dst)
        {
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

        static IDbArchive cfgroot(IDbArchive src)
            => src.Scoped("cfg");

        static FilePath cfgpath(IDbArchive src, EnvId name)
            => cfgroot(src).Scoped(name).Path("process", FileKind.Cfg);

        static FilePath toolpath(IDbArchive src, EnvId name)
            => cfgroot(src).Scoped(name).Path("tools", FileKind.Csv);

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
            var table = dst + FS.file($"{name}.settings",FileKind.Csv);
            var env = dst + FS.file($"{name}", FileKind.Cfg);
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