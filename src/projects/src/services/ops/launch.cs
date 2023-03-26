//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ProjectModels;
    using static CmdExpr;

    partial class ProjectServices
    {        
        public static LaunchScript launch(FolderPath root)
        {
            var dst = text.emitter();
            dst.AppendLine(call(cwd(script("config"))));
            dst.AppendLine(set(EnvTokens.PATH, (@string)$"{var(SettingNames.SlnPaths)};{var(EnvTokens.PATH)}"));
            dst.AppendLine(set(SettingNames.WsRoot, cwd()));
            dst.AppendLine(set(SettingNames.WsPath, cwd()));
            dst.AppendLine(var(SettingNames.VsCode));
            return new LaunchScript(root + FS.file("develop", FileKind.Cmd), new CmdScript("develop", dst.Emit()));
        }
    }
}