//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdExpr;

    using Names = Projects.SettingNames;

    public class Projects
    {
        public static IProject create(IWfChannel channel, ProjectKind kind, FolderPath root)
        {
            var project = default(IProject);
            var config = ProjectConfigFile.Empty;
            var archive = root.DbArchive();
            var develop = LaunchScript.Empty;
            if(ProjectConfigFile.path(root).Exists)
                config = Projects.configuration(root);
            else
            {
                config = Projects.configure(kind, root);
                Projects.save(channel, config);
            }
            if(LaunchScript.path(root).Exists)
            {
                develop = Projects.launcher(root);
            }
            else
            {
                develop = Projects.launcher(root);
                Projects.save(channel, develop);
            }

            if(CodeWorkspace.path(root).Exists)
            {

            }
            else
            {
            }

        
            return new DevProject(kind,root);
        }

        public static IProject load(IWfChannel channel, FilePath src)
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
                            var vars = CmdScripts.extract(expr, prefix, fence);
                            iter(vars.Keys, key => {
                                if(env.Find(key, out var value))
                                {
                                    found.Add(CmdScripts.var(key, prefix, fence, value));
                                }
                            });

                            var eval = FS.dir(CmdScripts.eval(expr, found.Array()));
                            if(eval.Exists)
                            {
                                folders.Add(eval);
                            }
                            else
                            {
                                channel.Error($"Not found: {eval}");
                            }                            
                        });
                    break;
                }
            });
            
            return new AggregateProject(src, folders.Array());
        }

        public static ExecToken save(IWfChannel channel, CodeWorkspace src)   
        {
            var buffer = text.emitter();
            var emitter = Json.emitter(buffer);
            emitter.Serialize(new {
                folders = src.Folders.Storage
            });
            return channel.FileEmit(buffer.Emit(), src.Path);
        }

        public static ExecToken save(IWfChannel channel, LaunchScript src)   
            => channel.FileEmit(src.Script.Body, src.Path);

        public static ExecToken save(IWfChannel channel, ProjectConfigFile src)
        {
            var buffer = text.emitter();
            iter(src.Body, setting => buffer.AppendLine(setting.Format()));
            return channel.FileEmit(buffer.Emit(), src.Path);
        }        

        public static void kind(string src, out ProjectKind dst)
        {
            dst = ProjectKind.None;
            switch(src.ToLower())
            {
                case "binary":
                    dst = ProjectKind.Binary;
                break;
            }
        }        

        public static ProjectConfigFile configuration(FolderPath root)
            => new ProjectConfigFile(root + FS.file("config", FileKind.Cmd), CmdScripts.setx(root + FS.file("config", FileKind.Cmd)));   

        public static ProjectConfigFile configure(ProjectKind kind, FolderPath root)
        {
            var path = root + FS.file("config", FileKind.Cmd);
            var settings = list<CmdSetExpr>();
            settings.Add(new (SettingNames.ProjectKind, kind.ToString()));
            settings.Add(new (SettingNames.SlnName, root.FolderName.Format()));
            settings.Add(new (SettingNames.SlnRoot, $"%~dp0..\\%{SettingNames.SlnName}%"));
            settings.Add(new (SettingNames.SlnCmd, $"%{SettingNames.SlnRoot}%\\cmd"));
            return new ProjectConfigFile(path,settings.Array());
        }

        public static LaunchScript launcher(FolderPath root)
        {
            var dst = text.emitter();
            dst.AppendLine(call(cwd(script("config"))));
            dst.AppendLine(set(EnvTokens.PATH, (@string)$"{var(Names.SlnPaths)};{var(EnvTokens.PATH)}"));
            dst.AppendLine(set(Names.WsRoot, cwd()));
            dst.AppendLine(set(Names.WsPath, cwd()));
            dst.AppendLine(var(Names.VsCode));
            return new LaunchScript(root + FS.file("develop", FileKind.Cmd), new CmdScript("develop", dst.Emit()));
        }


        static IProject Project;

        public static ref readonly IProject project()
        {
            if(Project == null)
                sys.@throw("Project is null");
            return ref Project;
        }

        [MethodImpl(Inline)]
        public static ref readonly IProject project(IProject src)
        {
            Project = src;
            return ref Project;
        }

        public class SettingNames 
        {
            public const string SlnRoot = nameof(SlnRoot);

            public const string SlnName = nameof(SlnName);

            public const string SlnSite = nameof(SlnSite);

            public const string SlnBuild = nameof(SlnBuild);

            public const string SlnVendor = nameof(SlnVendor);

            public const string SlnPub = nameof(SlnPub);

            public const string SlnCmd = nameof(SlnCmd);
            
            public const string SlnPaths = nameof(SlnPaths);

            public const string ProjectKind = nameof(ProjectKind);

            public const string WsRoot = nameof(WsRoot);

            public const string WsPath = nameof(WsPath);

            public const string VsCode = nameof(VsCode);
        }   
    }
}