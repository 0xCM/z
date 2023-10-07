//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = xmm;
using K = AsmRegTokens.XmmReg;
using O = AsmOperand;
using C = RegClassCode;
using api = AsmRegs;

public readonly struct xmm : IRegOp128<G>
{
    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public xmm(I index)
    {
        IndexCode = index;
    }

    public AsmRegName Name
        => api.name(this);

    public string Format()
        => Name.Format();

    public override string ToString()
        => Format();

    public NativeSizeCode Size
    {
        [MethodImpl(Inline)]
        get => NativeSizeCode.W128;
    }

    public C RegClassCode
    {
        [MethodImpl(Inline)]
        get => C.XMM;
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
        => reg(src.Size, src.RegClassCode, src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator AsmOperand(G src)
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
    public static implicit operator G(RegKind src)
        => new G(index(src));

    [MethodImpl(Inline)]
    public static G operator ++(G src)
        => api.next(src);

    [MethodImpl(Inline)]
    public static G operator --(G src)
        => api.prior(src);
}

public readonly struct xmm0 : IRegOp128<xmm0>
{
    public I IndexCode => I.r0;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm0 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm0 src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(xmm0 src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(xmm0 src)
        => (G)src;
}

public readonly struct xmm1 : IRegOp128<xmm1>
{
    public I IndexCode => I.r1;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm1 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm1 src)
        => (K)src.IndexCode;
}

public readonly struct xmm2 : IRegOp128<xmm2>
{
    public I IndexCode => I.r2;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm2 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm2 src)
        => (K)src.IndexCode;
}

public readonly struct xmm3 : IRegOp128<xmm3>
{
    public I IndexCode => I.r3;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm3 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm3 src)
        => (K)src.IndexCode;
}

public readonly struct xmm4 : IRegOp128<xmm4>
{
    public I IndexCode => I.r4;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm4 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm4 src)
        => (K)src.IndexCode;
}

public readonly struct xmm5 : IRegOp128<xmm5>
{
    public I IndexCode => I.r5;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm5 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm5 src)
        => (K)src.IndexCode;
}

public readonly struct xmm6 : IRegOp128<xmm6>
{
    public I IndexCode => I.r6;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm6 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm6 src)
        => (K)src.IndexCode;
}

public readonly struct xmm7 : IRegOp128<xmm7>
{
    public I IndexCode => I.r7;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm7 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm7 src)
        => (K)src.IndexCode;
}

public readonly struct xmm8 : IRegOp128<xmm8>
{
    public I IndexCode => I.r8;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm8 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm8 src)
        => (K)src.IndexCode;
}

public readonly struct xmm9 : IRegOp128<xmm9>
{
    public I IndexCode => I.r9;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm9 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm9 src)
        => (K)src.IndexCode;
}

public readonly struct xmm10 : IRegOp128<xmm10>
{
    public I IndexCode => I.r10;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm10 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm10 src)
        => (K)src.IndexCode;
}

public readonly struct xmm11 : IRegOp128<xmm11>
{
    public I IndexCode => I.r11;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm11 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm11 src)
        => (K)src.IndexCode;
}

public readonly struct xmm12 : IRegOp128<xmm12>
{
    public I IndexCode => I.r12;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm12 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm12 src)
        => (K)src.IndexCode;
}

public readonly struct xmm13 : IRegOp128<xmm13>
{
    public I IndexCode => I.r13;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm13 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm13 src)
        => (K)src.IndexCode;
}

public readonly struct xmm14 : IRegOp128<xmm14>
{
    public I IndexCode => I.r14;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm14 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm14 src)
        => (K)src.IndexCode;
}

public readonly struct xmm15 : IRegOp128<xmm15>
{
    public I IndexCode => I.r15;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm15 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm15 src)
        => (K)src.IndexCode;
}

public readonly struct xmm16 : IRegOp128<xmm16>
{
    public I IndexCode => I.r16;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm16 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm16 src)
        => (K)src.IndexCode;
}

public readonly struct xmm17 : IRegOp128<xmm17>
{
    public I IndexCode => I.r17;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm17 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm17 src)
        => (K)src.IndexCode;
}

public readonly struct xmm18 : IRegOp128<xmm18>
{
    public I IndexCode => I.r18;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm18 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm18 src)
        => (K)src.IndexCode;
}

public readonly struct xmm19 : IRegOp128<xmm19>
{
    public I IndexCode => I.r19;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm19 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm19 src)
        => (K)src.IndexCode;
}

public readonly struct xmm20 : IRegOp128<xmm20>
{
    public I IndexCode => I.r20;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm20 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm20 src)
        => (K)src.IndexCode;
}

public readonly struct xmm21 : IRegOp128<xmm21>
{
    public I IndexCode => I.r21;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm21 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm21 src)
        => (K)src.IndexCode;
}

public readonly struct xmm22 : IRegOp128<xmm22>
{
    public I IndexCode => I.r22;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm22 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm22 src)
        => (K)src.IndexCode;
}

public readonly struct xmm23 : IRegOp128<xmm23>
{
    public I IndexCode => I.r23;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm23 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm23 src)
        => (K)src.IndexCode;
}

public readonly struct xmm24 : IRegOp128<xmm24>
{
    public I IndexCode => I.r24;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm24 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm24 src)
        => (K)src.IndexCode;
}

public readonly struct xmm25 : IRegOp128<xmm25>
{
    public I IndexCode => I.r25;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm25 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm25 src)
        => (K)src.IndexCode;
}

public readonly struct xmm26 : IRegOp128<xmm26>
{
    public I IndexCode => I.r26;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm26 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm26 src)
        => (K)src.IndexCode;
}

public readonly struct xmm27 : IRegOp128<xmm27>
{
    public I IndexCode => I.r27;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm27 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm27 src)
        => (K)src.IndexCode;
}

public readonly struct xmm28 : IRegOp128<xmm28>
{
    public I IndexCode => I.r28;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm28 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm28 src)
        => (K)src.IndexCode;
}

public readonly struct xmm29 : IRegOp128<xmm29>
{
    public I IndexCode => I.r29;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm29 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm29 src)
        => (K)src.IndexCode;
}

public readonly struct xmm30 : IRegOp128<xmm30>
{
    public I IndexCode => I.r30;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm30 src)
        => new (src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm30 src)
        => (K)src.IndexCode;
}

public readonly struct xmm31 : IRegOp128<xmm31>
{
    public I IndexCode => I.r31;

    [MethodImpl(Inline)]
    public static implicit operator G(xmm31 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(xmm31 src)
        => (K)src.IndexCode;
}
