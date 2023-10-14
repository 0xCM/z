//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    public readonly struct CellTable : IComparable<CellTable>
    {
        public readonly RuleIdentity Sig;

        public readonly ushort TableIndex;

        public readonly Index<CellRow> Rows;

        public readonly uint CellCount;

        public readonly uint RowCount;

        [MethodImpl(Inline)]
        public CellTable(RuleIdentity sig, ushort index, CellRow[] src)
        {
            Sig = sig;
            TableIndex = index;
            Rows = Require.notnull(src);
            RowCount = (ushort)src.Length;
            CellCount = src.Select(x => (uint)x.CellCount).Sum();
        }

        public RuleTableKind Kind
        {
            [MethodImpl(Inline)]
            get => Sig.TableKind;
        }

        public RuleName Name
        {
            [MethodImpl(Inline)]
            get => Sig.TableName;
        }

        public ref CellRow this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public ref CellRow this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Rows[i];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Rows.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Rows.IsNonEmpty;
        }

        public string Format()
            => XedCellRender.Tables.format(this);

        public override string ToString()
            => Format();

        public int CompareTo(CellTable src)
        {
            var result = Sig.CompareTo(src.Sig);
            if(result == 0)
                result = TableIndex.CompareTo(src.TableIndex);
            return result;
        }

        public static CellTable Empty => new CellTable(RuleIdentity.Empty, 0, sys.empty<CellRow>());
    }
}
