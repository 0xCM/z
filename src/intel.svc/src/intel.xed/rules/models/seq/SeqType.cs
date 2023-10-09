//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public struct SeqType
    {
        public readonly Nonterminal Kind;

        public readonly SeqEffect Effect;

        [MethodImpl(Inline)]
        public SeqType(Nonterminal kind)
        {
            Kind = kind;
            Effect = 0;
        }

        [MethodImpl(Inline)]
        public SeqType(Nonterminal kind, SeqEffect effect)
        {
            Kind = kind;
            Effect = effect;
        }

        public string Format()
            => $"{Kind.Name}_{Effect}";

        public override string ToString()
            => Format();

        public static SeqType Empty => default;
    }
}

