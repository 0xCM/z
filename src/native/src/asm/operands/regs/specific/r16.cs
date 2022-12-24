//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    using static AsmRegBits;

    using I = RegIndexCode;
    using G = r16;
    using K = AsmRegTokens.Gp16Reg;
    using O = AsmOperand;
    using C = RegClassCode;
    using api = AsmRegs;

    public readonly struct r16 : IRegOp16<G>
    {
        internal const NativeSizeCode W = NativeSizeCode.W16;

        public I Index {get;}

        [MethodImpl(Inline)]
        public r16(I index)
        {
            Index = index;
        }


        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        public string Format()
            => ((K)Index).ToString();

        public override string ToString()
            => Format();

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => W;
        }

        public RegClassCode RegClassCode
        {
            [MethodImpl(Inline)]
            get => RegClassCode.GP;
        }

        public RegClass RegClass
        {
            [MethodImpl(Inline)]
            get => RegClassCode;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOps.kind(AsmOpClass.Reg, Size);
        }

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

        [MethodImpl(Inline)]
        public static G operator ++(G src)
            => api.next(src);

        [MethodImpl(Inline)]
        public static G operator --(G src)
            => api.prior(src);
    }

    public readonly struct ax : IRegOp16<ax>
    {
        public I Index => I.r0;

        public AsmRegName Name
        {
            [MethodImpl(Inline)]
            get => api.name(Size, RegClass, Index);
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => G.W;
        }

        public RegClass RegClass
        {
            [MethodImpl(Inline)]
            get => C.GP;
        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator G(ax src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(ax src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(ax src)
            => (G)src;

        [MethodImpl(Inline)]
        public static implicit operator RegOp(ax src)
            => (G)src;

    }

    public struct cx : IRegOp16<cx>
    {
        public I Index => I.r1;

        [MethodImpl(Inline)]
        public static implicit operator G(cx src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(cx src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(cx src)
            => (G)src;

        [MethodImpl(Inline)]
        public static implicit operator RegOp(cx src)
            => (G)src;
    }

    public struct dx : IRegOp16<dx>
    {
        public I Index => I.r2;

        [MethodImpl(Inline)]
        public static implicit operator G(dx src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(dx src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(dx src)
            => (G)src;

        [MethodImpl(Inline)]
        public static implicit operator RegOp(dx src)
            => (G)src;
    }

    public struct bx : IRegOp16<bx>
    {
        public I Index => I.r3;

        [MethodImpl(Inline)]
        public static implicit operator G(bx src)
            => new(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(bx src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(bx src)
            => (G)src;

        [MethodImpl(Inline)]
        public static implicit operator RegOp(bx src)
            => (G)src;
    }

    public struct si : IRegOp16<si>
    {
        public I Index => I.r4;

        [MethodImpl(Inline)]
        public static implicit operator G(si src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(si src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(si src)
            => (G)src;

        [MethodImpl(Inline)]
        public static implicit operator RegOp(si src)
            => (G)src;
    }

    public struct di : IRegOp16<di>
    {
        public I Index => I.r5;

        [MethodImpl(Inline)]
        public static implicit operator G(di src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(di src)
            => (K)src.Index;
    }

    public struct sp : IRegOp16<sp>
    {
        public I Index => I.r6;

        [MethodImpl(Inline)]
        public static implicit operator G(sp src)
            => new(src.Index);
    }

    public struct bp : IRegOp16<bp>
    {
        public I Index => I.r7;

        [MethodImpl(Inline)]
        public static implicit operator G(bp src)
            => new(src.Index);
    }

    public struct r8w : IRegOp16<r8w>
    {
        public I Index => I.r8;

        [MethodImpl(Inline)]
        public static implicit operator G(r8w src)
            => new(src.Index);
    }

    public struct r9w : IRegOp16<r9w>
    {
        public I Index => I.r9;

        [MethodImpl(Inline)]
        public static implicit operator G(r9w src)
            => new(src.Index);
    }

    public struct r10w : IRegOp16<r10w>
    {
        public I Index => I.r10;

        [MethodImpl(Inline)]
        public static implicit operator G(r10w src)
            => new(src.Index);
    }

    public struct r11w : IRegOp16<r11w>
    {
        public I Index => I.r11;

        [MethodImpl(Inline)]
        public static implicit operator G(r11w src)
            => new(src.Index);
    }

    public struct r12w : IRegOp16<r12w>
    {
        public I Index => I.r12;

        [MethodImpl(Inline)]
        public static implicit operator G(r12w src)
            => new (src.Index);
    }

    public struct r13w : IRegOp16<r13w>
    {
        public I Index => I.r13;

        [MethodImpl(Inline)]
        public static implicit operator G(r13w src)
            => new (src.Index);
    }

    public struct r14w : IRegOp16<r14w>
    {
        public I Index => I.r14;

        [MethodImpl(Inline)]
        public static implicit operator G(r14w src)
            => new (src.Index);
    }

    public struct r15w : IRegOp16<r15w>
    {
        public I Index => I.r15;

        [MethodImpl(Inline)]
        public static implicit operator G(r15w src)
            => new (src.Index);
    }

}