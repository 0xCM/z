//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RowExpr
        {
            public readonly Index<RuleCell> Cells;

            public RowExpr(Index<RuleCell> src)
            {
                Cells = Require.notnull(src);
            }

            public string Format()
            {
                var dst = text.emitter();
                CellRender.render(this, dst);
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}