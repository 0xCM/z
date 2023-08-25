//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public struct AsmOperands
{
    public byte OpCount;

    public AsmOperand Op0;

    public AsmOperand Op1;

    public AsmOperand Op2;

    public AsmOperand Op3;

    [MethodImpl(Inline)]
    public AsmOperands()
    {
        OpCount = 0;
        Op0 = default;
        Op1 = default;
        Op2 = default;
        Op3 = default;
    }

    [MethodImpl(Inline)]
    public AsmOperands(AsmOperand op0)
    {
        OpCount = 1;
        Op0 = op0;
        Op1 = default;
        Op2 = default;
        Op3 = default;
    }

    [MethodImpl(Inline)]
    public AsmOperands(AsmOperand op0, AsmOperand op1)
    {
        OpCount = 2;
        Op0 = op0;
        Op1 = op1;
        Op2 = default;
        Op3 = default;
    }

    [MethodImpl(Inline)]
    public AsmOperands(AsmOperand op0, AsmOperand op1, AsmOperand op2)
    {
        OpCount = 2;
        Op0 = op0;
        Op1 = op1;
        Op2 = op2;
        Op3 = default;
    }

    [MethodImpl(Inline)]
    public AsmOperands(AsmOperand op0, AsmOperand op1, AsmOperand op2, AsmOperand op3)
    {
        OpCount = 2;
        Op0 = op0;
        Op1 = op1;
        Op2 = op2;
        Op3 = op3;
    }

    public string Format()
        => AsmRender.format(this);

    public override string ToString()
        => Format();

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => OpCount == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => OpCount != 0;
    }


    public static AsmOperands Empty => default;
}
