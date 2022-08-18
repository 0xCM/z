//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiTableDef
    {
        public readonly TableId TableId;

        public readonly Identifier TypeName;

        public readonly Index<TableFieldDef> Fields;

        [MethodImpl(Inline)]
        public ApiTableDef(TableId id, Identifier name, TableFieldDef[] fields)
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

        public static ApiTableDef Empty
            => new ApiTableDef(TableId.Empty, Identifier.Empty, sys.empty<TableFieldDef>());
    }
}