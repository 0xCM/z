//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Tooling : WfSvc<Tooling>
    {
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
            => Settings.parse(Home(tool).Script("tools", FileKind.Cfg).ReadNumberedLines(), Chars.Eq);

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

        public SettingLookup Setup(Tool tool)
        {
            var script = ConfigScript(tool);
            var result = OmniScript.Run(script, out _);
            return LoadCfg(tool);
        }

        public Outcome RunScript(Actor tool, string name)
        {
            var path = Script(tool, name, FileKind.Cmd);
            if(!path.Exists)
                return (false, FS.missing(path));
            else
                return OmniScript.Run(path, out var _);
        }

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
                dst.Add(Tools.cmdline(FS.path(profile.ToolName), string.Format("{0} {1}", profile.Executable.Format(PathSeparator.BS), profile.HelpCmd)));
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
                result = OmniScript.Run(cmd, CmdVars.Empty, out var response);
                if(result.Fail)
                {
                    Channel.Error(result.Message);
                    continue;
                }

                Babble(string.Format("Executed '{0}'", cmd.Format()));

                // if(paths.Find(tool, out var path))
                // {
                //     var length = response.Length;
                //     var emitting = Channel.EmittingFile(path);
                //     using var writer = path.UnicodeWriter();
                //     for(var j=0; j<length; j++)
                //         writer.WriteLine(skip(response, j).Content);
                //     Channel.EmittedFile(emitting,length);

                //     docs.Add(new ToolHelpDoc(tool,path));
                // }
                // else
                //     Warn(string.Format("{0} has no help path", tool));
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
            iter(sources, src => ToolSettings.profiles(src,dst,Emitter));
            var lookup = dst.Seal();
            Channel.Ran(running, string.Format("Collected {0} profile definitions", lookup.EntryCount));
            return lookup;
        }
    }
}