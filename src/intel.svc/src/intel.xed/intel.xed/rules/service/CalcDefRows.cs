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
        public Index<TableDefRow> CalcDefRows(RuleTables src)
        {
            return Data(nameof(CalcDefRows), Calc);

            Index<TableDefRow> Calc()
            {
                var buffer = list<TableDefRow>();
                ref readonly var specs = ref src.Specs();
                var k=0u;
                for(var i=0u; i<specs.TableCount; i++)
                {
                    ref readonly var spec = ref specs[i];
                    for(var j=0u; j<spec.RowCount; j++, k++)
                    {
                        ref readonly var row = ref spec[j];
                        var dst = TableDefRow.Empty;
                        dst.Seq = k;
                        dst.TableId = spec.TableId;
                        dst.Index = j;
                        dst.Kind = spec.TableKind;
                        dst.Name = spec.Name;
                        dst.Statement = row.Format();
                        buffer.Add(dst);
                    }
                }
                return buffer.ToArray();
            }
        }
    }
}