//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public readonly struct RegMask : IRegMask
{
    public readonly RegOp Target;

    public readonly RegIndex Mask;

    public readonly RegMaskKind MaskKind;

    [MethodImpl(Inline)]
    public RegMask(RegOp target, RegIndex mask, RegMaskKind kind)
    {
        Target = target;
        Mask = mask;
        MaskKind = kind;
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => Target.Size;
    }

    public AsmOpKind OpKind
    {
        [MethodImpl(Inline)]
        get => asm.opkind(AsmOpClass.RegMask, Size);
    }

    public AsmOpClass OpClass
        => AsmOpClass.RegMask;

    RegOp IRegMask.Target
        => Target;

    RegIndex IRegMask.Mask
        => Mask;

    RegMaskKind IRegMask.MaskKind
        => MaskKind;

    public string Format()
        => AsmRender.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator AsmOperand(RegMask src)
        => new AsmOperand(src);
}
