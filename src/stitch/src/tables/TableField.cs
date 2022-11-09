//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TableField
    {
        public readonly ushort FieldIndex;

        public readonly Identifier FieldName;

        public readonly Identifier DataType;

        [MethodImpl(Inline)]
        public TableField(ushort index, string name, Identifier type)
        {
            FieldIndex = index;
            FieldName = name;
            DataType = type;
        }

        public string Format()
            => string.Format("[{0:D2} {1}:{2}]", FieldIndex, FieldName, DataType);

        public override string ToString()
            => Format();
    }
}