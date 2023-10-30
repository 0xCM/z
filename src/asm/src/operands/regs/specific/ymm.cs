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
