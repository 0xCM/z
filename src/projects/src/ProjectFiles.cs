//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static ProjectModels;
    using static CmdExpr;

    public class ProjectFiles
    {
        class SettingNames 
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
        
        public class LaunchScript
        {
            public static FilePath path(FolderPath root) => root + FS.file("develop", FileKind.Cmd);

            public readonly CmdScript Script;

            public readonly FilePath Path;

            public LaunchScript(FilePath path, CmdScript script)
            {
                Script= script;
                Path = path;
            }

            public static LaunchScript create(FolderPath root)
            {
                var dst = text.emitter();
                dst.AppendLine(call(cwd(script("config"))));
                dst.AppendLine(set(EnvTokens.PATH, (@string)$"{var(SettingNames.SlnPaths)};{var(EnvTokens.PATH)}"));
                dst.AppendLine(set(SettingNames.WsRoot, cwd()));
                dst.AppendLine(set(SettingNames.WsPath, cwd()));
                dst.AppendLine(var(SettingNames.VsCode));
                return new LaunchScript(root + FS.file("develop", FileKind.Cmd), new CmdScript("develop", dst.Emit()));
            }

            public static LaunchScript load(FolderPath root)
            {
                var path = root + FS.file("develop", FileKind.Cmd);
                return new LaunchScript(path, new CmdScript(path.FileName.WithoutExtension.Format(), path.ReadText()));
            }

            public static LaunchScript Empty => new LaunchScript(FilePath.Empty, CmdScript.Empty);
        }

        public class WorkspaceFile
        {
            public static FilePath path(FolderPath root) => root + FS.file(root.FolderName.Format(), FS.ext("code-workspace"));

            public readonly FilePath Path;

            public ReadOnlySeq<WorkspaceFolder> Folders {get;}

            public WorkspaceFile(FilePath path, params WorkspaceFolder[] folders)
            {
                Path = path;
                Folders = folders;
            }

            public static WorkspaceFile Empty => new WorkspaceFile(FilePath.Empty, sys.empty<WorkspaceFolder>());

        }

        public class WorkspaceFolder
        {
            public @string Name;

            public FolderPath Path;

            public WorkspaceFolder(@string name, FolderPath path)            
            {
                Name = name;
                Path = path;
            }

            public WorkspaceFolder(FolderPath path)            
            {
                Name = @string.Empty;
                Path = path;
            }

            public static implicit operator WorkspaceFolder(FolderPath path)
                => new WorkspaceFolder(path);            
        }

        public class ConfigFile
        {
            public static FilePath path(FolderPath root) => root + FS.file("config", FileKind.Cmd);

            public FilePath Path {get;}
         
            public Seq<CmdExpr> Body {get;}

            public ConfigFile(FilePath path, params CmdExpr[] settings)
            {
                Path = path;
                Body = settings;
            }     
            
            public ProjectKind Kind()
            {
                var kind = ProjectKind.None;
                var settings = Body.Where(x => x is ISetting s && s.Name == SettingNames.ProjectKind);
                if(settings.IsNonEmpty)
                    ProjectFiles.kind((settings.First as ISetting).Name, out kind);
                return kind;
            }

            public string Format()
            {
                var dst = text.emitter();
                sys.iter(Body, setting => dst.AppendLine(setting.Format()));
                return dst.Emit();
            }

            public override string ToString()
                => Format();

            public static ConfigFile Empty => new ConfigFile(FilePath.Empty, sys.empty<CmdSetting>());
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

        public static ConfigFile configure(ProjectKind kind, FolderPath root)
        {
            var path = root + FS.file("config", FileKind.Cmd);
            var settings = list<CmdSetting>();
            settings.Add(new (SettingNames.ProjectKind, kind.ToString()));
            settings.Add(new (SettingNames.SlnName, root.FolderName.Format()));
            settings.Add(new (SettingNames.SlnRoot, $"%~dp0..\\%{SettingNames.SlnName}%"));
            settings.Add(new (SettingNames.SlnCmd, $"%{SettingNames.SlnRoot}%\\cmd"));
            return new ConfigFile(path,settings.Array());
        }

        public static ExecToken save(IWfChannel channel, WorkspaceFile src)   
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

        public static ConfigFile load(FolderPath root)
            => new ConfigFile(root + FS.file("config", FileKind.Cmd), Settings.cmd(root + FS.file("config", FileKind.Cmd)));   
    }
}