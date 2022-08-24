//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Facet<T> : IFacet<string,T>
    {
        public readonly string Key;

        public readonly T Value;

        [MethodImpl(Inline)]
        public Facet(string name, T value)
        {
            Key = name;
            Value = value;
        }

        T IFacet<string,T>.Value 
            => Value;

        string IKeyed<string>.Key 
            => Key;

        [MethodImpl(Inline)]
        public void Deconstruct(string key, T value)
        {
            key = Key;
            value = Value;
        }

        public string Format()
            => RP.attrib(Key,Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Facet<T>((string name, T value) src)
            => new Facet<T>(src.name, src.value);
    }
}