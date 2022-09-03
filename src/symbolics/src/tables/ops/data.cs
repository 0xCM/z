//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class StringTables
    {
        [Op]
        public static Index<StringTableRow> rows<K>(ItemList<K,string> src)
            where K : unmanaged
        {
            var count = src.Count;
            var dst = sys.alloc<StringTableRow>(count);
            rows(src,dst);
            return dst;
        }

        [Op]
        public static uint rows<K>(ItemList<K,string> src, Span<StringTableRow> dst)
            where K : unmanaged
        {
            var entries = src.View;
            var count = (uint)min(entries.Length,dst.Length);
            for(var j=0u; j<count; j++)
            {
                ref var row = ref seek(dst,j);
                row.Index = j;
                row.Content = src[j].Value;
                row.Table = src.Name;
            }
            return count;
        }
    }
}