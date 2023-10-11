//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public enum RuleCellKind : byte
    {
        Void = 0,

        BitVal,

        IntVal,

        HexVal,

        BitLit,

        HexLit,

        SegVar,

        FieldSeg,

        Keyword,

        NtCall,

        Operator,

        InstSeg,

        NeqExpr,

        EqExpr,

        NtExpr,

        WidthVar,
    }
}
