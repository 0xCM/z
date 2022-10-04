//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline)]
        public static KeyedValue<K,V> kv<K,V>(K key, V value)
            => new KeyedValue<K,V>(key, value);
    }
}