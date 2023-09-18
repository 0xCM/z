//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

partial class AsmSigs
{
    [MethodImpl(Inline), Op]
    public static AsmSigToken token(AsmSigTokenKind kind, byte value)
        => new (kind,value);

    public static Index<AsmSigToken> tokenize(in AsmSig src)
    {
        var ops = src.Operands;
        var dst = alloc<AsmSigToken>(src.OpCount);
        for(var i=z8; i<src.OpCount; i++)
        {
            var op = src[i];
            seek(dst,i) = token(op.Kind, op.Value);
        }
        return dst;
    }
}
