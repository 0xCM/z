//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ProjectModels;

    partial class ProjectServices
    {
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
    }
}