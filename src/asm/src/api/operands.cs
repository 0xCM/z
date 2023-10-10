//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline)]
    public static ref AsmOperandSet operands(in AsmOperand op0, ref AsmOperandSet dst)
    {
        dst.Op0 = op0;
        dst.Op1 = AsmOperand.Empty;
        dst.Op2 = AsmOperand.Empty;
        dst.Op3 = AsmOperand.Empty;
        dst.OpCount = 1;
        return ref dst;
    }

    [MethodImpl(Inline)]
    public static ref AsmOperandSet operands(in AsmOperand op0, in AsmOperand op1, ref AsmOperandSet dst)
    {
        dst.Op0 = op0;
        dst.Op1 = op1;
        dst.Op2 = AsmOperand.Empty;
        dst.Op3 = AsmOperand.Empty;
        dst.OpCount = 2;
        return ref dst;
    }

    [MethodImpl(Inline)]
    public static ref AsmOperandSet operands(in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, ref AsmOperandSet dst)
    {
        dst.Op0 = op0;
        dst.Op1 = op1;
        dst.Op2 = op2;
        dst.Op3 = AsmOperand.Empty;
        dst.OpCount = 3;
        return ref dst;
    }

    [MethodImpl(Inline)]
    public static ref AsmOperandSet operands(in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, in AsmOperand op3, ref AsmOperandSet dst)
    {
        dst.Op0 = op0;
        dst.Op1 = op1;
        dst.Op2 = op2;
        dst.Op3 = op3;
        dst.OpCount = 4;
        return ref dst;
    }

    [MethodImpl(Inline)]
    public static ref AsmOperandSet operands(in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, in AsmOperand op3, in AsmOperand op4, ref AsmOperandSet dst)
    {
        dst.Op0 = op0;
        dst.Op1 = op1;
        dst.Op2 = op2;
        dst.Op3 = op3;
        dst.Op4 = op4;
        dst.OpCount = 5;
        return ref dst;
    }    
}
