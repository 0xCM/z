//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        static Version64 GetVersion64(this AssemblyName src)
            => new Version64((ushort)src.Version.Major, (ushort)src.Version.Minor, (ushort)src.Version.Build, (ushort)src.Version.Revision);

        public static VersionedName GetVersionedName(this AssemblyName src)
            => new (src.SimpleName(), src.GetVersion64());
    }

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
            => $"{Name}/{Version}";
        
        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator VersionedName(AssemblyName src)
            => src.GetVersionedName();

        public static VersionedName Empty => new VersionedName(EmptyString, default);
    }
}