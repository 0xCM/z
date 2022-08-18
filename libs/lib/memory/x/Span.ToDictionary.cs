//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XTend
    {
        [Op, Closures(Closure)]
        public static Dictionary<K,V> ToDictionary<K,V>(this ReadOnlySpan<(K,V)> src)
        {
            var count = src.Length;
            var dst = dict<K,V>(count);
            for(var i = 0u; i<count; i++)
            {
                ref readonly var kv = ref skip(src,i);
                dst.TryAdd(kv.Item1, kv.Item2);
            }
            return dst;
        }

        [Op, Closures(Closure)]
        public static Dictionary<K,V> ToDictionary<K,V>(this Span<(K,V)> src)
            => src.ReadOnly().ToDictionary();

        public static SortedDictionary<K,V> ToSortedDictionary<K,V>(this ReadOnlySpan<(K,V)> src)
            where K : IComparable<K>
                => new SortedDictionary<K, V>(src.ToDictionary());

        public static SortedDictionary<K,V> ToSortedDictionary<K,V>(this Span<(K,V)> src)
            where K : IComparable<K>
                => new SortedDictionary<K,V>(src.ToDictionary());

        public static SortedDictionary<K,V> ToSortedDictionary<K,V>(this Span<(K,V)> src, IComparer<K> comparer)
            => new SortedDictionary<K,V>(src.ToDictionary(), comparer);

        public static SortedDictionary<K,V> ToSortedDictionary<K,V>(this ReadOnlySpan<(K,V)> src, IComparer<K> comparer)
            => new SortedDictionary<K,V>(src.ToDictionary(), comparer);
    }
}