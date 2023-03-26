//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdExpr;
    using static ProjectModels;

    public partial class ProjectServices : WfSvc<ProjectServices>
    {
            public static LaunchScript LaunchCmd(FolderPath root)
            {
                var dst = text.emitter();
                dst.AppendLine(call(cwd(script("config"))));
                dst.AppendLine(set(EnvTokens.PATH, (@string)$"{var(ProjectServices.SettingNames.SlnPaths)};{var(EnvTokens.PATH)}"));
                dst.AppendLine(set(ProjectServices.SettingNames.WsRoot, cwd()));
                dst.AppendLine(set(ProjectServices.SettingNames.WsPath, cwd()));
                dst.AppendLine(var(ProjectServices.SettingNames.VsCode));
                return new LaunchScript(root + FS.file("develop", FileKind.Cmd), new CmdScript("develop", dst.Emit()));
            }

            public static LaunchScript load(FolderPath root)
            {
                var path = root + FS.file("develop", FileKind.Cmd);
                return new LaunchScript(path, new CmdScript(path.FileName.WithoutExtension.Format(), path.ReadText()));
            }

        public IProject CreateProject(ProjectKind kind, FolderPath root)
        {
            var project = default(IProject);
            var config = ConfigFile.Empty;
            var archive = root.DbArchive();
            var develop = LaunchScript.Empty;
            var workpsace = WorkspaceFile.Empty;
            if(ConfigFile.path(root).Exists)
                config = ProjectServices.configuration(root);
            else
            {
                config = ProjectServices.configure(kind, root);
                ProjectServices.save(Channel, config);
            }
            if(LaunchScript.path(root).Exists)
            {
                develop = LaunchCmd(root);
            }
            else
            {
                develop = LaunchCmd(root);
                ProjectServices.save(Channel, develop);
            }

            if(WorkspaceFile.path(root).Exists)
            {

            }
            else
            {
                workpsace = new WorkspaceFile(WorkspaceFile.path(root), new WorkspaceFolder(@string.Empty, FS.dir(".")));
                ProjectServices.save(Channel, workpsace);
            }

            switch(kind)
            {
                // case ProjectKind.Binary:
                //     project = new BinaryProject(root, new FileIndex());
                // break;
                default:
                    project = new Project(kind,root);
                break;
            }

            return project;
        }

        public ExecToken SaveProject(IWfChannel channel,  IProject project)
        {
            var flow = channel.Running($"Saving project {project.Root}");

            return channel.Ran(flow, $"Saved project {project.Root}");
        }

        public IProject LoadProject(FilePath src)
        {
            var doc = Json.document(src);
            var env = Env.process();
            var root = doc.RootElement;
            AsciFence fence = (AsciSymbols.LBrace, AsciSymbols.RBrace);
            var prefix = AsciSymbols.Dollar;
            var folders = list<FolderPath>();
            var found = list<ScriptVar>();            
            iter(root.EnumerateObject(), o => {
                switch(o.Name)
                {
                    case "folders":
                        iter(o.Value.EnumerateArray(), folder => {
                            var expr = folder.ToString();
                            var vars = Vars.extract(expr, prefix, fence);
                            iter(vars.Keys, key => {
                                if(env.Find(key, out var value))
                                {
                                    found.Add(Vars.var(key, prefix, fence, value));
                                }
                            });

                            var eval = FS.dir(Vars.eval(expr, found.Array()));
                            if(eval.Exists)
                            {
                                folders.Add(eval);
                            }
                            else
                            {
                                Channel.Error($"Not found: {eval}");
                            }                            
                        });
                    break;
                }
            });
            
            return new AggregateProject(src, folders.Array());
        }

        public void EmitApiDeps(IDbArchive dst)
        {
            var src = ExecutingPart.Assembly;
            var path = dst.Path($"{src.GetSimpleName()}", FileKind.DepsList);
            if(path.Exists)
                EmitApiDeps(src, path);
        }

        public void EmitApiDeps(Assembly src, FilePath dst)
        {
            var deps = JsonDeps.load(src);
            var buffer = list<string>();
            iteri(deps.RuntimeLibs(), (i,lib) => buffer.Add(string.Format("{0:D4}:{1}",i,lib)));
            var emitter = text.emitter();
            iter(buffer, line => emitter.AppendLine(line));
            Channel.FileEmit(emitter.Emit(), buffer.Count, dst);
        }

        public FileSource CreateFileSource(FilePath src)
            => new FileSource(src);

        public FolderSource CreateFolderSource(FolderPath src)
            => new FolderSource(src);
    }
}