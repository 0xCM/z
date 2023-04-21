//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class EnvReports
    {
        static uint KeySeq = 0;
        
        static ToolKey key(FilePath path)
            => new (inc(ref KeySeq), path);

        static IDbArchive cfgroot(IDbArchive src)
            => src.Scoped("cfg");

        static FilePath cfgpath(IDbArchive src, EnvId name)
            => cfgroot(src).Scoped(name).Path("process", FileKind.Cfg);

        static FilePath toolpath(IDbArchive src, EnvId name)
            => cfgroot(src).Scoped(name).Path("tools", FileKind.Csv);


        public static ExecToken emit(IWfChannel channel, IDbArchive dst)
        {
            var running = channel.Running();
            var targets = cfgroot(dst).Scoped(Env.id());
            tools(channel, targets);
            emit(channel, EnvVarKind.Process, targets);
            emit(channel, EnvVarKind.User, targets);
            emit(channel, EnvVarKind.Machine, targets);
            return channel.Ran(running);
        }

        public static ToolCatalog tools()
        {
            var paths = Env.path(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);
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

        public static EnvReport load(IEnvDb src, EnvId id)
            => new EnvReport(id,EnvVarKind.Process, Env.vars(cfgpath(src, id)), tools(toolpath(src, id)));

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

        static void tools(IWfChannel channel, IDbArchive dst)
        {
            var catalog = tools();
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