//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public readonly record struct TypeName : IDataType<TypeName>, IDataString<TypeName>
    {
        readonly @string Value;

        public TypeName()
        {
            Value = @string.Empty;
        }

        [MethodImpl(Inline)]
        public TypeName(@string value)   
        {
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Value.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Value.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(TypeName src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(TypeName src)
            => Value.CompareTo(src.Value);

        public string Format()
            => Value.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeName(Type src)
            => new TypeName(src.AssemblyQualifiedName);

        [MethodImpl(Inline)]
        public static implicit operator TypeName(string src)
            => new TypeName(src);

        [MethodImpl(Inline)]
        public static implicit operator TypeName(@string src)
            => new TypeName(src);

        public static TypeName Empty => new();
    }
}
