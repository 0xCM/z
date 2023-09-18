//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public record struct AsmOperands
{
    public byte OpCount;

    public AsmOperand Op0;

    public AsmOperand Op1;

    public AsmOperand Op2;

    public AsmOperand Op3;

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
