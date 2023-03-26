//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdExpr;

    partial class ProjectModels
    {
        public record class LaunchScript : ProjectFile<LaunchScript>
        {
            public static FilePath path(FolderPath root) => root + FS.file("develop", FileKind.Cmd);

            public readonly CmdScript Script;

            public readonly FilePath Path;

            public LaunchScript()
            {
                Script = CmdScript.Empty;
                Path = FilePath.Empty;
            }

            public LaunchScript(FilePath path, CmdScript script)
            {
                Script= script;
                Path = path;
            }


            public static LaunchScript Empty => new LaunchScript(FilePath.Empty, CmdScript.Empty);
        }
    }
}