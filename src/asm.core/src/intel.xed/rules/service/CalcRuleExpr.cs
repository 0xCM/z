//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<RuleExpr> CalcRuleExpr(CellTables src)
        {
            return Data(nameof(CalcRuleExpr),Calc);

            Index<RuleExpr> Calc()
            {
                var dst = core.alloc<RuleExpr>(src.RowCount);
                var k=z16;
                for(var i=0; i<src.TableCount; i++)
                {
                    ref readonly var table = ref src[i];
                    for(var j=0; j<table.RowCount; j++, k++)
                    {
                        ref readonly var row = ref table[j];
                        seek(dst,k) = new RuleExpr(k, table.Sig, (byte)row.RowIndex, String(row.Expression.Format()));
                    }
                }

                return dst;
            }
        }
    }
}