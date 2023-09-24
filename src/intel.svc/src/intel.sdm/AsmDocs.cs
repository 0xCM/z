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

    
}