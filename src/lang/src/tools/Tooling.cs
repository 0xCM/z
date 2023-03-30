//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Tooling : Channeled<Tooling>
    {
        public static ReadOnlySeq<IToolExecutor> executors(params Assembly[] src)
            => src.Types().Tagged<CmdExecutorAttribute>().Concrete().Map(x => (IToolExecutor)Activator.CreateInstance(x));

        public static string format(IToolCmd src)
        {
            var count = src.Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", src.Tool, Chars.LParen);
            for(var i=0; i<count; i++)
            {
                var arg = src.Args[i];
                buffer.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        [MethodImpl(Inline), Op]
        public static ToolFlagSpec flag(string name, string desc)
            => new ToolFlagSpec(name, desc);

        public static ReadOnlySeq<ToolFlagSpec> flags(FilePath src)
        {
            var k = z16;
            var dst = list<ToolFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.Eq);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.FS);
                
                if(i == NotFound)
                    continue;


                var name = text.trim(AsciSymbols.format(SQ.left(content,i)));
                var desc = text.trim(AsciSymbols.format(SQ.right(content,i)));
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(FilePath tool, params string[] src)
            => new ToolCmdLine(tool, src);

        [Op, Closures(UInt64k)]
        public static ToolCmd cmd<T>(Tool tool, in T src)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = sys.alloc<ClrFieldValue>(count);
            ClrFields.values(src, fields, reflected);
            var buffer = sys.alloc<CmdArg>(count);
            var target = span(buffer);
            var values = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(values,i);
                seek(target,i) = new CmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmd(tool, Cmd.identify(t), buffer);
        }        

        [Op, Closures(UInt64k)]
        public static Tool tool(CmdArgs args, byte index = 0)
            => new (CmdArgs.arg(args,index).Value);

        public FilePath ConfigScript(Tool tool)
            => Home(tool).ConfigScript(ApiAtomic.config, FileKind.Cmd);

        public FilePath Script(Tool tool, string name, FileKind kind)
            => Home(tool).Script(name, kind);

        public IDbArchive Docs(Tool tool)
            => Home(tool).Docs();

        public IToolWs Home(Tool tool)
            => new ToolWs(tool, ToolBase.Sources(tool.Name).Root);

        public IDbArchive ToolBase
            => AppDb.Toolbase();

        public FilePath ScriptPath(Tool tool, string name, FileKind kind)
            => Home(tool).Script(name, kind);

        public SettingLookup LoadCfg(Tool tool)
            => Z0.Settings.parse(Home(tool).Script("tools", FileKind.Cfg).ReadNumberedLines(), Chars.Eq);

        public ConstLookup<Actor,ToolProfile> InferProfiles(FolderPath src)
        {
            var @base = FolderPath.Empty;
            var members = Index<Actor>.Empty;
            var config = src + FS.file("toolset", FS.Settings);
            if(!config.Exists)
            {
                Channel.Error(FS.missing(config));
                return dict<Actor,ToolProfile>();
            }

            using var reader = config.Utf8LineReader();
            while(reader.Next(out var line))
            {
                ref readonly var content = ref line.Content;
                var i = text.index(content, Chars.Colon);
                if(i >=0)
                {
                    var name = text.left(content,i);
                    var value = text.right(content,i);
                    if(name == "InstallBase")
                    {
                        var root = FS.dir(value);
                        if(root.Exists)
                            @base = root;
                    }
                }
            }

            return LoadProfileLookup(src);
        }

        public FilePath ToolPath(FolderPath root, Tool tool)
        {
            if(LoadProfileLookup(root).Find(tool, out var profile))
                return profile.Executable;
            else
                return FilePath.Empty;
        }

        // public SettingLookup Setup(Tool tool)
        // {
        //     var script = ConfigScript(tool);
        //     var result = OmniScript.Run(script, out _);
        //     return LoadCfg(tool);
        // }

        // public Outcome RunScript(Actor tool, string name)
        // {
        //     var path = Script(tool, name, FileKind.Cmd);
        //     if(!path.Exists)
        //         return (false, FS.missing(path));
        //     else
        //         return OmniScript.Run(path, out var _);
        // }

        public Index<string> LoadDocs(string tool)
        {
            var src = Docs(tool);
            var dst = bag<string>();
            iter(src.Files(), file => dst.Add(file.ReadText()));
            return dst.ToIndex();
        }

        public ConstLookup<Actor,FilePath> CalcHelpPaths(FolderPath src)
        {
            var dst = new Lookup<Actor,FilePath>();
            var profiles = LoadProfileLookup(src).Values;
            var count = profiles.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                if(profile.HelpCmd.IsEmpty)
                    continue;

                dst.Include(profile.ToolName, src + FS.folder("help") + FS.file(profile.ToolName, FS.Help));
            }

            return dst.Seal();
        }

        public Index<ToolCmdLine> BuildHelpCommands(IToolWs ws)
        {
            var profiles = LoadProfileLookup(ws.Root.Root).Values;
            var count = profiles.Length;
            var dst = list<ToolCmdLine>();
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                if(profile.HelpCmd.IsEmpty)
                    continue;
                dst.Add(Tooling.cmdline(FS.path(profile.ToolName), string.Format("{0} {1}", profile.Executable.Format(PathSeparator.BS), profile.HelpCmd)));
            }
            dst.Sort();
            return dst.ToArray();
        }

        public Index<ToolHelpDoc> EmitHelp(IToolWs ws)
        {
            var result = Outcome.Success;
            var paths = CalcHelpPaths(ws.Root.Root);
            var commands = BuildHelpCommands(ws);
            var count = commands.Length;
            var docs = list<ToolHelpDoc>();
            for(var i=0; i<count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var tool = cmd.Tool;
                //result = OmniScript.Run(cmd, CmdVars.Empty, out var response);
                if(result.Fail)
                {
                    Channel.Error(result.Message);
                    continue;
                }

                Channel.Babble(string.Format("Executed '{0}'", cmd.Format()));

            }

            return docs.ToArray();
        }
 
        public ConstLookup<ToolIdOld,ToolHelpDoc> LoadHelpDocs(IDbArchive src)
        {
            var dst = dict<ToolIdOld,ToolHelpDoc>();
            var files = src.Files(FileKind.Help);
            iter(files, file =>{
                var fmt = file.FileName.Format();
                var i = text.index(fmt, Chars.Dot);
                if(i > 0)
                {
                    var tool = text.left(fmt,i);
                    dst.TryAdd(tool, new ToolHelpDoc(tool, file, file.ReadAsci()));
                }
            });
            return dst;
        }

        public ConstLookup<Actor,ToolProfile> LoadProfileLookup(FolderPath dir)
        {
            var running = Channel.Running(string.Format("Loading tool profiles from {0}", dir));
            var sources = dir.Match("tool.profiles", FS.Csv, true);
            var dst = new Lookup<Actor,ToolProfile>();
            iter(sources, src => ToolSettings.profiles(src,dst,Channel));
            var lookup = dst.Seal();
            Channel.Ran(running, string.Format("Collected {0} profile definitions", lookup.EntryCount));
            return lookup;
        }
             
    }
}
