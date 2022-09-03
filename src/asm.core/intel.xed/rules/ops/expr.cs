//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static CellExpr expr(OperatorKind op, FieldValue value)
            => new (op,value);

        [MethodImpl(Inline), Op]
        public static RowExpr expr(Index<RuleCell> src)
            => new RowExpr(src);
    }
}