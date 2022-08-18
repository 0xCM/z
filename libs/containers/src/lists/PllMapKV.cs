//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class PllMap<K,V>
    {
        readonly ConcurrentDictionary<K,V> Data;

        public PllMap()
        {
            Data = new();
        }

        [MethodImpl(Inline)]
        public PllMap(ConcurrentDictionary<K,V> src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public bool Include(K key, V value)
            => Data.TryAdd(key,value);

        [MethodImpl(Inline)]
        public V GetOrAdd(K key, Func<K,V> f)
            => Data.GetOrAdd(key,f);

        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
            => Data.TryGetValue(key, out value);

        [MethodImpl(Inline)]
        public V Include(K key, Func<K,V> f)
            => Data.GetOrAdd(key,f);

        [MethodImpl(Inline)]
        public Index<V> Include(ReadOnlySpan<K> keys, Func<K,V> f)
            => map(keys, key => Data.GetOrAdd(key,f));

        public ICollection<K> Keys
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public ICollection<V> Values
        {
            [MethodImpl(Inline)]
            get => Data.Values;
        }

        [MethodImpl(Inline)]
        public static implicit operator PllMap<K,V>(ConcurrentDictionary<K,V> src)
            => new PllMap<K,V>(src);

        [MethodImpl(Inline)]
        public static implicit operator ConcurrentDictionary<K,V>(PllMap<K,V> src)
            => src.Data;
    }
}