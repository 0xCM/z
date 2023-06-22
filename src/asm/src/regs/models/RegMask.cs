//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct RegMask : IRegMask
    {
        public static string format(in RegMask src)
        {
            var dst = EmptyString;
            if(src.MaskKind == RegMaskKind.k1)
                dst = string.Format("{0} {{1}}", src.Target, AsmRegs.rK(src.Mask));
            else if(src.MaskKind == RegMaskKind.k1z)
                dst = string.Format("{0} {{{1}}{{2}}", src.Target, AsmRegs.rK(src.Mask), Chars.z);
            return dst;
        }

        public RegOp Target {get;}

        public RegIndex Mask {get;}

        public RegMaskKind MaskKind {get;}

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
            get => AsmOps.kind(AsmOpClass.RegMask, Size);
        }

        public AsmOpClass OpClass
            => AsmOpClass.RegMask;
        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(RegMask src)
            => new AsmOperand(src);
    }
}