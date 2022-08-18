//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiPackArchive : IFileArchive
    {
        IDbTargets Tables()
            => new DbTargets(Root);

        FS.FilePath ProcessAsmPath()
            => Tables().Path(FS.file("asm.statements", FileKind.Csv));

        FS.FilePath AsmCallsPath()
            => Tables().Path(FS.file("asm.calls", FileKind.Csv));

        FS.FilePath JmpTarget()
            => Tables().Path(FS.file("asm.jumps", FileKind.Csv));

        IDbTargets DetailTables()
            => Tables().Targets("asm.details");
    }
}