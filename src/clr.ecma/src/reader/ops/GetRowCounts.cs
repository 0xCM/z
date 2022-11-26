//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {
        [Op]
        public Index<TableIndex,uint> GetRowCounts(ReadOnlySeq<KeyedValue<TableIndex,byte>> indices)
        {
            var count = indices.Count;
            var dst = sys.alloc<uint>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (uint)MD.GetTableRowCount(indices[i].Key);
            return dst;
        }
    }
}