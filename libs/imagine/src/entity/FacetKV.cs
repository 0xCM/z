//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Facet<K,V> : IFacet<K,V>
        where K : IEquatable<K>, IComparable<K>
    {
        public readonly K Key;

        public readonly V Value;

        [MethodImpl(Inline)]
        public Facet(K key, V value)
        {
            Key = key;
            Value = value;
        }

        V IFacet<K,V>.Value 
            => Value;

        K IKeyed<K>.Key 
            => Key;

        public string Format()
            => RP.facet(Key,Value);

        public override string ToString()
            => Format();

        public static implicit operator Facet<K,V>((K key, V value) src)
            => new Facet<K,V>(src.key, src.value);
    }
}