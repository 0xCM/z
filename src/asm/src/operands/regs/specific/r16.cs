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

public readonly struct ax : IRegOp16<ax>
{
    public I IndexCode => I.r0;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, IndexCode);
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => G.W;
    }

    public RegClass RegClass
    {
        [MethodImpl(Inline)]
        get => C.GP;
    }

    public string Format()
        => Name.Format();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator G(ax src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(ax src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(ax src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(ax src)
        => (G)src;

}

public struct cx : IRegOp16<cx>
{
    public I IndexCode => I.r1;

    [MethodImpl(Inline)]
    public static implicit operator G(cx src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(cx src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(cx src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(cx src)
        => (G)src;
}

public struct dx : IRegOp16<dx>
{
    public I IndexCode => I.r2;

    [MethodImpl(Inline)]
    public static implicit operator G(dx src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(dx src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(dx src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(dx src)
        => (G)src;
}

public struct bx : IRegOp16<bx>
{
    public I IndexCode => I.r3;

    [MethodImpl(Inline)]
    public static implicit operator G(bx src)
        => new(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(bx src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(bx src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(bx src)
        => (G)src;
}

public struct si : IRegOp16<si>
{
    public I IndexCode => I.r4;

    [MethodImpl(Inline)]
    public static implicit operator G(si src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(si src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(si src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(si src)
        => (G)src;
}

public struct di : IRegOp16<di>
{
    public I IndexCode => I.r5;

    [MethodImpl(Inline)]
    public static implicit operator G(di src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(di src)
        => (K)src.IndexCode;
}

public struct sp : IRegOp16<sp>
{
    public I IndexCode => I.r6;

    [MethodImpl(Inline)]
    public static implicit operator G(sp src)
        => new(src.IndexCode);
}

public struct bp : IRegOp16<bp>
{
    public I IndexCode => I.r7;

    [MethodImpl(Inline)]
    public static implicit operator G(bp src)
        => new(src.IndexCode);
}

public struct r8w : IRegOp16<r8w>
{
    public I IndexCode => I.r8;

    [MethodImpl(Inline)]
    public static implicit operator G(r8w src)
        => new(src.IndexCode);
}

public struct r9w : IRegOp16<r9w>
{
    public I IndexCode => I.r9;

    [MethodImpl(Inline)]
    public static implicit operator G(r9w src)
        => new(src.IndexCode);
}

public struct r10w : IRegOp16<r10w>
{
    public I IndexCode => I.r10;

    [MethodImpl(Inline)]
    public static implicit operator G(r10w src)
        => new(src.IndexCode);
}

public struct r11w : IRegOp16<r11w>
{
    public I IndexCode => I.r11;

    [MethodImpl(Inline)]
    public static implicit operator G(r11w src)
        => new(src.IndexCode);
}

public struct r12w : IRegOp16<r12w>
{
    public I IndexCode => I.r12;

    [MethodImpl(Inline)]
    public static implicit operator G(r12w src)
        => new (src.IndexCode);
}

public struct r13w : IRegOp16<r13w>
{
    public I IndexCode => I.r13;

    [MethodImpl(Inline)]
    public static implicit operator G(r13w src)
        => new (src.IndexCode);
}

public struct r14w : IRegOp16<r14w>
{
    public I IndexCode => I.r14;

    [MethodImpl(Inline)]
    public static implicit operator G(r14w src)
        => new (src.IndexCode);
}

public struct r15w : IRegOp16<r15w>
{
    public I IndexCode => I.r15;

    [MethodImpl(Inline)]
    public static implicit operator G(r15w src)
        => new (src.IndexCode);
}

