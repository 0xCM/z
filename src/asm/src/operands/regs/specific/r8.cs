//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = r8;
using K = AsmRegTokens.Gp8Reg;
using O = AsmOperand;
using api = AsmRegs;
using C = RegClassCode;

public readonly struct r8 : IRegOp8<G>
{
    internal const NativeSizeCode W = NativeSizeCode.W8;

    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public r8(I index)
    {
        IndexCode = index;
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => W;
    }

    public C RegClassCode
    {
        [MethodImpl(Inline)]
        get => C.GP;
    }

    public RegClass RegClass
    {
        [MethodImpl(Inline)]
        get => RegClassCode;
    }

    public AsmOpKind OpKind
    {
        [MethodImpl(Inline)]
        get => asm.opkind(AsmOpClass.Reg, Size);
    }

    [MethodImpl(Inline)]
    public AsmOperand Untyped()
        => new AsmOperand(this);

    public string Format()
        => ((K)IndexCode).ToString();

    public override string ToString()
        => Format();

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
    public static implicit operator I(G src)
        => src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator G(I src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator G(K src)
        => new ((I)src);

    [MethodImpl(Inline)]
    public static explicit operator byte(G src)
        => (byte)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator G(Sym<K> src)
        => new ((I)src.Kind);

    [MethodImpl(Inline)]
    public static implicit operator G(RegKind src)
        => new (index(src));

    [MethodImpl(Inline)]
    public static G operator ++(G src)
        => api.next(src);

    [MethodImpl(Inline)]
    public static G operator --(G src)
        => api.prior(src);
}
