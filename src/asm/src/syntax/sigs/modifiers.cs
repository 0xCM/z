//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static AsmSigTokens;

partial class AsmSigs
{
    public static AsmModifierKind modifier(OpMaskToken src)
        => src switch
        {
            OpMaskToken.k1 => AsmModifierKind.k1,
            OpMaskToken.z => AsmModifierKind.z,
            OpMaskToken.k1z => AsmModifierKind.k1z,
            OpMaskToken.k2 => AsmModifierKind.k2,
            _ => AsmModifierKind.None,
        };

    public static bool opmask(AsmSigOpExpr src, out string target, out OpMaskToken dst)
    {
        var modifiers = Symbols.index<OpMaskToken>();
        dst = default;
        target = EmptyString;
        var i = text.index(src.Text, Chars.LBrace);
        if(i > 0)
        {
            target = text.trim(text.left(src.Text,i));
            modifiers.ExprKind(text.trim(text.right(src.Text,i-1)), out dst);
            return true;
        }
        return false;
    }
}
