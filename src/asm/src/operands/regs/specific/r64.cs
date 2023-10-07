//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = r64;
using K = AsmRegTokens.Gp64Reg;
using O = AsmOperand;
using api = AsmRegs;

public readonly struct r64 : IRegOp64<G>
{
    public I IndexCode {get;}

    [MethodImpl(Inline)]
    public r64(I index)
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

public readonly struct rax : IRegOp64<rax>
{
    public I IndexCode => I.r0;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(rax src)
        => src.Generalized;

    [MethodImpl(Inline)]
    public static implicit operator K(rax src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(rax src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(rax src)
        => (G)src;
}

public struct rcx : IRegOp64<rcx>
{
    public I IndexCode => I.r1;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new (IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(rcx src)
        => new (src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(rcx src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(rcx src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(rcx src)
        => (G)src;
}

public struct rdx : IRegOp64<rdx>
{
    public I IndexCode => I.r2;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(rdx src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(rdx src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(rdx src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(rdx src)
        => (G)src;
}

public struct rbx : IRegOp64<rbx>
{
    public I IndexCode => I.r3;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(rbx src)
        => new(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(rbx src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(rbx src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(rbx src)
        => (G)src;

}

public struct rsi : IRegOp64<rsi>
{
    public I IndexCode => I.r4;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(rsi src)
        => new(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(rsi src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(rsi src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(rsi src)
        => (G)src;
}

public struct rdi : IRegOp64<rdi>
{
    public I IndexCode => I.r5;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(rdi src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(rdi src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(rdi src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(rdi src)
        => (G)src;
}

public struct rsp : IRegOp64<rsp>
{
    public I IndexCode => I.r6;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(rsp src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(rsp src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(rsp src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(rsp src)
        => (G)src;
}

public struct rbp : IRegOp64<rbp>
{
    public I IndexCode => I.r7;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(rbp src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(rbp src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(rbp src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(rbp src)
        => (G)src;
}

public struct r8q : IRegOp64<r8q>
{
    public I IndexCode => I.r8;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(r8q src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(r8q src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(r8q src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(r8q src)
        => (G)src;
}

public struct r9q : IRegOp64<r9q>
{
    public I IndexCode => I.r9;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(r9q src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(r9q src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(r9q src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(r9q src)
        => (G)src;
}

public struct r10q : IRegOp64<r10q>
{
    public I IndexCode => I.r10;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(r10q src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(r10q src)
        => (K)src.IndexCode;

    [MethodImpl(Inline)]
    public static implicit operator O(r10q src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(r10q src)
        => (G)src;
}

public struct r11q : IRegOp64<r11q>
{
    public I IndexCode => I.r11;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(r11q src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(r11q src)
        => (K)src.IndexCode;
}

public struct r12q : IRegOp64<r12q>
{
    public I IndexCode => I.r12;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(r12q src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(r12q src)
        => (K)src.IndexCode;
}

public struct r13q : IRegOp64<r13q>
{
    public I IndexCode => I.r13;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(r13q src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(r13q src)
        => (K)src.IndexCode;
}

public struct r14q : IRegOp64<r14q>
{
    public I IndexCode => I.r14;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(r14q src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(r14q src)
        => (K)src.IndexCode;

}

public struct r15q : IRegOp64<r15q>
{
    public I IndexCode => I.r15;

    public G Generalized
    {
        [MethodImpl(Inline)]
        get => new G(IndexCode);
    }

    [MethodImpl(Inline)]
    public static implicit operator G(r15q src)
        => new G(src.IndexCode);

    [MethodImpl(Inline)]
    public static implicit operator K(r15q src)
        => (K)src.IndexCode;
}
