//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = rDb;
using K = AsmRegTokens.DebugReg;
using O = AsmOperand;
using api = AsmRegs;

public readonly struct rDb : IRegOp64<rDb>
{
    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public rDb(I index)
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
        => reg(src.Size, src.RegClassCode, src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator AsmOperand(G src)
        => src.Untyped();

    [MethodImpl(Inline)]
    public static implicit operator K(G src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator G(K src)
        => new ((I)src);

    [MethodImpl(Inline)]
    public static implicit operator G(I src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator I(G src)
        => src.IndexCode;

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
