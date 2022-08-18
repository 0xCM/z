//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct GridRow
        {
            public readonly RuleSig Rule;

            public readonly ushort Row;

            public readonly Index<GridCol> Cols;

            [MethodImpl(Inline)]
            public GridRow(RuleSig rule, ushort row, GridCol[] cols)
            {
                Rule = rule;
                Row = row;
                Cols = cols;
            }

            public byte ColCount
            {
                [MethodImpl(Inline)]
                get => (byte)Cols.Count;
            }

            public ref GridCol this[byte i]
            {
                [MethodImpl(Inline)]
                get => ref Cols[i];
            }

            public uint PackedWidth()
                => Cols.Storage.Where(c => c.Field != 0).Select(x => x.Size.PackedWidth).Sum();

            public uint AlignedWidth()
                => Cols.Storage.Where(c => c.Field != 0).Select(x => x.Size.NativeWidth).Sum();

            public DataSize Size()
                => new DataSize(PackedWidth(), AlignedWidth());
        }
    }
}