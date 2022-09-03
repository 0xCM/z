//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands
{
    using static AsmRegBits;

    using I = RegIndexCode;
    using G = rSeg;
    using K = AsmRegTokens.SegReg;
    using O = AsmOperand;
    using C = RegClassCode;
    using api = AsmRegs;

    public readonly struct rSeg: IRegOp64<G>
    {
        public RegIndexCode Index {get;}

        [MethodImpl(Inline)]
        public rSeg(RegIndexCode index)
        {
            Index = index;
        }


        [MethodImpl(Inline)]
        public O Untyped()
            => new O(this);

        public string Format()
            => ((K)Index).ToString();

        public override string ToString()
            => Format();

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => NativeSizeCode.W64;
        }

        public RegClassCode RegClassCode
        {
            [MethodImpl(Inline)]
            get => RegClassCode.DB;
        }

        public RegClass RegClass
        {
            [MethodImpl(Inline)]
            get => RegClassCode;
        }

        [MethodImpl(Inline)]
        public static implicit operator RegOp(G src)
            => reg(src.Size, src.RegClassCode, src.Index);

        [MethodImpl(Inline)]
        public static implicit operator O(G src)
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
    }

    public readonly struct cs : IRegOp64<cs>
    {
        public I Index => I.r0;

        [MethodImpl(Inline)]
        public static implicit operator G(cs src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(cs src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(cs src)
            => (G)src;
    }

    public readonly struct ds : IRegOp64<ds>
    {
        public I Index => I.r1;

        [MethodImpl(Inline)]
        public static implicit operator G(ds src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(ds src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(ds src)
            => (G)src;
    }

    public readonly struct ss : IRegOp64<ss>
    {
        public I Index => I.r2;

        [MethodImpl(Inline)]
        public static implicit operator G(ss src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(ss src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(ss src)
            => (G)src;
    }

    public readonly struct es : IRegOp64<es>
    {
        public I Index => I.r3;

        [MethodImpl(Inline)]
        public static implicit operator G(es src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(es src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(es src)
            => (G)src;

    }

    public readonly struct fs : IRegOp64<fs>
    {
        public I Index => I.r4;

        [MethodImpl(Inline)]
        public static implicit operator G(fs src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(fs src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(fs src)
            => (G)src;

    }

    public readonly struct gs : IRegOp64<gs>
    {
        public I Index => I.r5;

        [MethodImpl(Inline)]
        public static implicit operator G(gs src)
            => new G(src.Index);

        [MethodImpl(Inline)]
        public static implicit operator K(gs src)
            => (K)src.Index;

        [MethodImpl(Inline)]
        public static implicit operator O(gs src)
            => (G)src;
    }
}