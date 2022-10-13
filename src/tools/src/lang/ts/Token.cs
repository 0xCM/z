//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TokenLift<K,V> 
    {
        public readonly K Key;

        public readonly V Value;

        public TokenLift(K key, V value)
        {
            Key = key;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator TokenLift<K,V>((K key, V value) src)
            => new (src.key,src.value);
    }
}