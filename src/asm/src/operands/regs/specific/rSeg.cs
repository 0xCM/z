//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = rSeg;
using K = AsmRegTokens.SegReg;
using O = AsmOperand;
using C = RegClassCode;

public readonly struct rSeg: IRegOp64<G>
{
    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public rSeg(I index)
    {
        IndexCode = index;
    }

    [MethodImpl(Inline)]
    public O Untyped()
        => new O(this);

    public string Format()
        => ((K)IndexCode).ToString();

    public override string ToString()
        => Format();

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => NativeSizeCode.W64;
    }

    public C RegClassCode
    {
        [MethodImpl(Inline)]
        get => C.DB;
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
    public static implicit operator O(G src)
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
        => new ((I)src.Kind);

    [MethodImpl(Inline)]
    public static implicit operator G(RegKind src)
        => new (index(src));
}
