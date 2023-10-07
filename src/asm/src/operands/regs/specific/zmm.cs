//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = zmm;
using K = AsmRegTokens.ZmmReg;
using O = AsmOperand;
using C = RegClassCode;
using api = AsmRegs;

public readonly struct zmm : IRegOp256<G>
{
    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public zmm(I index)
    {
        IndexCode = index;
    }

    public string Format()
        => ((K)IndexCode).ToString();

    public override string ToString()
        => Format();

    public NativeSizeCode Size
    {
        [MethodImpl(Inline)]
        get => NativeSizeCode.W512;
    }

    public C RegClassCode
    {
        [MethodImpl(Inline)]
        get => C.ZMM;
    }

    public RegClass RegClass
    {
        [MethodImpl(Inline)]
        get => RegClassCode;
    }


    [MethodImpl(Inline)]
    public O Untyped()
        => new (this);

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
        => new G((I)src);

    [MethodImpl(Inline)]
    public static implicit operator G(I src)
        => new G(src);

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

public readonly struct zmm0 : IRegOp512<zmm0>
{
    public I IndexCode => I.r0;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm0 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm0 src)
        => (K)src.IndexCode;
}

public readonly struct zmm1 : IRegOp512<zmm1>
{
    public I IndexCode => I.r1;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm1 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm1 src)
        => (K)src.IndexCode;
}

public readonly struct zmm2 : IRegOp512<zmm2>
{
    public I IndexCode => I.r2;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm2 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm2 src)
        => (K)src.IndexCode;
}

public readonly struct zmm3 : IRegOp512<zmm3>
{
    public I IndexCode => I.r3;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm3 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm3 src)
        => (K)src.IndexCode;
}

public readonly struct zmm4 : IRegOp512<zmm4>
{
    public I IndexCode => I.r4;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm4 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm4 src)
        => (K)src.IndexCode;
}

public readonly struct zmm5 : IRegOp512<zmm5>
{
    public I IndexCode => I.r5;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm5 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm5 src)
        => (K)src.IndexCode;
}

public readonly struct zmm6 : IRegOp512<zmm6>
{
    public I IndexCode => I.r6;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm6 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm6 src)
        => (K)src.IndexCode;
}

public readonly struct zmm7 : IRegOp512<zmm7>
{
    public I IndexCode => I.r7;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm7 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm7 src)
        => (K)src.IndexCode;
}

public readonly struct zmm8 : IRegOp512<zmm8>
{
    public I IndexCode => I.r8;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm8 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm8 src)
        => (K)src.IndexCode;
}

public readonly struct zmm9 : IRegOp512<zmm9>
{
    public I IndexCode => I.r9;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm9 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm9 src)
        => (K)src.IndexCode;
}

public readonly struct zmm10 : IRegOp512<zmm10>
{
    public I IndexCode => I.r10;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm10 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm10 src)
        => (K)src.IndexCode;
}

public readonly struct zmm11 : IRegOp512<zmm11>
{
    public I IndexCode => I.r11;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm11 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm11 src)
        => (K)src.IndexCode;
}

public readonly struct zmm12 : IRegOp512<zmm12>
{
    public I IndexCode => I.r12;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm12 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm12 src)
        => (K)src.IndexCode;
}

public readonly struct zmm13 : IRegOp512<zmm13>
{
    public I IndexCode => I.r13;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm13 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm13 src)
        => (K)src.IndexCode;
}

public readonly struct zmm14 : IRegOp512<zmm14>
{
    public I IndexCode => I.r14;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm14 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm14 src)
        => (K)src.IndexCode;
}

public readonly struct zmm15 : IRegOp512<zmm15>
{
    public I IndexCode => I.r15;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm15 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm15 src)
        => (K)src.IndexCode;
}

public readonly struct zmm16 : IRegOp512<zmm16>
{
    public I IndexCode => I.r16;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm16 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm16 src)
        => (K)src.IndexCode;
}

public readonly struct zmm17 : IRegOp512<zmm17>
{
    public I IndexCode => I.r17;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm17 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm17 src)
        => (K)src.IndexCode;
}

public readonly struct zmm18 : IRegOp512<zmm18>
{
    public I IndexCode => I.r18;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm18 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm18 src)
        => (K)src.IndexCode;
}

public readonly struct zmm19 : IRegOp512<zmm19>
{
    public I IndexCode => I.r19;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm19 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm19 src)
        => (K)src.IndexCode;
}

public readonly struct zmm20 : IRegOp512<zmm20>
{
    public I IndexCode => I.r20;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm20 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm20 src)
        => (K)src.IndexCode;
}

public readonly struct zmm21 : IRegOp512<zmm21>
{
    public I IndexCode => I.r21;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm21 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm21 src)
        => (K)src.IndexCode;
}

public readonly struct zmm22 : IRegOp512<zmm22>
{
    public I IndexCode => I.r22;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm22 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm22 src)
        => (K)src.IndexCode;
}

public readonly struct zmm23 : IRegOp512<zmm23>
{
    public I IndexCode => I.r23;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm23 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm23 src)
        => (K)src.IndexCode;
}

public readonly struct zmm24 : IRegOp512<zmm24>
{
    public I IndexCode => I.r24;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm24 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm24 src)
        => (K)src.IndexCode;
}

public readonly struct zmm25 : IRegOp512<zmm25>
{
    public I IndexCode => I.r25;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm25 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm25 src)
        => (K)src.IndexCode;
}

public readonly struct zmm26 : IRegOp512<zmm26>
{
    public I IndexCode => I.r26;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm26 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm26 src)
        => (K)src.IndexCode;
}

public readonly struct zmm27 : IRegOp512<zmm27>
{
    public I IndexCode => I.r27;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm27 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm27 src)
        => (K)src.IndexCode;
}

public readonly struct zmm28 : IRegOp512<zmm28>
{
    public I IndexCode => I.r28;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm28 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm28 src)
        => (K)src.IndexCode;
}

public readonly struct zmm29 : IRegOp512<zmm29>
{
    public I IndexCode => I.r29;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm29 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm29 src)
        => (K)src.IndexCode;
}

public readonly struct zmm30 : IRegOp512<zmm30>
{
    public I IndexCode => I.r30;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm30 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm30 src)
        => (K)src.IndexCode;
}

public readonly struct zmm31 : IRegOp512<zmm31>
{
    public I IndexCode => I.r31;

    [MethodImpl(Inline)]
    public static implicit operator G(zmm31 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(zmm31 src)
        => (K)src.IndexCode;
}
