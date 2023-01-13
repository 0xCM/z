//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Heaps
    {
        [Op]
        public static ReadOnlySeq<SymHeapRecord> records(SymHeap src)
        {
            var count = src.SymbolCount;
            var dst = alloc<SymHeapRecord>(count);
            var remains = src.CharCount*2;
            for(var i=0u; i<count; i++)
            {
                ref var entry = ref seek(dst,i);
                remains -= src.Size(i);
                entry.Key = i;
                entry.Offset = src.Offset(i)*2;
                entry.Size = src.Size(i);
                entry.Remains = remains;
                entry.Source = src.Source(i);
                entry.Name = src.Name(i);
                entry.Value = src.Value(i);
                entry.Expression = text.format(src.Symbol(i));
            }
            return dst;
        }
    }
}