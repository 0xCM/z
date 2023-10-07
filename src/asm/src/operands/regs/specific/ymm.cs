//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = ymm;
using K = AsmRegTokens.YmmReg;
using O = AsmOperand;
using C = RegClassCode;
using api = AsmRegs;

public readonly struct ymm : IRegOp256<ymm>
{
    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public ymm(I index)
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
        get => NativeSizeCode.W256;
    }

    public C RegClassCode
    {
        [MethodImpl(Inline)]
        get => C.YMM;
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

public readonly struct ymm0 : IRegOp256<ymm0>
{
    public I IndexCode => I.r0;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm0 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm0 src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(ymm0 src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(ymm0 src)
        => (G)src;
}

public readonly struct ymm1 : IRegOp256<ymm1>
{
    public I IndexCode => I.r1;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm1 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm1 src)
        => (K)src.IndexCode;
}

public readonly struct ymm2 : IRegOp256<ymm2>
{
    public I IndexCode => I.r2;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm2 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm2 src)
        => (K)src.IndexCode;
}

public readonly struct ymm3 : IRegOp256<ymm3>
{
    public I IndexCode => I.r3;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm3 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm3 src)
        => (K)src.IndexCode;
}

public readonly struct ymm4 : IRegOp256<ymm4>
{
    public I IndexCode => I.r4;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm4 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm4 src)
        => (K)src.IndexCode;
}

public readonly struct ymm5 : IRegOp256<ymm5>
{
    public I IndexCode => I.r5;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm5 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm5 src)
        => (K)src.IndexCode;
}

public readonly struct ymm6 : IRegOp256<ymm6>
{
    public I IndexCode => I.r6;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm6 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm6 src)
        => (K)src.IndexCode;
}

public readonly struct ymm7 : IRegOp256<ymm7>
{
    public I IndexCode => I.r7;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm7 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm7 src)
        => (K)src.IndexCode;
}

public readonly struct ymm8 : IRegOp256<ymm8>
{
    public I IndexCode => I.r8;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm8 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm8 src)
        => (K)src.IndexCode;
}

public readonly struct ymm9 : IRegOp256<ymm9>
{
    public I IndexCode => I.r9;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm9 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm9 src)
        => (K)src.IndexCode;
}

public readonly struct ymm10 : IRegOp256<ymm10>
{
    public I IndexCode => I.r10;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm10 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm10 src)
        => (K)src.IndexCode;
}

public readonly struct ymm11 : IRegOp256<ymm11>
{
    public I IndexCode => I.r11;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm11 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm11 src)
        => (K)src.IndexCode;
}

public readonly struct ymm12 : IRegOp256<ymm12>
{
    public I IndexCode => I.r12;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm12 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm12 src)
        => (K)src.IndexCode;
}

public readonly struct ymm13 : IRegOp256<ymm13>
{
    public I IndexCode => I.r13;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm13 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm13 src)
        => (K)src.IndexCode;
}

public readonly struct ymm14 : IRegOp256<ymm14>
{
    public I IndexCode => I.r14;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm14 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm14 src)
        => (K)src.IndexCode;
}

public readonly struct ymm15 : IRegOp256<ymm15>
{
    public I IndexCode => I.r15;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm15 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm15 src)
        => (K)src.IndexCode;
}

public readonly struct ymm16 : IRegOp256<ymm16>
{
    public I IndexCode => I.r16;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm16 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm16 src)
        => (K)src.IndexCode;
}

public readonly struct ymm17 : IRegOp256<ymm17>
{
    public I IndexCode => I.r17;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm17 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm17 src)
        => (K)src.IndexCode;
}

public readonly struct ymm18 : IRegOp256<ymm18>
{
    public I IndexCode => I.r18;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm18 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm18 src)
        => (K)src.IndexCode;
}

public readonly struct ymm19 : IRegOp256<ymm19>
{
    public I IndexCode => I.r19;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm19 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm19 src)
        => (K)src.IndexCode;
}

public readonly struct ymm20 : IRegOp256<ymm20>
{
    public I IndexCode => I.r20;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm20 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm20 src)
        => (K)src.IndexCode;
}

public readonly struct ymm21 : IRegOp256<ymm21>
{
    public I IndexCode => I.r21;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm21 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm21 src)
        => (K)src.IndexCode;
}

public readonly struct ymm22 : IRegOp256<ymm22>
{
    public I IndexCode => I.r22;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm22 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm22 src)
        => (K)src.IndexCode;
}

public readonly struct ymm23 : IRegOp256<ymm23>
{
    public I IndexCode => I.r23;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm23 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm23 src)
        => (K)src.IndexCode;
}

public readonly struct ymm24 : IRegOp256<ymm24>
{
    public I IndexCode => I.r24;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm24 src)
        => new (src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm24 src)
        => (K)src.IndexCode;
}

public readonly struct ymm25 : IRegOp256<ymm25>
{
    public I IndexCode => I.r25;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm25 src)
        => new (src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm25 src)
        => (K)src.IndexCode;
}

public readonly struct ymm26 : IRegOp256<ymm26>
{
    public I IndexCode => I.r26;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm26 src)
        => new (src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm26 src)
        => (K)src.IndexCode;
}

public readonly struct ymm27 : IRegOp256<ymm27>
{
    public I IndexCode => I.r27;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm27 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm27 src)
        => (K)src.IndexCode;
}

public readonly struct ymm28 : IRegOp256<ymm28>
{
    public I IndexCode => I.r28;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm28 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm28 src)
        => (K)src.IndexCode;
}

public readonly struct ymm29 : IRegOp256<ymm29>
{
    public I IndexCode => I.r29;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm29 src)
        => new (src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm29 src)
        => (K)src.IndexCode;
}

public readonly struct ymm30 : IRegOp256<ymm30>
{
    public I IndexCode => I.r30;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm30 src)
        => new (src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm30 src)
        => (K)src.IndexCode;
}

public readonly struct ymm31 : IRegOp256<ymm31>
{
    public I IndexCode => I.r31;

    [MethodImpl(Inline)]
    public static implicit operator G(ymm31 src)
        => new (src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ymm31 src)
        => (K)src.IndexCode;
}
