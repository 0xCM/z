//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public enum ColKind : byte
    {
        None = 0,

        Keyword,

        Field,

        FieldSeg,

        Rule,

        Operator,

        BitLiteral,

        HexLiteral,

        Expr,

        SegVal,

        SegVar,

        RuleExpr
    }
}
