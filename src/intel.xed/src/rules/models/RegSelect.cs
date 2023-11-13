//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;
using static XedModels;

partial class XedRules
{
    public class RegSelect
    {
        public static Dictionary<RuleIdentity, RegSelect> selectors()
        {
            var src = XedTables.RuleCells().Tables();
            var tables = list<CellTable>();
            var selectors = list<RegSelect>();
            foreach(var table in src)
            {
                if(table.Rows.SelectMany(x => x.Consequents().Map(x => x.Field)).Any(x => x == FieldKind.OUTREG))
                {
                    tables.Add(table);
                    selectors.Add(RegSelect.define(table));
                }            
            }
            return selectors.Select(x => (x.Rule,x)).ToDictionary();
        }

        readonly Seq<num8> Predicates;

        readonly Seq<CellValue> Registers;

        readonly CellTable Table;

        public readonly uint ColCount;

        public readonly uint RowCount;

        public readonly ReadOnlySeq<FieldKind> Cols;

        public readonly uint RowWidth;

        public readonly uint TableSize;

        public readonly RuleIdentity Rule;
        
        byte ColumnIndex(FieldKind field)
        {
            var dst = z8;
            for(var i=z8; i<Cols.Count; i++)
            {
                if(Cols[i] == field)
                {
                    dst = i;
                    break;
                }
            }
            return dst;
        }

        public RegExpr Evaluate(in XedFieldState state)
        {
            var dst = RegExpr.Empty;
            var match = bit.Off;            
            var row=0u;
            for(; row<RowCount; row++)
            {                
                match = bit.On;
                for(var j=0u; j<ColCount && match; j++)
                {
                    ref readonly var col = ref Cols[j];
                    var cell = this[row,col];
                    var field = (num8)XedFields.extract(state,col).Data;
                    match = field == cell;
                }
                if(match)
                    break;
            }
            if(match)
            {
                ref readonly var cell = ref Register(row);
                if(cell.IsExpr)
                {
                    var expr = cell.AsCellExpr();
                    if(expr.Value.IsNonterm)
                        dst = new(expr.Value.ToNonterm());
                    else
                        dst = new(expr.Value.ToReg());
                }                
            }

            return dst;
        }

        public ref readonly num8 this[uint row, FieldKind col]
        {
            [MethodImpl(Inline)]
            get => ref Predicates[row*ColCount + ColumnIndex(col)];
        }

        [MethodImpl(Inline)]
        public uint ColWidth(FieldKind col)
            => XedFields.def(col).PackedWidth;

        public ref readonly CellValue Register(uint row)
            => ref Registers[row];
        		
        RegSelect(CellTable src)
        {
            Table = src;
            RowCount = src.RowCount;
            Rule = src.Identity;
            var rows = src.Rows;
            var cols = hashset<FieldKind>();
            foreach(var row in rows)
            foreach(var a in row.Antecedants())
                cols.Add(a.Field);
            Cols = cols.Array();    
            RowWidth = (uint)Cols.Sum(x => XedFields.def(x).Size.PackedWidth);
            ColCount = (uint)cols.Count;
            TableSize = ColCount*RowWidth;
            Predicates = new num8[RowCount*ColCount];
            Registers = alloc<CellValue>(RowCount);
            var k=0u;
            for(var i=0u; i<RowCount; i++)
            {
                ref readonly var row = ref rows[i];
                var antecentants = row.Antecedants();
                for(var j=0; j<antecentants.Length; j++)
                {
                    ref readonly var antecedant = ref skip(antecentants,j);
                    ref readonly var cellval = ref antecedant.Value;
                    if(cellval.IsExpr)
                    {
                        var expr = cellval.AsCellExpr();
                        if(expr.Operator == RuleOperator.Eq)
                        {
                            var colidx = ColumnIndex(antecedant.Field);
                            ref readonly var fval = ref expr.Value;
                            Predicates[i*ColCount + colidx] = fval.ToByte();
                        }
                    }
                }

                var consequents = row.Consequents();
                for(var j=0; j<consequents.Length; j++)
                {
                    ref readonly var consequent = ref skip(consequents,j);
                    if(consequent.Field == FieldKind.OUTREG)
                    {
                        Registers[i] = consequent.Value;
                        break;
                    }
                }
            }

        }
        
        public static RegSelect define(CellTable src)        
            => new(src);
    }
}