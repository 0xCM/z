//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct m512 : IMemOp512<m512>
    {
        public readonly NativeSize TargetSize;

        public readonly AsmAddress Address;

        [MethodImpl(Inline)]
        public m512(AsmAddress address)
        {
            Address = address;
            TargetSize = NativeSizeCode.W512;
        }

        [MethodImpl(Inline)]
        public m512(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        {
            Address = new AsmAddress(@base, index, scale, disp);
            TargetSize = NativeSizeCode.W512;
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => TargetSize;
        }

        public AsmOpKind OpKind
            => AsmOpKind.Mem512;

        public AsmOpClass OpClass
            => AsmOpClass.Mem;

        public string Format()
            => MemOp.format(this);

        public override string ToString()
            => Format();

       AsmAddress IMemOp.Address
            => Address;

        NativeSize IMemOp.TargetSize
            => Size;

        [MethodImpl(Inline)]
        public static implicit operator m512(AsmAddress src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m512 src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator MemOp(m512 src)
            => new (src.TargetSize, src.Address);
    }
}