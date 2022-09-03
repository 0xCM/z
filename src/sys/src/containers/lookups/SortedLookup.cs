//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SortedLookup
    {
        public static SortedLookup<K,V>.Builder build<K,V>()
            where K : IComparable<K>
                => new();

        public static SortedLookup<K,V>.Builder build<K,V>(ConcurrentDictionary<K,V> src)
            where K : IComparable<K>
                => new(src);

        public static SortedLookup<K,V> create<K,V>(Index<K> keys, Index<V> values)
            where K : IComparable<K>
        {
            var dst = sys.cdict<K,V>();
            var count = Require.equal(keys.Count,values.Count);
            for(var i=0; i<count; i++)
                if(!dst.TryAdd(keys[i],values[i]))
                    sys.@throw(string.Format("Duplicate entry:({0},{1})", keys[i], values[i]));

            return new SortedLookup<K, V>(dst, keys, values);
        }

        public static SortedLookup<K,V> create<K,V>(ConcurrentDictionary<K,V> src)
            where K : IComparable<K>
                => new SortedLookup<K,V>(src);

        public static SortedLookup<K,V> create<K,V>(Dictionary<K,V> src)
            where K : IComparable<K>
                => new SortedLookup<K,V>(src);
    }
}