//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        public readonly struct OpModifier
        {
            public readonly OpModKind Kind;

            [MethodImpl(Inline)]
            public OpModifier(OpModKind kind)
            {
                Kind = kind;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OpModKind(OpModifier src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static implicit operator OpModifier(OpModKind src)
                => new OpModifier(src);
        }
    }
}