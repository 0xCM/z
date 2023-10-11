//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public class RuleGrids
    {
        public readonly Index<RuleGrid> Tables;

        public readonly uint ColCount;

        public RuleGrids(RuleGrid[] src)
        {
            Tables = src;
            ColCount = src.Select(x => x.ColCount).Max();
        }

        public uint TableCount
        {
            [MethodImpl(Inline)]
            get => Tables.Count;
        }

        public ref RuleGrid this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Tables[i];
        }

        public ref RuleGrid this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Tables[i];
        }

        public Index<GridRow> Rows(uint i)
        {
            ref readonly var table = ref Tables[i];
            return XedCells.rows(table.Rule, table.RowCount, table.ColCount, table.Cells);
        }

        public Index<GridRow> Rows(int i)
            => Rows((uint)i);

        public static implicit operator RuleGrids(RuleGrid[] src)
            => new (src);

        public static implicit operator RuleGrids(Index<RuleGrid> src)
            => new (src);
    }
}
