//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleSeqTerm
        {
            public readonly Identifier Name;

            public readonly bool IsCall;

            [MethodImpl(Inline)]
            public RuleSeqTerm(Identifier name, bool call)
            {
                Name = name;
                IsCall = call;
            }

            public string Format()
                => IsCall ? string.Format("{0}()", Name) : Name;

            public override string ToString()
                => Format();
        }
    }
}