//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [DataWidth(8)]
    public readonly struct RuleMacro
    {
        public readonly RuleMacroKind Kind;

        [MethodImpl(Inline)]
        public RuleMacro(RuleMacroKind kind)
        {
            Kind = kind;
        }

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator RuleMacro(RuleMacroKind src)
            => new RuleMacro(src);

        [MethodImpl(Inline)]
        public static implicit operator RuleMacroKind(RuleMacro src)
            => src.Kind;

        public static RuleMacro Emtpy => new RuleMacro(0);
    }
}
