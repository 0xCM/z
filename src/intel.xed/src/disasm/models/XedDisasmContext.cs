//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

public class XedDisasmContext
{
    public readonly IDbArchive ProjectRoot;

    public readonly ConcurrentBag<XedDisasmDetailBlock> Blocks;

    public readonly InstBlockPatterns InstPatterns;
    
    public readonly MachineMode Mode;

    readonly IDbArchive DisasmTargets;
     
    public XedDisasmContext(IDbArchive root)
    {
        ProjectRoot = root;
        Mode = MachineMode.Default;
        Blocks = new();
        InstPatterns = XedTables.Instructions().Patterns;
        DisasmTargets = root.Scoped("xed");
    }

    public FilePath DisasmSummaryPath(FilePath src)
        =>  (DisasmTargets ?? src.FolderPath.DbArchive()).Path(FS.file(string.Format("{0}.summary", src.FileName.WithoutExtension), FS.Csv));

    public FilePath DisasmDetailPath(FilePath src)
        => (DisasmTargets ?? src.FolderPath.DbArchive()).Path(FS.file(string.Format("{0}.details", src.FileName.WithoutExtension), FS.Csv));

    public FilePath DisasmChecksPath(FilePath src)
        => (DisasmTargets ?? src.FolderPath.DbArchive()).Path(FS.file(string.Format("{0}.checks", src.FileName.WithoutExtension), FS.Txt));

    public FilePath DisasmOpsPath(FilePath src)
        => (DisasmTargets ?? src.FolderPath.DbArchive()).Path(FS.file(string.Format("{0}.ops", src.FileName.WithoutExtension.Format()), FS.Txt));
}
