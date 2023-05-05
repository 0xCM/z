//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public int GetRowCount(TableIndex index)
            => MD.GetTableRowCount(index);

        [Op]
        public Index<TableIndex,uint> GetRowCounts()
        {
            var index = Symbols.values<TableIndex,byte>();
            var count = index.Count;
            var dst = sys.alloc<uint>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = (uint)GetRowCount(index[i].Key);
            return dst;
        }
    }
}