//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonTypes 
    {
        public sealed record class TypeParameter : IJsonParameter<TypeParameter>
        {
            public TypeParameter(string name)
            {
                Name = name;
            }

            public TypeParameter()
            {
                Name = EmptyString;
            }

            public @string Name {get;}

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsNonEmpty;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Name.Hash;
            }

            public int CompareTo(TypeParameter src)
                => Name.CompareTo(src.Name);

            public override int GetHashCode()
                => Hash;

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            public bool Equals(TypeParameter src)
                => Name.Equals(src.Name);

            [MethodImpl(Inline)]
            public static implicit operator TypeParameter(string name)
                => new(name);
        }
    }        
}