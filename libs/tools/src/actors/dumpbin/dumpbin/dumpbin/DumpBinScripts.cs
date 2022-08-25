//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    internal class DumpBinScripts
    {
        public static ToolScript DumpObj(FilePath input, IDbTargets dst)
            => Tooling.script(dst.Path("dump-obj",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

        public static ToolScript DumpDll(FilePath input, IDbTargets dst)
            => Tooling.script(dst.Path("dump-dll",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

        public static ToolScript DumpExe(FilePath input, IDbTargets dst)
            => Tooling.script(dst.Path("dump-exe",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

        public static ToolScript DumpLib(FilePath input, IDbTargets dst)
            => Tooling.script(dst.Path("dump-lib",FileKind.Cmd), vars(input.FolderPath, input.FileName, dst.Root));

        static CmdVars vars(FolderPath SrcDir, FS.FileName SrcFile, FolderPath DstDir)
            => CmdVars.load(
                ("SrcDir", SrcDir.Format(PathSeparator.BS)),
                ("SrcFile", SrcFile.Format()),
                ("DstDir", DstDir.Format(PathSeparator.BS))
                );
    }
}