//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines typetable content
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
    public readonly record struct DbTypeTable : IComparable<DbTypeTable>
    {
        const string TableName = "db.typetables";

        [Render(8)]
        public readonly uint Key;

        [Render(48)]
        public readonly Label TypeName;

        [Render(16)]
        public readonly byte PackedWidth;

        [Render(16)]
        public readonly uint NativeWidth;

        [Render(12)]
        public readonly ushort RowCount;

        public readonly ReadOnlySeq<TypeTableRow> Rows;

        [MethodImpl(Inline)]
        public DbTypeTable(uint key, Label name, DataSize size, TypeTableRow[] rows)
        {
            Key = key;
            TypeName = name;
            NativeWidth = size.NativeWidth;
            PackedWidth = (byte)size.PackedWidth;
            RowCount = (ushort)rows.Length;
            Rows = rows;
        }

        [MethodImpl(Inline)]
        public int CompareTo(DbTypeTable src)
            => TypeName.CompareTo(src.TypeName);
    }
}