//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    partial class XTend
    {
        [Op, Closures(Closure)]
        public static ConstLookup<K,V> ToConstLookup<K,V>(this Dictionary<K,V> src)
            => src;

        [Op, Closures(Closure)]
        public static ConstLookup<K,V> ToConstLookup<K,V>(this ConcurrentDictionary<K,V> src)
            => src;

        [Op, Closures(Closure)]
        public static ConstLookup<K,V> ToConstLookup<K,V>(this (K key, V value)[] src)
            => src.ToDictionary();

        [Op, Closures(Closure)]
        public static ConstLookup<K,V> ToConstLookup<K,V>(this Paired<K,V>[] src)
            => src.ToDictionary();
    }
}