//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

partial class AsmSigs
{
    [MethodImpl(Inline)]
    public static AsmSigExpr expression(AsmMnemonic mnemonic)
        =>  new (mnemonic);

    [MethodImpl(Inline), Op]
    public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0)
        => new (mnemonic, op0);

    [MethodImpl(Inline), Op]
    public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1)
        => new (mnemonic, op0, op1);

    [MethodImpl(Inline), Op]
    public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2)
        => new (mnemonic, op0, op1, op2);

    [MethodImpl(Inline), Op]
    public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3)
        => new (mnemonic, op0, op1, op2, op3);

    [MethodImpl(Inline), Op]
    public static AsmSigExpr expression(AsmMnemonic mnemonic, AsmSigOpExpr op0, AsmSigOpExpr op1, AsmSigOpExpr op2, AsmSigOpExpr op3, AsmSigOpExpr op4)
        => new (mnemonic, op0, op1, op2, op3, op4);

    [Op]
    public static AsmSigExpr expression(AsmMnemonic mnemonic, ReadOnlySpan<string> ops)
    {
        var count = min(ops.Length, AsmSigExpr.MaxOpCount);
        switch(count)
        {
            case 1:
                return expression(mnemonic, skip(ops, 0));
            case 2:
                return expression(mnemonic, skip(ops, 0), skip(ops, 1));
            case 3:
                return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2));
            case 4:
                return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2), skip(ops, 3));
            case 5:
                return expression(mnemonic, skip(ops, 0), skip(ops, 1), skip(ops, 2), skip(ops, 3), skip(ops, 4));
        }

        return expression(mnemonic);
    }
}
