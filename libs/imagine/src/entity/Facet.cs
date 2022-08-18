//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Facet : IFacet<string,object>
    {
        public readonly string Key;

        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public Facet(string name, dynamic value)
        {
            Key = name;
            Value = value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Algs.hash(Format());
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
        {
            var k = Key ?? EmptyString;
            var v = (Value ?? EmptyString).ToString();

            if(sys.nonempty(v))
                return RP.facet(k, v);
            else
                return k;
        }
    

        public override string ToString()
            => Format();


        object IFacet<string, object>.Value 
            => Value;

        string IKeyed<string>.Key 
            => Key;

        [MethodImpl(Inline)]
        public static implicit operator Facet((string name, dynamic value) src)
            => new Facet(src.name, src.value);

        public static Facet Empty => new Facet(EmptyString, EmptyString);
    }
}