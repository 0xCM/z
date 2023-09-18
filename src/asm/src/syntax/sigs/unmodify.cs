//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class AsmSigs
{
    public static AsmSig unmodify(in AsmSig src)
    {
        var ops = new AsmSigOps();
        for(byte i=0; i<src.OpCount; i++)
            ops[i] = src[i].WithoutModifier();
        return new AsmSig(src.Mnemonic, ops);
    }
}
