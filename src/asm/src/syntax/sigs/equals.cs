//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

partial class AsmSigs
{
    [Op]
    internal static bool equals(AsmSigExpr a, AsmSigExpr b)
    {
        if(a.Mnemonic != b.Mnemonic)
            return false;

        var count = a.OpCount;

        if(count != b.OpCount)
            return false;

        var opsA = a.Operands();
        var opsB = b.Operands();
        var result = true;
        for(var i=0; i<count; i++)
            result &= skip(opsA,i).Equals(skip(opsB,i));
        return result;
    }
}
