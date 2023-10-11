//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public readonly struct CellRow : IComparable<CellRow>
    {
        public readonly RuleIdentity TableSig;

        public readonly ushort TableIndex;

        public readonly ushort RowIndex;

        public readonly uint CellCount;

        public readonly Index<RuleCell> Cells;

        public readonly RowExpr Expression;

        [MethodImpl(Inline)]
        public CellRow(RuleIdentity sig, ushort table, ushort row, RuleCell[] src)
        {
            TableIndex = table;
            RowIndex = row;
            TableSig = sig;
            Cells = Require.notnull(src);
            CellCount = (uint)src.Length;
            Expression = Xed.expr(src);
        }

        byte AntecedantCount
        {
            [MethodImpl(Inline)]
            get
            {
                var result = z8;
                for(var i=0; i<Cells.Count; i++)
                {
                    if(Cells[i].Logic != LogicKind.Antecedant)
                        break;
                    result++;
                }
                return result;
            }
        }

        byte ConsequentOffset
        {
            [MethodImpl(Inline)]
            get
            {
                var result = z8;
                for(var i=z8; i<Cells.Count; i++)
                {
                    if(Cells[i].Logic != LogicKind.Consequent)
                        continue;

                    result = i;
                    break;
                }

                return result;
            }
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<RuleCell> Antecedants()
            => sys.slice(Cells.View,0,AntecedantCount);

        [MethodImpl(Inline)]
        public ReadOnlySpan<RuleCell> Consequents()
            => sys.slice(Cells.View,ConsequentOffset);

        public bool HasConsequent
        {
            [MethodImpl(Inline)]
            get => Cells.IsNonEmpty && Cells.Last.IsOperator;
        }

        public readonly uint Count
        {
            [MethodImpl(Inline)]
            get => Cells.Count;
        }

        public ref RuleCell this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Cells[i];
        }

        public ref RuleCell this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Cells[i];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Cells.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Cells.IsNonEmpty;
        }

        public string Format()
            => CellRender.Tables.format(this);

        public override string ToString()
            => Format();

        public int CompareTo(CellRow src)
        {
            var result = TableSig.CompareTo(src.TableSig);
            if(result == 0)
                result = TableIndex.CompareTo(src.TableIndex);
            if(result == 0)
                result = RowIndex.CompareTo(src.RowIndex);
            return result;
        }

        public static CellRow Empty => new CellRow(RuleIdentity.Empty, 0, 0, sys.empty<RuleCell>());
    }
}
