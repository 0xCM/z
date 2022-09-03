//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes an extant table
    /// </summary>
    public class ReflectedTable : IComparable<ReflectedTable>
    {
        [Render(24)]
        public readonly Type Type;

        [Render(24)]
        public readonly TableId Id;

        public readonly Index<ClrTableField> Fields;

        public readonly LayoutKind? Layout;

        public readonly CharSet? CharSet;

        public readonly byte? Pack;

        public readonly uint? Size;

        [MethodImpl(Inline)]
        public ReflectedTable(Type type, TableId id, ClrTableField[] fields, LayoutKind? layout, CharSet? charset, byte? pack, uint? size)
        {

            Type = type;
            Id = id;
            Fields = fields;
            Layout = layout;
            CharSet = charset;
            Pack = pack;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Id.IsEmpty || Fields.IsEmpty;
        }

        public int CompareTo(ReflectedTable src)
            => Type.DisplayName().CompareTo(src.Type.DisplayName());

    }
}