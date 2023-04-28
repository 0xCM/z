//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct VersionedName : IComparable<VersionedName>
    {
        public readonly @string Name;

        public readonly Version64 Version;

        [MethodImpl(Inline)]
        public VersionedName(string name, Version64 version)
        {
            Name = name;
            Version = version;
        }
        
        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | Version.Hash;
        }

        [MethodImpl(Inline)]
        public bool Equals(VersionedName src)
            => Name == src.Name && Version == src.Version;

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

        [MethodImpl(Inline)]
        public int CompareTo(VersionedName src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
                result = Version.CompareTo(src.Version);
            return result;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Name;
        
        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator VersionedName(AssemblyName src)
            => src.GetVersionedName();

        public static VersionedName Empty => new VersionedName(EmptyString, default);
    }
}