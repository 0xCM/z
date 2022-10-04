//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ts
{
    public readonly struct Token<K,V> 
    {
        public readonly K Key;

        public readonly V Value;

        public Token(K key, V value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator Token<K,V>((K key, V value) src)
            => new (src.key,src.value);
    }
}