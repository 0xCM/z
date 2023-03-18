//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdExpr;

    partial class ProjectFiles
    {
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
    }
}