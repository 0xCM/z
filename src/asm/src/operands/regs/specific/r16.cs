//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

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

    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public r16(I index)
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
        get => asm.opkind(AsmOpClass.Reg, Size);
    }

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
