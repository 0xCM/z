//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    using static AsmRegBits;

    using I = RegIndexCode;
    using G = xCr;
    using K = AsmRegTokens.XControlReg;
    using O = AsmOperand;
    using C = RegClassCode;
    using api = AsmRegs;

    public readonly struct xCr : IRegOp64<xCr>
    {
        public RegIndexCode Index {get;}

        [MethodImpl(Inline)]
        public xCr(I index)
        {
            Index = index;
        }

        public string Format()
            => ((K)Index).ToString();

        public override string ToString()
            => Format();

        public NativeSizeCode Size
        {
            [MethodImpl(Inline)]
            get => NativeSizeCode.W64;
        }

        public RegClassCode RegClassCode
        {
            [MethodImpl(Inline)]
            get => RegClassCode.XCR;
        }

        public RegClass RegClass
        {
            [MethodImpl(Inline)]
            get => RegClassCode;
        }


        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        [MethodImpl(Inline)]
        public static implicit operator RegOp(G src)
            => reg(src.Size, src.RegClassCode, src.Index);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(G src)
            => src.Untyped();

        [MethodImpl(Inline)]
        public static implicit operator K(G src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator G(K src)
            => new G((I)src);

        [MethodImpl(Inline)]
        public static implicit operator G(uint4 src)
            => new G((I)(byte)src);

        [MethodImpl(Inline)]
        public static implicit operator G(I src)
            => new G(src);

        [MethodImpl(Inline)]
        public static implicit operator I(G src)
            => src.Index;

        [MethodImpl(Inline)]
        public static explicit operator byte(G src)
            => (byte)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator G(Sym<K> src)
            => new G((I)src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator G(RegKind src)
            => new G(index(src));
    }
}