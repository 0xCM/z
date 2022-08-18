//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiTableDb
    {
        ConstLookup<TableId,ApiTableDef> _Defs;

        public ApiTableDb(ApiTableDef[] schemas)
        {
            _Defs = schemas.Map(s => (s.TableId, s)).ToConstLookup();
        }

        public bool Schema(TableId table, out ApiTableDef schema)
            => _Defs.Find(table, out schema);

        public ReadOnlySpan<ApiTableDef> TableDefs
        {
            [MethodImpl(Inline)]
            get => _Defs.Values;
        }

        public ReadOnlySpan<TableId> TableNames
        {
            [MethodImpl(Inline)]
            get => _Defs.Keys;
        }
    }
}