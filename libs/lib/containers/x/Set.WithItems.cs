// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    partial class XTend
    {
        /// <summary>
        /// Adds a stream of items to a target set
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="dst">The target set</param>
        /// <param name="src">The source stream</param>
        public static ISet<T> WithItems<T>(this ISet<T> dst, IEnumerable<T> src)
        {
            src.Iter(item => dst.Add(item));
            return dst;
        }

        /// <summary>
        /// Adds a stream of items to a target set
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="dst">The target set</param>
        /// <param name="src">The source stream</param>
        public static HashSet<T> WithItems<T>(this HashSet<T> dst, IEnumerable<T> src)
        {
            src.Iter(item => dst.Add(item));
            return dst;
        }

        /// <summary>
        /// Addes the entries of the source dictionary to the destination dictionary
        /// </summary>
        /// <typeparam name="TKey">The common dictionary key type</typeparam>
        /// <typeparam name="TValue">The common dictionary value type</typeparam>
        /// <param name="dst">The target dictionary</param>
        /// <param name="src">The source dictionary</param>
        public static IDictionary<TKey, TValue> WithItems<TKey, TValue>(this IDictionary<TKey,TValue> dst, IReadOnlyDictionary<TKey, TValue> src)
        {
            src.Iter(s => dst.Add(s.Key, s.Value));
            return dst;
        }

        /// <summary>
        /// Addes the key-value pairs to the extended dictionary
        /// </summary>
        /// <param name="dst">The extended dictionary</param>
        /// <param name="src">The items to add</param>
        /// <typeparam name="K">The dictionary key type</typeparam>
        /// <typeparam name="V">The dictionary value type</typeparam>
        public static IDictionary<K,V> WithItems<K,V>(this IDictionary<K, V> dst, IEnumerable<KeyValuePair<K,V>> src)
        {
            src.Iter(item => dst.Add(item));
            return dst;
        }

    }
}