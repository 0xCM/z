//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes an extant table
    /// </summary>
    public class ClrTable : IComparable<ClrTable>
    {
        [Render(24)]
        public readonly Type Type;

        [Render(24)]
        public readonly TableId Id;

        public readonly ClrTableCols Cells;

        public readonly LayoutKind? Layout;

        public readonly CharSet? CharSet;

        public readonly byte? Pack;

        public readonly uint? Size;

        [MethodImpl(Inline)]
        public ClrTable(Type type, TableId id, ClrTableCol[] fields, LayoutKind? layout, CharSet? charset, byte? pack, uint? size)
        {

            Type = type;
            Id = id;
            Cells = fields;
            Layout = layout;
            CharSet = charset;
            Pack = pack;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Id.IsEmpty || Cells.IsEmpty;
        }

        public int CompareTo(ClrTable src)
            => Type.DisplayName().CompareTo(src.Type.DisplayName());

    }
}