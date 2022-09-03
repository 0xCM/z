//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SortedLookupEntry<K,V> : IComparable<SortedLookupEntry<K,V>>
        where K : IComparable<K>
    {
        public readonly K Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public SortedLookupEntry(K key, V value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]
        public int CompareTo(SortedLookupEntry<K,V> src)
            => Key.CompareTo(src.Key);

        public string Format()
            => string.Format("[{0}] = {1}", Key, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SortedLookupEntry<K,V>((K key, V value) src)
            => new SortedLookupEntry<K,V>(src.key, src.value);

        [MethodImpl(Inline)]
        public static implicit operator SortedLookupEntry<K,V>(Paired<K,V> src)
            => new SortedLookupEntry<K,V>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Paired<K,V>(SortedLookupEntry<K,V> src)
            => Tuples.paired(src.Key,src.Value);
    }
}