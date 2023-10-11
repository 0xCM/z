//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
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
