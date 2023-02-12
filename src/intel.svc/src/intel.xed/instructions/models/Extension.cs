//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [DataWidth(8)]
        public readonly record struct Extension
        {
            public readonly ExtensionKind Kind;

            [MethodImpl(Inline)]
            public Extension(ExtensionKind src)
            {
                Kind = src;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Extension(ExtensionKind src)
                => new Extension(src);

            [MethodImpl(Inline)]
            public static implicit operator ExtensionKind(Extension src)
                => src.Kind;

            public static Extension Empty => default;
        }
    }
}