//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {     
        public void EmitTableSpecs(XedRuleTables src)
        {
            var formatter = CsvTables.formatter<TableDefRow>();
            ref readonly var specs = ref src.Specs();
            ref readonly var criteria = ref src.Criteria();
            using var emitter = XedPaths.RuleSpecs().AsciEmitter();
            emitter.AppendLine(formatter.FormatHeader());
            var k=0u;
            var count = Require.equal(specs.TableCount,criteria.Count);
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref specs[i];
                ref readonly var table = ref criteria[i];
                if(spec.IsNonEmpty)
                {
                    emitter.AppendLine();
                    var kRows = Require.equal(table.RowCount, spec.RowCount);
                    for(var j=0u; j<kRows; j++, k++)
                    {
                        ref readonly var row = ref spec[j];
                        var dst = TableDefRow.Empty;
                        dst.Seq = k;
                        dst.TableId = spec.TableId;
                        dst.Index = j;
                        dst.Kind = spec.TableKind;
                        dst.Name = spec.Name;
                        dst.Statement = row.Format();
                        emitter.AppendLine(formatter.Format(dst));
                    }

                    emitter.AppendLine();
                    emitter.AppendLine();
                    table.RenderLines(emitter);
                }
            }
        }
    }
}