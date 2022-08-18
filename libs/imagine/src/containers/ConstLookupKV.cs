//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ConstLookup<K,V> : ILookupData<K,V>
    {
        readonly ConcurrentDictionary<K,V> Storage;

        Index<K> _Keys;

        Index<V> _Values;

        Index<LookupEntry<K,V>> _Entries;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => _Entries.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => _Entries.IsNonEmpty;
        }

        ConstLookup()
        {
            Storage = new();
            _Keys = sys.empty<K>();
            _Values = sys.empty<V>();
            _Entries = sys.empty<LookupEntry<K,V>>();
        }

        public ConstLookup(ConcurrentDictionary<K,V> src)
        {
            Storage = src;
            _Keys = src.Keys.Array();
            _Values = src.Values.Array();
            _Entries = src.Map(x => new LookupEntry<K,V>(x.Key,x.Value));
        }

        public ConstLookup(IDictionary<K,V> src)
        {
            Storage = src.ToConcurrentDictionary();
            _Keys = src.Keys.Array();
            _Values = src.Values.Array();
            _Entries = src.Map(x => new LookupEntry<K,V>(x.Key,x.Value));
        }

        public ReadOnlySpan<K> Keys
        {
            [MethodImpl(Inline)]
            get => _Keys.View;
        }

        public ReadOnlySpan<V> Values
        {
            [MethodImpl(Inline)]
            get => _Values.View;
        }

        public ReadOnlySpan<LookupEntry<K,V>> Entries
        {
            [MethodImpl(Inline)]
            get => _Entries.View;
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => _Entries.Count;
        }

        [MethodImpl(Inline)]
        public bool ContainsKey(K key)
            => Storage.ContainsKey(key);

        public V this[K key]
        {
            [MethodImpl(Inline)]
            get => Storage[key];
        }

        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
            => Storage.TryGetValue(key, out value);

        public Index<T> MapValues<T>(Func<V,T> f)
            => _Values.Map(f);

        public Index<T> MapKeys<T>(Func<K,T> f)
            => _Keys.Map(f);

        public Index<T> MapEntries<T>(Func<LookupEntry<K,V>,T> f)
            => _Entries.Map(f);

        public static ConstLookup<K,V> Empty => new();

        ConcurrentDictionary<K, V> ILookupData<K, V>.Storage
            => Storage;

        Index<K> ILookupData<K, V>.Keys
            => _Keys;

        Index<V> ILookupData<K, V>.Values
            => _Values;

        public static implicit operator ConstLookup<K,V>(Dictionary<K,V> src)
            => new ConstLookup<K,V>(src);

        public static implicit operator ConstLookup<K,V>(ConcurrentDictionary<K,V> src)
            => new ConstLookup<K,V>(src);
    }
}