//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public class XedRuleKindAttribute : Attribute
    {
        public XedRuleKindAttribute(RuleKind kind)
        {
            Kind = kind;
        }

        public RuleKind Kind {get;}
    }
}