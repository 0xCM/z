//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    using static AsmRegBits;

    using I = RegIndexCode;
    using G = rCr;
    using K = AsmRegTokens.ControlReg;
    using O = AsmOperand;
    using C = RegClassCode;
    using api = AsmRegs;

    public readonly struct rCr : IRegOp64<G>
    {
        public I IndexCode {get;}

        [MethodImpl(Inline)]
        public rCr(I index)
        {
            IndexCode = index;
        }

        [MethodImpl(Inline)]
        public O Untyped()
            => new (this);

        public string Format()
            => ((K)IndexCode).ToString();

        public override string ToString()
            => Format();

        public NativeSizeCode Size
        {
            [MethodImpl(Inline)]
            get => NativeSizeCode.W64;
        }

        public C RegClassCode
        {
            [MethodImpl(Inline)]
            get => C.CR;
        }

        public RegClass RegClass
        {
            [MethodImpl(Inline)]
            get => RegClassCode;
        }

        [MethodImpl(Inline)]
        public static implicit operator RegOp(G src)
            => reg(src.Size, src.RegClassCode, src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator O(G src)
            => src.Untyped();

        [MethodImpl(Inline)]
        public static implicit operator K(G src)
            => (K)src.IndexCode;

        [MethodImpl(Inline)]
        public static implicit operator G(K src)
            => new((I)src);

        [MethodImpl(Inline)]
        public static implicit operator G(I src)
            => new(src);

        [MethodImpl(Inline)]
        public static implicit operator I(G src)
            => src.IndexCode;

        [MethodImpl(Inline)]
        public static explicit operator byte(G src)
            => (byte)src.IndexCode;

        [MethodImpl(Inline)]
        public static implicit operator G(Sym<K> src)
            => new((I)src.Kind);

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

    public readonly struct cr0 : IRegOp64<cr0>
    {
        public I IndexCode => I.r0;

        [MethodImpl(Inline)]
        public static implicit operator G(cr0 src)
            => new G(src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator K(cr0 src)
            => (K)src.IndexCode;

        [MethodImpl(Inline)]
        public static implicit operator O(cr0 src)
            => (G)src;

        [MethodImpl(Inline)]
        public static implicit operator RegOp(cr0 src)
            => (G)src;

    }

    public readonly struct cr1 : IRegOp64<cr1>
    {
        public I IndexCode => I.r1;

        [MethodImpl(Inline)]
        public static implicit operator G(cr1 src)
            => new G(src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator K(cr1 src)
            => (K)src.IndexCode;

        [MethodImpl(Inline)]
        public static implicit operator O(cr1 src)
            => (G)src;

        [MethodImpl(Inline)]
        public static implicit operator RegOp(cr1 src)
            => (G)src;
    }

    public readonly struct cr2 : IRegOp64<cr2>
    {
        public I IndexCode => I.r2;

        [MethodImpl(Inline)]
        public static implicit operator G(cr2 src)
            => new G(src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator K(cr2 src)
            => (K)src.IndexCode;
    }

    public readonly struct cr3 : IRegOp64<cr3>
    {
        public I IndexCode => I.r3;

        [MethodImpl(Inline)]
        public static implicit operator G(cr3 src)
            => new G(src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator K(cr3 src)
            => (K)src.IndexCode;
    }

    public readonly struct cr4 : IRegOp64<cr4>
    {
        public I IndexCode => I.r4;

        [MethodImpl(Inline)]
        public static implicit operator G(cr4 src)
            => new G(src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator K(cr4 src)
            => (K)src.IndexCode;
    }

    public readonly struct cr5 : IRegOp64<cr5>
    {
        public I IndexCode => I.r5;

        [MethodImpl(Inline)]
        public static implicit operator G(cr5 src)
            => new G(src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator K(cr5 src)
            => (K)src.IndexCode;
    }

    public readonly struct cr6 : IRegOp64<cr6>
    {
        public I IndexCode => I.r6;

        [MethodImpl(Inline)]
        public static implicit operator G(cr6 src)
            => new G(src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator K(cr6 src)
            => (K)src.IndexCode;
    }

    public readonly struct cr7 : IRegOp64<cr7>
    {
        public I IndexCode => I.r7;

        [MethodImpl(Inline)]
        public static implicit operator G(cr7 src)
            => new G(src.IndexCode);

        [MethodImpl(Inline)]
        public static implicit operator K(cr7 src)
            => (K)src.IndexCode;
    }

}