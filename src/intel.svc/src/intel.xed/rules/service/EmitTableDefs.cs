//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedRules
    {
        static void EmitRulePage(in TableCriteria src)
        {
            var formatter = Tables.formatter<TableDefRow>();
            using var emitter = XedPaths.Service.RulePage(src.Sig).Path.AsciEmitter();
            emitter.AppendLine(formatter.FormatHeader());
            var k=0u;
            for(var j=0u; j<src.RowCount; j++, k++)
            {
                ref readonly var spec = ref src[j];
                var specFormat = spec.Format();
                var row = TableDefRow.Empty;
                row.Seq = k;
                row.TableId = src.TableId;
                row.Index = j;
                row.Kind = src.TableKind;
                row.Name = src.TableName;
                row.Statement = specFormat;
                emitter.AppendLine(formatter.Format(row));
            }
            emitter.AppendLine();
            emitter.AppendLine();
            src.RenderLines(emitter);
        }

        public void EmitRulePages(RuleTables src)
            => iter(src.Criteria(), table => EmitRulePage(table), PllExec);
    }
}