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
        [MethodImpl(Inline), Op]
        public int GetRowCount(TableIndex index)
            => MD.GetTableRowCount(index);

        [Op]
        public Index<TableIndex,uint> GetRowCounts(ReadOnlySeq<KeyedValue<TableIndex,byte>> indices)
        {
            var count = indices.Count;
            var dst = sys.alloc<uint>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (uint)GetRowCount(indices[i].Key);
            return dst;
        }
    }
}