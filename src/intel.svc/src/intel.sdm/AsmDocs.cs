//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using System.Linq;

public readonly struct AsmDocs
{
    readonly IDbArchive _Root;
    
    public AsmDocs()
    {
        _Root = AppSettings.Default.DevRoot().Scoped("asm/docs");        
    }

    public IDbArchive Root()
        => _Root;

    public IDbArchive SdmDocs()
        => Root().Scoped("sdm");
    
    public IDbArchive SdmInstructions()
        => SdmDocs().Scoped("instructions");
    
    public ParallelQuery<FilePath> SdmInstructionFiles()
        => SdmInstructions().Files(FileKind.Csv).AsParallel();    
}