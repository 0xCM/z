//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EnvModule;

    [ApiHost]
    public class Env
    {
        [CmdOp(Names.EnvTools)]
        public static void tools(IWfChannel channel, CmdArgs args)
        {
            var buffer = bag<FilePath>();
            var paths = Env.paths(EnvTokens.PATH, EnvVarKind.Process).Delimit(Chars.NL);

            iter(paths, dir => {
                iter(DbArchive.enumerate(dir, false, FileKind.Exe, FileKind.Cmd, FileKind.Bat), path => {
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

            var dir = Env.cd();
            var file = FS.file($"{dir.FolderName}.tools", FileKind.List);
            var dst = dir + file;
            channel.FileEmit(emitter.Emit(), dst);
        }

        public static ReadOnlySeq<EnvReport> reports(IWfChannel channel, IDbArchive dst)
        {
            var flow = channel.Running();
            var src = Env.reports();
            var id = EnvId.Current;
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
                     token = Env.emit(channel, kind, dst.Root);
                break;
                case EnvVarKind.User:
                    token = Env.emit(channel, kind, dst.Root);
                break;
                case EnvVarKind.Machine:
                    token = Env.emit(channel, kind, dst.Root);
                break;
            }

            return token;
        }

        public static EnvId EnvId 
        {
            get => var(EnvVarKind.Process, nameof(EnvId), x => new EnvId(x));
            set => apply(new EnvVar(EnvVarKind.Process, nameof(EnvId), value.Format()));
        }

        public static CfgBlock cfg(FilePath src)
        {
            var dst = list<CfgEntry>();
            using var reader = src.Utf8LineReader();
            var line = TextLine.Empty;
            while(reader.Next(out line))
            {
                var i = line.Index('=');
                if(i > 0)
                {
                    var name = text.left(line.Content, i);
                    var value = text.right(line.Content,i);
                    dst.Add(new (name,value));
                }
            }
            return new (src.FileName.WithoutExtension.Format(),dst.ToArray());
        }

        public static EnvReport report(EnvVarKind kind)
        {
            var _vars = vars(kind);
            var cfg = CfgBlock.alloc(_vars.Count);
            for(var i=0; i<cfg.Count; i++)
            {
                ref readonly var src = ref _vars[i];
                cfg[i] = new CfgEntry(src.VarName, src.VarValue);
            }
            return new EnvReport(EnvId.Current, kind, cfg, _vars);
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
            emit(channel, EnvVarKind.Process, dst.Root);
            emit(channel, EnvVarKind.User, dst.Root);
            emit(channel, EnvVarKind.Machine, dst.Root);
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

        public static FolderPaths paths(string name, EnvVarKind kind)
        {
            var value = Environment.GetEnvironmentVariable(name, (EnvironmentVariableTarget)kind);
            var values = text.split(value,Chars.Semicolon).Sort();
            return map(values, FS.dir);
        }

        public static EnvVars<@string> vars(FilePath src, char sep = Chars.Eq)
        {
            var k = z16;
            var dst = list<EnvVar<@string>>();
            var line = AsciLineCover.Empty;
            var buffer = sys.alloc<char>(1024*4);
            using var reader = src.AsciLineReader();
            while(reader.Next(out line))
            {
                var content = line.Codes;
                var i = SQ.index(content, sep);
                if(i == NotFound)
                    continue;

                var _name = Asci.format(SQ.left(content,i), buffer);
                var _value = Asci.format(SQ.right(content,i), buffer);
                dst.Add(new (_name, _value));
            }
            return dst.ToArray().Sort();
        }

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

        public static ExecToken emit(IWfChannel channel, EnvVarKind kind, FolderPath dst)
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

            token = emit(channel, kind, vars, new DbArchive(dst));
            return token;
        }

        public static EnvVars vars(EnvVarKind kind)
        {
            var dst = list<EnvVar>();
            foreach(DictionaryEntry kv in Environment.GetEnvironmentVariables((EnvironmentVariableTarget)kind))
                 dst.Add(new EnvVar(kind, kv.Key?.ToString() ?? EmptyString, kv.Value?.ToString() ?? EmptyString));
            return dst.ToArray().Sort();
        }
        
        public static EnvVars machine()
            => vars(EnvVarKind.Machine);

        public static EnvVars user()
            => vars(EnvVarKind.User);

        public static EnvVars process()
            => vars(EnvVarKind.Process);

        public static void apply(EnvVar src)
            => Environment.SetEnvironmentVariable(src.VarName, src.VarValue, (EnvironmentVariableTarget)src.Kind);

        public static Index<EnvVarRow> records(EnvVars src, string name)
        {
            const char Sep = ';';
            var buffer = list<EnvVarRow>();
            var k=0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var v = ref src[i];
                var vName = v.VarName;
                var vValue = v.VarValue;

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
            return CsvChannels.emit(channel, records(src, name).View, table, ASCI);
        }
    }
}