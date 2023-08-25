//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm.Operands;

using static AsmRegBits;

using I = RegIndexCode;
using G = r8;
using K = AsmRegTokens.Gp8LoReg;
using O = AsmOperand;
using api = AsmRegs;
using C = RegClassCode;

public readonly struct r8 : IRegOp8<G>
{
    internal const NativeSizeCode W = NativeSizeCode.W8;

    public I Index {get;}

    [MethodImpl(Inline)]
    public r8(I index)
    {
        Index = index;
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
        => ((K)Index).ToString();

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator RegOp(G src)
        => reg(src.Size, src.RegClassCode, src.Index);

    [MethodImpl(Inline)]
    public static implicit operator AsmOperand(G src)
        => src.Untyped();

    [MethodImpl(Inline)]
    public static implicit operator K(G src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator I(G src)
        => src.Index;

    [MethodImpl(Inline)]
    public static implicit operator G(I src)
        => new G(src);

    [MethodImpl(Inline)]
    public static implicit operator G(K src)
        => new G((I)src);

    [MethodImpl(Inline)]
    public static explicit operator byte(G src)
        => (byte)src.Index;

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

public readonly struct al : IRegOp8<al>
{
    public I Index => I.r0;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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

    public static implicit operator r8(al src)
        => new r8(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(al src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(al src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(al src)
        => (G)src;

}

public struct cl : IRegOp8<cl>
{
    public I Index => I.r1;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(cl src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(cl src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(cl src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(cl src)
        => (G)src;

}

public struct dl : IRegOp8<dl>
{
    public I Index => I.r2;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(dl src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(dl src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(dl src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(dl src)
        => (G)src;
}

public struct bl : IRegOp8<bl>
{
    public I Index => I.r3;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(bl src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(bl src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(bl src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(bl src)
        => (G)src;
}

public struct sil : IRegOp8<sil>
{
    public I Index => I.r4;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(sil src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(sil src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(sil src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(sil src)
        => (G)src;
}

public struct dil : IRegOp8<dil>
{
    public I Index => I.r5;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(dil src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(dil src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(dil src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(dil src)
        => (G)src;
}

public struct spl : IRegOp8<spl>
{
    public I Index => I.r6;


    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(spl src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(spl src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(spl src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(spl src)
        => (G)src;
}

public struct bpl : IRegOp8<bpl>
{
    public I Index => I.r7;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(bpl src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(bpl src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(bpl src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(bpl src)
        => (G)src;
}

public struct r8b : IRegOp8<r8b>
{
    public I Index => I.r8;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(r8b src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(r8b src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(r8b src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(r8b src)
        => (G)src;
}

public struct r9b : IRegOp8<r9b>
{
    public I Index => I.r9;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(r9b src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(r9b src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(r9b src)
        => (G)src;

    [MethodImpl(Inline)]
    public static implicit operator RegOp(r9b src)
        => (G)src;
}

public struct r10b : IRegOp8<r10b>
{
    public I Index => I.r10;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(r10b src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(r10b src)
        => (K)src.Index;
}

public struct r11b : IRegOp8<r11b>
{
    public I Index => I.r11;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(r11b src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(r11b src)
        => (K)src.Index;
}

public struct r12b : IRegOp8<r12b>
{
    public I Index => I.r12;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(r12b src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(r12b src)
        => (K)src.Index;
}

public struct r13b : IRegOp8<r13b>
{
    public I Index => I.r13;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(r13b src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(r13b src)
        => (K)src.Index;
}

public struct r14b : IRegOp8<r14b>
{
    public I Index => I.r14;


    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(r14b src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(r14b src)
        => (K)src.Index;
}

public struct r15b : IRegOp8<r15b>
{
    public I Index => I.r15;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
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
    public static implicit operator G(r15b src)
        => new G(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(r15b src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator I(r15b src)
        => src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(r15b src)
        => (G)src;
}

public readonly struct ah : IRegOp8<ah>
{
    public I Index => I.r4;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => G.W;
    }

    public RegClass RegClass
    {
        [MethodImpl(Inline)]
        get => C.GP8HI;
    }

    public string Format()
        => Name.Format();

    public override string ToString()
        => Format();

    public static implicit operator r8(ah src)
        => new r8(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(ah src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator I(ah src)
        => src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(ah src)
        => (G)src;
}

public readonly struct ch : IRegOp8<ch>
{
    public I Index => I.r5;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => G.W;
    }

    public RegClass RegClass
    {
        [MethodImpl(Inline)]
        get => C.GP8HI;
    }

    public string Format()
        => Name.Format();

    public override string ToString()
        => Format();

    public static implicit operator r8(ch src)
        => new r8(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(ch src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator I(ch src)
        => src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(ch src)
        => (G)src;

}

public readonly struct dh : IRegOp8<dh>
{
    public I Index => I.r6;


    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => G.W;
    }

    public RegClass RegClass
    {
        [MethodImpl(Inline)]
        get => C.GP8HI;
    }

    public string Format()
        => Name.Format();

    public override string ToString()
        => Format();

    public static implicit operator r8(dh src)
        => new r8(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(dh src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator I(dh src)
        => src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(dh src)
        => (G)src;
}

public readonly struct bh : IRegOp8<bh>
{
    public I Index => I.r7;

    public AsmRegName Name
    {
        [MethodImpl(Inline)]
        get => api.name(Size, RegClass, Index);
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => G.W;
    }

    public RegClass RegClass
    {
        [MethodImpl(Inline)]
        get => C.GP8HI;
    }

    public string Format()
        => Name.Format();

    public override string ToString()
        => Format();

    public static implicit operator r8(bh src)
        => new r8(src.Index);

    [MethodImpl(Inline)]
    public static implicit operator K(bh src)
        => (K)src.Index;

    [MethodImpl(Inline)]
    public static implicit operator I(bh src)
        => src.Index;

    [MethodImpl(Inline)]
    public static implicit operator O(bh src)
        => (G)src;
}
