//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class AsmSigs
{
    public static bool modified(in AsmSigOp src)
        => text.contains(src.Format(), Chars.LBrace);

    public static bool modified(in AsmSig src)
    {
        var count = src.OpCount;
        for(var i=0; i<count; i++)
        {
            if(modified(src[i]))
                return true;
        }
        return false;
    }
}
