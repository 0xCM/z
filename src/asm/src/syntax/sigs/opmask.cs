//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class AsmSigs
{
    public static bool opmask(in AsmSig src, out AsmSigOp dst)
    {
        var result = false;
        var count = src.OpCount;
        dst = AsmSigOp.Empty;
        ref readonly var ops = ref src.Operands;
        for(var i=0; i<count; i++)
        {
            var op = ops[i];
            result = op.Kind == AsmSigTokenKind.OpMask;
            if(result)
            {
                dst = op;
                break;
            }
        }
        return result;
    }
}
