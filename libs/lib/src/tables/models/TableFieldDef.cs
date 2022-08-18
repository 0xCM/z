//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TableFieldDef
    {
        public readonly ushort FieldIndex;

        public readonly Identifier FieldName;

        public readonly Identifier DataType;

        [MethodImpl(Inline)]
        public TableFieldDef(ushort index, string name, Identifier type)
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