//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public readonly struct AsmOpMask
    {
        public readonly RegMaskKind MaskKind;

        public readonly RegOp Source;

        public readonly RegOp Target;

        [MethodImpl(Inline)]
        public AsmOpMask(RegMaskKind kind, RegOp src, RegOp dst)
        {
            MaskKind = kind;
            Source = src;
            Target = dst;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => MaskKind == 0 && Source.IsEmpty && Target.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }
    }
}