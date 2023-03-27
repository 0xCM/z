//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        public record struct ComponentKey : IComparable<ComponentKey>
        {
            public readonly @string Name;

            public readonly @string Version;

            [MethodImpl(Inline)]
            public ComponentKey(@string name, @string version)
            {
                Name = name;
                Version = version;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Name.Hash | Version.Hash;
            }

            public override int GetHashCode()
                => Hash;

            public bool Equals(ComponentKey src)
                => Name == src.Name && Version == src.Version;

            public string Format()
                => $"{Name}/{Version}";

            public override string ToString()
                => Format();

            public int CompareTo(ComponentKey src)
            {
                var result = Name.CompareTo(src.Name);
                if(result == 0)
                    result = Version.CompareTo(src.Version);
                return result;
            }
        }
    }
}