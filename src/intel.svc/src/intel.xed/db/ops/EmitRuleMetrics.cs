//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDb
    {
        public void EmitRuleMetrics(CellTables src)
        {
            var dst = text.emitter();
            for(var i=0; i<src.TableCount; i++)
                dst.AppendLine(CalcTableMetrics(src[i]));
            FileEmit(dst.Emit(), src.TableCount, Paths.DbTarget("rules.metrics", FileKind.Txt));
        }

        string CalcTableMetrics(in CellTable table)
        {
            var dst = text.emitter();
            dst.AppendLine(string.Format("{0,-32} {1}", table.Sig, Paths.CheckedRulePage(table.Sig)));
            dst.AppendLine(RP.PageBreak120);
            dst.AppendLine();
            for(var i=0; i<table.RowCount; i++)
            {
                ref readonly var row = ref table[i];

                if(i != 0)
                    dst.AppendLine();

                var size = DataSize.Empty;
                dst.AppendLine(RP.PageBreak120);
                for(var j=0; j<row.CellCount; j++)
                {
                    ref readonly var cell = ref row[j];
                    ref readonly var key = ref cell.Key;
                    dst.AppendLineFormat("{0} | {1} | {2,-26} | {3}", key, cell.Size.Format(2,2), XedRender.format(cell.Field), cell);
                }

                dst.AppendLine(RP.PageBreak120);
                dst.AppendLine(row.Expression);
            }

            dst.AppendLine();
            dst.AppendLine(RP.PageBreak120);

            return dst.Emit();
        }
    }
}