//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public record struct TypeListEntry : IDataString<TypeListEntry>
    {
        readonly string _TypeName;

        readonly Type _Type;
        
        [MethodImpl(Inline)]
        public TypeListEntry(string name)
        {
            _TypeName = name;
            _Type = Type.GetType(name);
        }   

        [MethodImpl(Inline)]
        public TypeListEntry(Type type)
        {
            _TypeName = type.AssemblyQualifiedName;
            _Type = type;
        }

        public string TypeName
        {
            [MethodImpl(Inline)]
            get => _TypeName;
        }

        public Type Type
        {
            [MethodImpl(Inline)]
            get => _Type;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(_TypeName);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(_TypeName);
        }

        public string Format()
            => _TypeName;

        public override string ToString()
            => _TypeName;
        
        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(_TypeName);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(TypeListEntry src)
            => _TypeName.CompareTo(src._TypeName);

        [MethodImpl(Inline)]
        public bool Equals(TypeListEntry src)
            => asci32.eq(_TypeName,src._TypeName);
        
        [MethodImpl(Inline)]
        public static implicit operator TypeListEntry(string name)
            => new TypeListEntry(name);

        [MethodImpl(Inline)]
        public static implicit operator TypeListEntry(Type src)
            => new TypeListEntry(src.AssemblyQualifiedName);
    }
}