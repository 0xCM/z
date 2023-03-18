//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static ProjectModels;

    public partial class ProjectFiles
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