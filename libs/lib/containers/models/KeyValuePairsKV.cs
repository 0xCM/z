//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Collections;

    /// <summary>
    /// Reifies a K-V parametric hashtable, along with extras
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public readonly struct KeyValuePairs<K,V> : IKeyValuePairs<K,V>
    {
        public readonly K[] Keys;

        public readonly V[] Values;

        readonly IReadOnlyDictionary<K,V> KeyedValues;

        readonly HashSet<V> ValueSet;

        readonly IReadOnlyDictionary<V,K[]> IndexedValues;

        public ISet<V> DistinctValues
        {
            [MethodImpl(Inline)]
            get => ValueSet;
        }

        public V this[K key]
        {
            [MethodImpl(Inline)]
            get => KeyedValues[key];
        }

        public int Count
        {
            [MethodImpl(Inline)]
            get => KeyedValues.Count;
        }

        public K[] this[V value]
        {
            [MethodImpl(Inline)]
            get => IndexedValues[value];
        }

        [MethodImpl(Inline)]
        public K[] ValueKeys(V value)
            => this[value];

        [MethodImpl(Inline)]
        public bool ContainsKey(K key)
            => KeyedValues.ContainsKey(key);

        [MethodImpl(Inline)]
        public bool ContainsValue(V value)
            => ValueSet.Contains(value);

        [MethodImpl(Inline)]
        public bool TryGetValue(K key, out V value)
            => KeyedValues.TryGetValue(key, out value);

        [MethodImpl(Inline)]
        public bool TryGetKeys(V value, out K[] keys)
            => IndexedValues.TryGetValue(value, out keys);

        KeyValuePairs(int i)
        {
            KeyedValues = new Dictionary<K,V>();
            ValueSet = new HashSet<V>();
            IndexedValues = new Dictionary<V,K[]>();
            Keys = Array.Empty<K>();
            Values = Array.Empty<V>();
        }

        public KeyValuePairs(IReadOnlyDictionary<K,V> data)
        {
            KeyedValues = data;
            Keys = data.Keys.ToArray();
            Values = data.Values.ToArray();
            ValueSet = Values.ToHashSet();
            var valueIndex = new Dictionary<V,K[]>();
            IndexedValues = valueIndex;
        }

        public KeyValuePairs(Dictionary<K,V> data)
        {
            KeyedValues = data;
            Keys = data.Keys.ToArray();
            Values = data.Values.ToArray();
            ValueSet = Values.ToHashSet();
            IndexedValues = data.Flip();
        }

        IEnumerable<K> IReadOnlyDictionary<K,V>.Keys
            => Keys;

        IEnumerable<V> IReadOnlyDictionary<K,V>.Values
            => Values;

        IEnumerator<KeyValuePair<K,V>> IEnumerable<KeyValuePair<K,V>>.GetEnumerator()
            => KeyedValues.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => KeyedValues.GetEnumerator();

        K[] IKeyValuePairs<K,V>.Keys
            => Keys;

        V[] IKeyValuePairs<K,V>.Values
            => Values;

        /// <summary>
        /// A hashtable that hashes nothing
        /// </summary>
        public static KeyValuePairs<K,V> Empty
            => new KeyValuePairs<K,V>(0);
    }
}