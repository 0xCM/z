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

        public readonly ReadOnlySeq<ColumDef> Columns;

        [MethodImpl(Inline)]
        public TableDef(TableId name, Identifier type, ColumDef[] fields)
        {
            TableName = name;
            TypeName = type;
            Columns = fields;
        }

        public static TableDef Empty
            => new TableDef(TableId.Empty, Identifier.Empty, sys.empty<ColumDef>());

   }
}