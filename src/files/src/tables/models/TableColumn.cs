//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TableColumn
    {
        public readonly string Name;

        public readonly string Type;

        public readonly ushort ColWidth;

        [MethodImpl(Inline)]
        public TableColumn(string name, string type, ushort width)
        {
            Name = name;
            Type = type;
            ColWidth = width;
        }

        public string Format()
            => string.Format(RP.pad(-(int)ColWidth), Name);

        public override string ToString()
            => Format();

        public static TableColumn Empty => new TableColumn(EmptyString, EmptyString, 0);
    }
}