//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;

partial class XedCells
{
    public static TableSpecs tables(ReadOnlySeq<TableCriteria> src)
    {
        var dst = dict<RuleIdentity,TableSpec>();
        var specs = alloc<TableSpec>(src.Count);
        var seq = z16;
        for(var i=z16; i<src.Count; i++)
        {
            ref readonly var table = ref src[i];
            var tix = i;
            var tk = table.TableKind;
            ref readonly var sig = ref table.Rule;            
            var rows = alloc<RowSpec>(table.RowCount);
            for(ushort j=0; j<table.RowCount; j++)
            {
                var rix = j;
                ref readonly var row = ref table[j];
                var left = row.Antecedant.Select(x => cellinfo(x.TypeInfo, LogicKind.Antecedant, x.Data));
                var right = row.Consequent.Select(x => cellinfo(x.TypeInfo, LogicKind.Consequent, x.Data));
                var count = left.Count + 1 + right.Count;
                var keys = alloc<CellKey>(count);
                var cells = alloc<CellInfo>(count);
                var m=z8;
                var kw = RuleKeyword.Empty;
                for(var k=0; k<left.Count; k++,m++)
                {
                    ref readonly var ci = ref left[k];
                    if(ci.IsKeyword)
                        XedParsers.parse(ci.Data, out kw);
                    seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Antecedant, left[k].Kind, tk, sig.TableName, left[k].Field, kw.KeywordKind);
                    seek(cells, m) = ci;
                }

                {
                    seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Operator, RuleCellKind.Operator, tk, sig.TableName, FieldKind.INVALID, KeywordKind.None);
                    seek(cells, m) = cellinfo(OperatorKind.Impl);
                    m++;
                }

                for(var k=0; k<right.Count; k++,m++)
                {
                    ref readonly var ci = ref right[k];
                    if(ci.IsKeyword)
                        XedParsers.parse(ci.Data, out kw);
                    seek(keys,m) = new CellKey(seq++, tix, rix, m, LogicKind.Consequent, right[k].Kind, tk, sig.TableName, right[k].Field, kw.KeywordKind);
                    seek(cells, m) = ci;
                }
                seek(rows,j) = new RowSpec(sig, tix, rix, keys, cells);
            }

            var spec = new TableSpec(tix, sig, rows);
            seek(specs,i) = spec;
            dst.Add(sig, spec);
        }
        return specs.Select(x => (x.Identity,x)).ToDictionary();
    }
}