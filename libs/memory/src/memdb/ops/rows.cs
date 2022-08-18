//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public static Index<TypeTableRow> rows(Index<DbTypeTable> src)
            => src.SelectMany(x => x.Rows).Sort().Resequence();
    }
}