//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [DataWidth(7)]
        public readonly record struct InstCategory
        {
            public readonly CategoryKind Kind;

            [MethodImpl(Inline)]
            public InstCategory(CategoryKind src)
            {
                Kind = src;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator InstCategory(CategoryKind src)
                => new InstCategory(src);

            [MethodImpl(Inline)]
            public static implicit operator CategoryKind(InstCategory src)
                => src.Kind;

            public static InstCategory Empty => default;
        }
    }
}