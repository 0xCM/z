//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly struct m256 : IMemOp256<m256>
{
    public readonly NativeSize TargetSize;

    public readonly AsmAddress Address;

    [MethodImpl(Inline)]
    public m256(AsmAddress address)
    {
        Address = address;
        TargetSize = NativeSizeCode.W256;
    }

    [MethodImpl(Inline)]
    public m256(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
    {
        Address = new AsmAddress(@base, index, scale, disp);
        TargetSize = NativeSizeCode.W256;
    }

    public AsmOpKind OpKind
        => AsmOpKind.Mem256;

    public AsmOpClass OpClass
        => AsmOpClass.Mem;

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => TargetSize;
    }

    AsmAddress IMemOp.Address
        => Address;

    NativeSize IMemOp.TargetSize
        => Size;

    public string Format()
        => MemOp.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator m256(AsmAddress src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator AsmOperand(m256 src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator MemOp(m256 src)
        => new (src.TargetSize, src.Address);
}
