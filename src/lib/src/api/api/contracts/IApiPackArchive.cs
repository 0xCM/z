//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiPackArchive : IFileArchive
    {
        DbArchive Tables()
            => new DbArchive(Root);

        FilePath ProcessAsmPath()
            => Tables().Path(FS.file("asm.statements", FileKind.Csv));

        FilePath AsmCallsPath()
            => Tables().Path(FS.file("asm.calls", FileKind.Csv));

        FilePath JmpTarget()
            => Tables().Path(FS.file("asm.jumps", FileKind.Csv));

        DbArchive DetailTables()
            => Tables().Targets("asm.details");
    }
}