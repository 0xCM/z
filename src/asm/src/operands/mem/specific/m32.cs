//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct m32 : IMemOp32<m32>
    {
        public readonly NativeSize TargetSize;

        public readonly AsmAddress Address;

        [MethodImpl(Inline)]
        public m32(AsmAddress address)
        {
            Address = address;
            TargetSize = NativeSizeCode.W32;
        }

        [MethodImpl(Inline)]
        public m32(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
            TargetSize = NativeSizeCode.W32;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem32;

        public AsmOpClass OpClass
            => AsmOpClass.Mem;

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => TargetSize;
        }

        public string Format()
            => MemOp.format(this);

        public override string ToString()
            => Format();

        AsmAddress IMemOp.Address
            => Address;

        NativeSize IMemOp.TargetSize
            => Size;

        [MethodImpl(Inline)]
        public static implicit operator m32(AsmAddress src)
            => new m32(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator MemOp(m32 src)
            => new MemOp(src.TargetSize, src.Address);
    }
}