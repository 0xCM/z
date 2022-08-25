//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct WsCmdVars
    {
        public static WsCmdVars create()
            => new WsCmdVars();

        public @string Actor;

        public FilePath SrcPath;

        public FilePath DstPath;

        public FS.FolderPath SrcDir;

        public FS.FileName SrcFile;

        public FS.FolderPath DstDir;

        public @string SrcId;

        public CmdVars ToCmdVars()
            => CmdVars.load(
            (nameof(SrcDir), SrcDir.IsNonEmpty ? SrcDir.Format(PathSeparator.BS) : EmptyString),
            (nameof(SrcFile), SrcFile.IsNonEmpty ? SrcFile.Format() : EmptyString),
            (nameof(DstDir), DstDir.IsNonEmpty ? DstDir.Format(PathSeparator.BS) : EmptyString),
            (nameof(SrcId), SrcId),
            (nameof(Actor), Actor),
            (nameof(SrcPath), SrcPath.IsNonEmpty ? SrcPath.Format(PathSeparator.BS) : EmptyString),
            (nameof(DstPath), DstPath.IsNonEmpty ? DstPath.Format(PathSeparator.BS) : EmptyString)
            );
    }
}