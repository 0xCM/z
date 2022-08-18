//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SortedLookup<K,V>
        where K : IComparable<K>
    {
        public static Builder build()
            => new Builder();

        public class Builder
        {
            readonly ConcurrentDictionary<K,V> Data;

            public bool Contains(K key)
                => Data.ContainsKey(key);

            [MethodImpl(Inline)]
            public bool TryAdd(K key, Func<V> src)
                => Data.TryAdd(key, src());

            [MethodImpl(Inline)]
            public V AddOrUpdate(K key, Func<K,V> src)
                => Data.AddOrUpdate(key, src, (k,v) => src(k));

            [MethodImpl(Inline)]
            public bool TryAdd(K key, Func<Paired<K,V>> src)
                => Data.TryAdd(key, src().Right);

            [MethodImpl(Inline)]
            public void Add(K key, V value)
            {
                if(!Data.TryAdd(key, value))
                    Errors.Throw(string.Format("Duplicate entry:({0},{1})", key, value));
            }

            public Builder()
            {
                Data = new();
            }

            public Builder(ConcurrentDictionary<K,V> src)
            {
                Data = src;
            }

            public SortedLookup<K,V> Create()
            {
                var storage = this.Data;
                var keys = storage.Keys.Array().Sort();
                var values = storage.Values.Array();
                var entries = storage.Map(x => new SortedLookupEntry<K,V>(x.Key,x.Value)).Sort();
                return new(storage, keys, values, entries);
            }

        }

        readonly ConcurrentDictionary<K,V> Lookup;

        readonly Index<K> _Keys;

        readonly Index<V> _Values;

        readonly Index<SortedLookupEntry<K,V>> _Entries;

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

        SortedLookup(ConcurrentDictionary<K,V> storage, Index<K> keys, Index<V> values, Index<SortedLookupEntry<K,V>> entries)
        {
            Lookup = storage;
            _Keys = keys;
            _Values = values;
            _Entries = entries;
        }

        SortedLookup()
        {
            Lookup = new();
            _Keys = sys.empty<K>();
            _Values = sys.empty<V>();
            _Entries = sys.empty<SortedLookupEntry<K,V>>();
        }

        public SortedLookup(ConcurrentDictionary<K,V> src, Index<K> keys, Index<V> values)
        {
            Require.equal(Require.equal(keys.Count, values.Count), (uint)src.Count);
            Lookup = src;
            _Keys = keys.Sort();
            _Values = values;
            _Entries = Lookup.Map(x => new SortedLookupEntry<K,V>(x.Key,x.Value)).Sort();
        }

        public SortedLookup(ConcurrentDictionary<K,V> src)
        {
            Lookup = src;
            _Keys = src.Keys.Array().Sort();
            _Values = src.Values.Array();
            _Entries = Lookup.Map(x => new SortedLookupEntry<K,V>(x.Key,x.Value)).Sort();
        }

        public SortedLookup(Dictionary<K,V> src)
        {
            Lookup = src.ToConcurrentDictionary();
            _Keys = src.Keys.Array().Sort();
            _Values = src.Values.Array();
            _Entries = Lookup.Map(x => new SortedLookupEntry<K,V>(x.Key,x.Value)).Sort();
        }

        internal SortedLookup(ILookupData<K,V> src)
        {
            Lookup = src.Storage;
            _Keys = src.Keys.Sort();
            _Values = src.Values;
            _Entries = Lookup.Map(x => new SortedLookupEntry<K,V>(x.Key,x.Value)).Sort();
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

        public ReadOnlySpan<SortedLookupEntry<K,V>> Entries
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
            => Lookup.ContainsKey(key);

        public V this[K key]
        {
            [MethodImpl(Inline)]
            get => Lookup[key];
        }

        public ref readonly V this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref _Values[index];
        }

        public ref readonly V this[int index]
        {
            [MethodImpl(Inline)]
            get => ref _Values[index];
        }


        [MethodImpl(Inline)]
        public bool Find(K key, out V value)
            => Lookup.TryGetValue(key, out value);

        public Index<T> MapValues<T>(Func<V,T> f)
            => _Values.Map(f);

        public Index<T> MapKeys<T>(Func<K,T> f)
            => _Keys.Map(f);

        public Index<T> MapEntries<T>(Func<SortedLookupEntry<K,V>,T> f)
            => _Entries.Map(f);

        public static SortedLookup<K,V> Empty => new();

        public static implicit operator SortedLookup<K,V>(Dictionary<K,V> src)
            => new SortedLookup<K,V>(src);

        public static implicit operator SortedLookup<K,V>(ConcurrentDictionary<K,V> src)
            => new SortedLookup<K,V>(src);
    }
}