//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TableDef
    {
        public readonly TableId TableId;

        public readonly Identifier TypeName;

        public readonly Index<TableField> Fields;

        [MethodImpl(Inline)]
        public TableDef(TableId id, Identifier name, TableField[] fields)
        {
            TableId = id;
            TypeName = name;
            Fields = fields;
        }

        public uint FieldCount
        {
            [MethodImpl(Inline)]
            get => Fields.Count;
        }

        public static TableDef Empty
            => new TableDef(TableId.Empty, Identifier.Empty, sys.empty<TableField>());
    }
}