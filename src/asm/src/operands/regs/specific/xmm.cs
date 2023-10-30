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
