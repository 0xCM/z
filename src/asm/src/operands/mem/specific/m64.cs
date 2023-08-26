//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly struct m64 : IMemOp64<m64>
{
    public readonly NativeSize TargetSize;

    public readonly AsmAddress Address;

    [MethodImpl(Inline)]
    public m64(AsmAddress address)
    {
        Address = address;
        TargetSize = NativeSizeCode.W64;
    }

    [MethodImpl(Inline)]
    public m64(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
    {
        Address = new AsmAddress(@base, index, scale, disp);
        TargetSize = NativeSizeCode.W64;
    }

    public AsmOpKind OpKind
        => AsmOpKind.Mem64;

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
    public static implicit operator m64(AsmAddress src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator AsmOperand(m64 src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator MemOp(m64 src)
        => new (src.TargetSize, src.Address);

}
