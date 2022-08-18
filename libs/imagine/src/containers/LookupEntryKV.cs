//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LookupEntry<K,V>
    {
        public readonly K Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public LookupEntry(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public string Format()
            => string.Format("[{0}] = {1}", Key, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LookupEntry<K,V>((K key, V value) src)
            => new LookupEntry<K,V>(src.key, src.value);
    }
}