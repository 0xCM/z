//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = rK;
using K = AsmRegTokens.KReg;
using O = AsmOperand;
using C = RegClassCode;
using api = AsmRegs;

public readonly struct rK : IRegOp64<rK>
{
    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public rK(I index)
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
        get => NativeSizeCode.W64;
    }

    public C RegClassCode
    {
        [MethodImpl(Inline)]
        get => C.MASK;
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
    public static implicit operator O(G src)
        => src.Untyped();

    [MethodImpl(Inline)]
    public static implicit operator K(G src)
        => (K)src.IndexCode;

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
        => src.IndexCode;

    [MethodImpl(Inline)]
    public static explicit operator byte(G src)
        => (byte)src.IndexCode;

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

public readonly struct k0 : IRegOp64<k0>
{
    public I IndexCode => I.r0;

    [MethodImpl(Inline)]
    public static implicit operator G(k0 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(k0 src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(k0 src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(k0 src)
        => (G)src;
}

public readonly struct k1 : IRegOp64<k1>
{
    public I IndexCode => I.r1;

    [MethodImpl(Inline)]
    public static implicit operator G(k1 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(k1 src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(k1 src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(k1 src)
        => (G)src;
}

public readonly struct k2 : IRegOp64<k2>
{
    public I IndexCode => I.r2;

    [MethodImpl(Inline)]
    public static implicit operator G(k2 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(k2 src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(k2 src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(k2 src)
        => (G)src;
}

public readonly struct k3 : IRegOp64<k3>
{
    public I IndexCode => I.r3;

    [MethodImpl(Inline)]
    public static implicit operator G(k3 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(k3 src)
        => (K)src.IndexCode;
}

public readonly struct k4 : IRegOp64<k4>
{
    public I IndexCode => I.r4;

    [MethodImpl(Inline)]
    public static implicit operator G(k4 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(k4 src)
        => (K)src.IndexCode;
}

public readonly struct k5 : IRegOp64<k5>
{
    public I IndexCode => I.r5;

    [MethodImpl(Inline)]
    public static implicit operator G(k5 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(k5 src)
        => (K)src.IndexCode;
}

public readonly struct k6 : IRegOp64<k6>
{
    public I IndexCode => I.r6;

    [MethodImpl(Inline)]
    public static implicit operator G(k6 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(k6 src)
        => (K)src.IndexCode;
}

public readonly struct k7 : IRegOp64<k7>
{
    public I IndexCode => I.r7;

    [MethodImpl(Inline)]
    public static implicit operator G(k7 src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(k7 src)
        => (K)src.IndexCode;
}
