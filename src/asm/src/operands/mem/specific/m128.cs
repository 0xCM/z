//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct m128 : IMemOp128<m128>
    {
        public readonly NativeSize TargetSize;

        public readonly AsmAddress Address;

        [MethodImpl(Inline)]
        public m128(AsmAddress address)
        {
            Address = address;
            TargetSize = NativeSizeCode.W128;
        }

        [MethodImpl(Inline)]
        public m128(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
            TargetSize = NativeSizeCode.W128;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem128;

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
        public static implicit operator m128(AsmAddress src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m128 src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator MemOp(m128 src)
            => new (src.TargetSize, src.Address);
    }
}