//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

partial class AsmSigs
{
    public static string format(in AsmSigOp src)
        => src.IsEmpty ? EmptyString : expression(src).Text;

    public static string format(in AsmSigExpr src)
    {
        var storage = CharBlock64.Null;
        var dst = storage.Data;
        var i=0u;
        text.copy(src.Mnemonic.Format(MnemonicCase.Lowercase), ref i, dst);
        var count = src.OpCount;

        if(count != 0)
            seek(dst,i++) = Chars.Space;

        operands(src, ref i, dst);
        return storage.Format().Trim();
    }

    public static string format(in AsmSig src)
    {
        if(src.IsEmpty)
            return EmptyString;

        var dst = text.buffer();
        dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
        var count = src.OpCount;
        for(byte i=0; i<count; i++)
        {
            if(i != 0)
                dst.Append(", ");
            else
                dst.Append(Chars.Space);

            dst.Append(expression(src[i]).Text);
        }
        return dst.Emit();
    }
}
