//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdExpr;
    using static ProjectModels;

    using Names = Projects.SettingNames;

    public class Projects
    {
        public static IProject create(IWfChannel channel, ProjectKind kind, FolderPath root)
        {
            var project = default(IProject);
            var config = ConfigFile.Empty;
            var archive = root.DbArchive();
            var develop = LaunchScript.Empty;
            if(ConfigFile.path(root).Exists)
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

        
            return new Project(kind,root);
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

        public static ExecToken save(IWfChannel channel, ConfigFile src)
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

        public static ConfigFile configuration(FolderPath root)
            => new ConfigFile(root + FS.file("config", FileKind.Cmd), CmdScripts.setx(root + FS.file("config", FileKind.Cmd)));   

        public static ConfigFile configure(ProjectKind kind, FolderPath root)
        {
            var path = root + FS.file("config", FileKind.Cmd);
            var settings = list<CmdSetExpr>();
            settings.Add(new (SettingNames.ProjectKind, kind.ToString()));
            settings.Add(new (SettingNames.SlnName, root.FolderName.Format()));
            settings.Add(new (SettingNames.SlnRoot, $"%~dp0..\\%{SettingNames.SlnName}%"));
            settings.Add(new (SettingNames.SlnCmd, $"%{SettingNames.SlnRoot}%\\cmd"));
            return new ConfigFile(path,settings.Array());
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

        public static FilePath flowpath(IProject src)
            => src.Build().Path(FS.file($"{src.Name}.build.flows",FileKind.Csv));

        public static ProjectContext context(IProject src)
            => new ProjectContext(src, flows(src));

        static Outcome parse(string src, out Tool dst)
        {
            dst = text.trim(src);
            return true;
        }

        static CmdFlows flows(IProject src)
        {
            var path = Projects.flowpath(src);
            if(path.Exists)
            {
                var lines = path.ReadLines(TextEncodingKind.Asci,true);
                var buffer = sys.alloc<CmdFlow>(lines.Length - 1);
                var reader = lines.Storage.Reader();
                reader.Next(out _);
                var i = 0u;
                while(reader.Next(out var line))
                {
                    var parts = text.trim(text.split(line, Chars.Pipe));
                    Require.equal(parts.Length, CmdFlow.FieldCount);
                    var cells = parts.Reader();
                    ref var dst = ref seek(buffer,i++);
                    parse(cells.Next(), out dst.Tool).Require();
                    DataParser.parse(cells.Next(), out dst.SourceName).Require();
                    DataParser.parse(cells.Next(), out dst.TargetName).Require();
                    DataParser.parse(cells.Next(), out dst.SourcePath).Require();
                    DataParser.parse(cells.Next(), out dst.TargetPath).Require();
                }
                return new(FileCatalog.load(src.Files().Array().ToSortedSpan()), buffer);
            }
            else
                return CmdFlows.Empty;
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