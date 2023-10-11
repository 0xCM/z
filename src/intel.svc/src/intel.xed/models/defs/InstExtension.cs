//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [DataWidth(8)]
    public readonly record struct InstExtension
    {
        public readonly ExtensionKind Kind;

        [MethodImpl(Inline)]
        public InstExtension(ExtensionKind src)
        {
            Kind = src;
        }

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator InstExtension(ExtensionKind src)
            => new InstExtension(src);

        [MethodImpl(Inline)]
        public static implicit operator ExtensionKind(InstExtension src)
            => src.Kind;

        public static InstExtension Empty => default;
    }
}
