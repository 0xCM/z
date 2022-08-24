//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    partial class XTend
    {
        public static Dictionary<K,V> ToDictionary<K,V>(this IEnumerable<(K key, V value)> src)
            => new Dictionary<K,V>(src.Select(x => new KeyValuePair<K,V>(x.key, x.value)));

        public static Dictionary<uint,T> ToIndexDictionary<T>(this ReadOnlySpan<T> src)
            => mapi(src, (i,x) => ((uint)i,x)).ToDictionary();

        public static Dictionary<uint,T> ToIndexDictionary<T>(this Span<T> src)
            => @readonly(src).ToIndexDictionary();

        public static SortedDictionary<K,V> ToSortedDictionary<K,V>(this IEnumerable<(K key, V value)> src)
            where K : IComparable<K>
                => new SortedDictionary<K,V>(src.ToDictionary());
        public static SortedDictionary<K,V> ToSortedDictionary<K,V>(this IEnumerable<(K,V)> src, IComparer<K> comparer)
            => new SortedDictionary<K,V>(src.ToDictionary(), comparer);
    }
}