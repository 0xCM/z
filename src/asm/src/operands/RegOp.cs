//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using api = AsmRegs;

using static AsmRegBits;

/// <summary>
/// Specifies a register operand
/// </summary>
public readonly struct RegOp : IRegOp
{
    readonly RegKind Data;

    [MethodImpl(Inline)]
    internal RegOp(ushort src)
        => Data = (RegKind)src;

    [MethodImpl(Inline)]
    public RegOp(RegKind src)
        => Data = src;

    public AsmOpClass OpClass
    {
        [MethodImpl(Inline)]
        get => AsmOpClass.Reg;
    }

    public bit IsEmpty
    {
        [MethodImpl(Inline)]
        get => (ushort)Data == ushort.MaxValue;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => (ushort)Data != ushort.MaxValue;
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => width(this);
    }

    public RegClassCode RegClassCode
    {
        [MethodImpl(Inline)]
        get => @class(this);
    }

    public RegIndexCode IndexCode
    {
        [MethodImpl(Inline)]
        get => index(this);
    }

    public RegKind RegKind
    {
        [MethodImpl(Inline)]
        get => (RegKind)Data;
    }

    public RegClass RegClass
    {
        [MethodImpl(Inline)]
        get => RegClassCode;
    }

    public AsmOpKind OpKind
    {
        [MethodImpl(Inline)]
        get => asm.opkind(AsmOpClass.Reg, Size);
    }

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, IndexCode);
    }

    public string Format()
        => Name.Format().Trim();

    public override string ToString()
        =>  Format();

    [MethodImpl(Inline)]
    public static implicit operator RegKind(RegOp src)
        => src.RegKind;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(RegKind kind)
        => asm.reg(kind);

    [MethodImpl(Inline)]
    public static implicit operator AsmOperand(RegOp src)
        => new (src);

    public static RegOp Empty
    {
        [MethodImpl(Inline)]
        get => new RegOp(ushort.MaxValue);
    }
}
