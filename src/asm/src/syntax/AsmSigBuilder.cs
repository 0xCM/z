//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;

using static AsmSigs;

public struct AsmSigBuilder
{
    public static AsmSigBuilder init(AsmMnemonic mnemonic)
        => new(mnemonic);
    
    readonly AsmMnemonic Mnemonic;

    AsmSigOps Operands;

    byte Index;

    [MethodImpl(Inline)]
    AsmSigBuilder(AsmMnemonic mnemonic)
    {
        Mnemonic = mnemonic;
        Operands = default;
        Index = 0;
    }


}
