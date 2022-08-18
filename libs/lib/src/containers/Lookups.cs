//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    [ApiHost]
    public struct Lookups
    {
        const NumericKind Closure = UnsignedInts;

        public static KeyedValues<K,V> keyed<K,V>(Dictionary<K,V> src)
            => new KeyedValues<K,V>(src.Select(x => kvp(x.Key, x.Value)).Array());

        public static KeyedValues<K,V> keyed<K,V>(K key, V[] values)
            => new KeyedValues<K,V>(values.Select(value => kvp(key, value)));
    }

    partial class XTend
    {
        /// <summary>
        /// Creates a hashtable from a dictionary
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="K">The key type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        public static KeyValuePairs<K,V> ToKVPairs<K,V>(this Dictionary<K,V> src)
            => new KeyValuePairs<K,V>(src);
    }
}