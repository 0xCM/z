//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class TableDef
    {
        public readonly TableId TableName;

        public readonly Identifier TypeName;

        public readonly ReadOnlySeq<Column> Columns;

        [MethodImpl(Inline)]
        public TableDef(TableId name, Identifier type, Column[] fields)
        {
            TableName = name;
            TypeName = type;
            Columns = fields;
        }

        public static TableDef Empty
            => new TableDef(TableId.Empty, Identifier.Empty, sys.empty<Column>());

        public record class Column
        {
            public readonly ushort Index;

            public readonly Identifier Name;

            public readonly Identifier DataType;

            [MethodImpl(Inline)]
            public Column(ushort index, string name, Identifier type)
            {
                Index = index;
                Name = name;
                DataType = type;
            }

            public string Format()
                => string.Format("[{0:D2} {1}:{2}]", Index, Name, DataType);

            public override string ToString()
                => Format();
        }
    }
}