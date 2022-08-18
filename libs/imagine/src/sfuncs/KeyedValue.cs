//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    /// <summary>
    /// Correlates a value with a key that uniquely identifies the value within some context
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct KeyedValue<K,V>
    {
        /// <summary>
        /// The key that identifies the value
        /// </summary>
        public K Key;

        /// <summary>
        /// The value identified by the key
        /// </summary>
        public V Value;

        [MethodImpl(Inline)]
        public KeyedValue(K key, V value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]
        public KeyedValue((K key, V value) kv)
        {
            Key = kv.key;
            Value = kv.value;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out K key, out V value)
        {
            key = Key;
            value = Value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Key,Value);
        }
        public string Format()
            => $"{Value.GetType().Name}[{Key}]={Value}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator KeyedValue<K,V>((K key, V value) src)
            => new KeyedValue<K,V>(src);

        [MethodImpl(Inline)]
        public static implicit operator (K key, V value)(KeyedValue<K,V> src)
            => (src.Key, src.Value);
    }
}