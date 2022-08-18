//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines typetable content
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct DbTypeTable : IEntity<DbTypeTable,uint>, IComparable<DbTypeTable>
    {
        public readonly uint Key;

        public readonly Label TypeName;

        public readonly byte PackedWidth;

        public readonly uint NativeWidth;

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

        uint IKeyed<uint>.Key 
            => Key;

        [MethodImpl(Inline)]
        public int CompareTo(DbTypeTable src)
            => TypeName.CompareTo(src.TypeName);
    }
}