
//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Op]
        public static Index<RuleSig> sigs(params (RuleTableKind kind, RuleName rule)[] src)
            => src.Select(x => new RuleSig(x.kind,x.rule));
    }
}