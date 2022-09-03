//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Creates a concurrent dictionary from an ordinary dictionary
        /// </summary>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="d">The source dictionary</param>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this IDictionary<K,V> d)
            => new ConcurrentDictionary<K,V>(d);

        /// <summary>
        /// Constructs a mutable dictionary from a sequence of key-value pairs
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The indexed value</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static ConcurrentDictionary<K,V> ToConcurrentDictionary<K,V>(this IEnumerable<(K key, V value)> src)
            => new ConcurrentDictionary<K, V>(src.Select(x => new KeyValuePair<K,V>(x.key, x.value)));
    }
}