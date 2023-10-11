//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    public readonly struct RowSpec : IComparable<RowSpec>
    {
        public readonly ushort TableId;

        public readonly RuleIdentity Sig;

        public readonly ushort RowIndex;

        public readonly Index<CellKey> Keys;

        public readonly Index<CellInfo> CellInfo;

        public readonly ushort ColCount;

        [MethodImpl(Inline)]
        public RowSpec(RuleIdentity sig, ushort tid, ushort rix, CellKey[] keys, CellInfo[] cells)
        {
            Sig = sig;
            TableId = tid;
            RowIndex = rix;
            Keys = keys;
            CellInfo = cells;
            ColCount = (ushort)Require.equal(keys.Length, cells.Length);
        }

        [MethodImpl(Inline)]
        public ref readonly CellInfo Cell(ushort i)
            => ref CellInfo[i];

        [MethodImpl(Inline)]
        public ref readonly CellKey Key(ushort i)
            => ref Keys[i];

        public string Format()
            => CellRender.expression(this);

        public override string ToString()
            => Format();

        public int CompareTo(RowSpec src)
            => Sig.CompareTo(src.Sig);
    }
}
