//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static LookupProjector<K,V,T> ToLookupProjector<K,V,T>(this IEnumerable<(K key, V value)> src, IProjector<V,T> projector)
            => src.ToDictionary().ToLookupProjector(projector);

        public static LookupProjector<K,V,T> ToLookupProjector<K,V,T>(this ConcurrentDictionary<K,V> src, IProjector<V,T> projector)
            => new LookupProjector<K,V,T>(src,projector);

        public static LookupProjector<K,V,T> ToLookupProjector<K,V,T>(this IDictionary<K,V> src, IProjector<V,T> projector)
            => new LookupProjector<K,V,T>(src,projector);

        public static ConstLookup<K,V> ToConstLookup<K,V>(this IEnumerable<(K key, V value)> src)
            => src.ToDictionary();

        public static SortedLookup<K,V> ToSortedLookup<K,V>(this IEnumerable<(K key, V value)> src)
            where K : IComparable<K>
                => new SortedLookup<K,V>(src.ToDictionary());

        /// <summary>
        /// Determines whether a set is empty
        /// </summary>
        /// <typeparam name="T">The type of element that may be contained in the set</typeparam>
        /// <param name="set">The set under examination</param>
        [MethodImpl(Inline)]
        public static bool IsEmpty<T>(this ISet<T> set)
            => set.Count == 0;

        /// <summary>
        /// Determines whether a set is nonempty
        /// </summary>
        /// <typeparam name="T">The type of element that may be contained in the set</typeparam>
        /// <param name="set">The set under examination</param>
        [MethodImpl(Inline)]
        public static bool IsNonEmpty<T>(this ISet<T> set)
            => set.Count != 0;

        /// <summary>
        /// Determines whether a collection contains any elements
        /// </summary>
        /// <typeparam name="T">The type of item contained by the collection</typeparam>
        /// <param name="src">The collection to examine</param>
        [MethodImpl(Inline)]
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> src)
             => src.Count == 0;
    }
}