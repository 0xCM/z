//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

partial struct asm
{
    [Op]
    public static AsmInstruction inst(in AsmMnemonic mnemonic, params AsmOperand[] ops)
    {
        var count = ops.Length;
        switch(count)
        {
            case 0:
                return inst(mnemonic, out _);
            case 1:
                return inst(mnemonic, skip(ops,0), out _);
            case 2:
                return inst(mnemonic, skip(ops,0), skip(ops,1), out _);
            case 3:
                return inst(mnemonic, skip(ops,0), skip(ops,1), skip(ops,2), out _);
            case 4:
                return inst(mnemonic, skip(ops,0), skip(ops,1), skip(ops,2), skip(ops,3), out _);
        }
        return AsmInstruction.Empty;
    }

    [MethodImpl(Inline), Op]
    public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOperands ops)
        => new (mnemonic, ops);

    [MethodImpl(Inline), Op]
    public static AsmInstruction inst(in AsmMnemonic mnemonic, out AsmInstruction dst)
    {
        dst = inst(mnemonic, AsmOperands.Empty);
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOperand op0, out AsmInstruction dst)
    {
        dst.Mnemonic = mnemonic;
        dst.Operands = AsmOperands.Empty;
        ops(op0, ref dst.Operands);
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOperand op0, in AsmOperand op1, out AsmInstruction dst)
    {
        dst.Mnemonic = mnemonic;
        dst.Operands = AsmOperands.Empty;
        ops(op0, op1, ref dst.Operands);
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, out AsmInstruction dst)
    {
        dst.Mnemonic = mnemonic;
        dst.Operands = AsmOperands.Empty;
        ops(op0, op1, op2, ref dst.Operands);
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static AsmInstruction inst(in AsmMnemonic mnemonic, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, in AsmOperand op3, out AsmInstruction dst)
    {
        dst.Mnemonic = mnemonic;
        dst.Operands = AsmOperands.Empty;
        ops(op0, op1, op2, op3, ref dst.Operands);
        return dst;
    }
}