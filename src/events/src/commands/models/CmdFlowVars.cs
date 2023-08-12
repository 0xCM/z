//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public struct CmdFlowVars
{
    public static CmdFlowVars create()
        => new CmdFlowVars();

    public @string Actor;

    public FilePath SrcPath;

    public FilePath DstPath;

    public FolderPath SrcDir;

    public FileName SrcFile;

    public FolderPath DstDir;

    public @string SrcId;

    public CmdVars ToCmdVars()
        => CmdScripts.vars(
        (nameof(SrcDir), SrcDir.IsNonEmpty ? SrcDir.Format(PathSeparator.BS) : EmptyString),
        (nameof(SrcFile), SrcFile.IsNonEmpty ? SrcFile.Format() : EmptyString),
        (nameof(DstDir), DstDir.IsNonEmpty ? DstDir.Format(PathSeparator.BS) : EmptyString),
        (nameof(SrcId), SrcId),
        (nameof(Actor), Actor),
        (nameof(SrcPath), SrcPath.IsNonEmpty ? SrcPath.Format(PathSeparator.BS) : EmptyString),
        (nameof(DstPath), DstPath.IsNonEmpty ? DstPath.Format(PathSeparator.BS) : EmptyString)
        );
}
