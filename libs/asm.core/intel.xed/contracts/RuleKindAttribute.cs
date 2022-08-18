//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class RuleKindAttribute : Attribute
        {
            public RuleKindAttribute(RuleKind kind)
            {
                Kind = kind;
            }

            public RuleKind Kind {get;}
        }
    }
}