//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class XTend
    {
        /// <summary>
        /// Constructs a mutable dictionary from a sequence of key-value pairs
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The indexed value</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this ReadOnlySpan<(K key, V value)> src)
            => new ConcurrentDictionary<K, V>(map(src,x => new KeyValuePair<K,V>(x.key, x.value)));

        /// <summary>
        /// Constructs a mutable dictionary from a sequence of key-value pairs
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The indexed value</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this Span<(K key, V value)> src)
            => new ConcurrentDictionary<K, V>(map(src,x => new KeyValuePair<K,V>(x.key, x.value)));

        /// <summary>
        /// Creates a concurrent dictionary from the input sequence
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="values">The input sequence</param>
        /// <param name="keySelector"></param>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this IEnumerable<V> values, Func<V, K> keySelector)
            => new ConcurrentDictionary<K,V>(
                from value in values select new KeyValuePair<K,V>(keySelector(value), value));

        /// <summary>
        /// Creates a concurrent dictionary from the input sequence
        /// </summary>
        /// <typeparam name="S">The input sequence type</typeparam>
        /// <typeparam name="K">The dictionary key type</typeparam>
        /// <typeparam name="V">The type of the indexed valuie</typeparam>
        /// <param name="sources">The input sequence</param>
        /// <param name="keySelector">Function that selects the key</param>
        /// <param name="valueSelector">Function that selects the value</param>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<S,K,V>(this IEnumerable<S> sources, Func<S,K> keySelector, Func<S,V> valueSelector)
            => new ConcurrentDictionary<K,V>(from item in sources select new KeyValuePair<K,V>(keySelector(item), valueSelector(item)));
        public static Dictionary<uint,T> ToIndexDictionary<T>(this Index<T> src)
            => @readonly(src.Storage).ToIndexDictionary();

        public static Dictionary<uint,T> ToIndexDictionary<T>(this T[] src)
            => @readonly(src).ToIndexDictionary();

        public static Dictionary<K,V> ToDictionary<K,V>(this IEnumerable<KeyedValue<K,V>> src)
            => src.Select(x => (x.Key, x.Value)).ToDictionary();


        [MethodImpl(Inline)]
        public static Index<T> Filter<T>(this T[] src, Func<T, bool> f)
            => src.Where(f);

        [MethodImpl(Inline)]
        public static Index<T> ToIndex<T>(this T[] src)
            => src;

        [MethodImpl(Inline)]
        public static Index<T> ToIndex<T>(this List<T> src)
            => src.ToArray();

        [MethodImpl(Inline)]
        public static Index<T> ToIndex<T>(this IEnumerable<T> src)
            => src.Array();

        public static uint AddRange<T>(this HashSet<T> dst, ReadOnlySpan<T> src)
        {
            var counter = 0u;
            foreach(var item in src)
                if(dst.Add(item))
                    counter++;
            return counter;
        }

        public static uint AddRange<T>(this HashSet<T> dst, params T[] src)
            => dst.AddRange(@readonly(src));
    }
}