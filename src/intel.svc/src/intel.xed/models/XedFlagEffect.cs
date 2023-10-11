//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedModels
{
    public readonly struct XedFlagEffect
    {
        public readonly XedRegFlag Flag;

        public readonly FlagEffectKind Effect;

        [MethodImpl(Inline)]
        public XedFlagEffect(XedRegFlag f, FlagEffectKind k)
        {
            Flag = f;
            Effect = k;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Flag == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Flag != 0;
        }

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator XedFlagEffect((XedRegFlag f, FlagEffectKind k) src)
            => new XedFlagEffect(src.f, src.k);

        [MethodImpl(Inline)]
        public static implicit operator FlagEffect(XedFlagEffect src)
        {
            Xed.convert(src, out FlagEffect dst);
            return dst;
        }
    }
}
