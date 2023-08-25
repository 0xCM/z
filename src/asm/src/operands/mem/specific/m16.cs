//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly struct m16 : IMemOp16<m16>
{
    public readonly NativeSize TargetSize;

    public readonly AsmAddress Address;

    [MethodImpl(Inline)]
    public m16(AsmAddress address)
    {
        Address = address;
        TargetSize = NativeSizeCode.W16;
    }

    [MethodImpl(Inline)]
    public m16(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
    {
        Address = new AsmAddress(@base, index, scale, disp);
        TargetSize = NativeSizeCode.W16;
    }

    public AsmOpKind OpKind
        => AsmOpKind.Mem16;

    public AsmOpClass OpClass
        => AsmOpClass.Mem;

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => TargetSize;
    }

    AsmAddress IMemOp.Address
        => Address;

    public string Format()
        => MemOp.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator m16(AsmAddress src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator AsmOperand(m16 src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator MemOp(m16 src)
        => new (src.TargetSize, src.Address);
}
