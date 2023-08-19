//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Represents an operand expression of the form BaseReg + IndexReg*Scale + Displacement
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly struct AsmAddress
{
    public readonly RegOp Base;

    public readonly RegOp Index;

    public readonly MemoryScale Scale;

    public readonly Disp Disp;

    [MethodImpl(Inline)]
    public AsmAddress(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
    {
        Base = @base;
        Index = index;
        Scale = scale;
        Disp = disp;
    }

    public bool HasIndex
    {
        [MethodImpl(Inline)]
        get => Index.IsNonEmpty;
    }

    public bool HasScale
    {
        [MethodImpl(Inline)]
        get => Scale.IsNonEmpty;
    }

    public bool HasDisp
    {
        [MethodImpl(Inline)]
        get => Disp.IsNonZero;
    }

    public string Format()
        => AsmRender.format(this);

    public override string ToString()
        => Format();
}
