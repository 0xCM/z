//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    internal class DumpBinScripts
    {
        public static ToolScript DumpObj(FS.FilePath input, IDbTargets dst)
            => Tooling.script(dst.Path("dump-obj",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

        public static ToolScript DumpDll(FS.FilePath input, IDbTargets dst)
            => Tooling.script(dst.Path("dump-dll",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

        public static ToolScript DumpExe(FS.FilePath input, IDbTargets dst)
            => Tooling.script(dst.Path("dump-exe",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

        public static ToolScript DumpLib(FS.FilePath input, IDbTargets dst)
            => Tooling.script(dst.Path("dump-lib",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

        static CmdVars vars(FS.FolderPath SrcDir, FS.FileName SrcFile, FS.FolderPath DstDir)
            => CmdVars.load(
                ("SrcDir", SrcDir.Format(PathSeparator.BS)),
                ("SrcFile", SrcFile.Format()),
                ("DstDir", DstDir.Format(PathSeparator.BS))
                );
    }
}