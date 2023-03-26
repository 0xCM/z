//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AssemblyKey : IDataType<AssemblyKey>
    {
        [Render(64)]
        public readonly @string Name;

        [Render(12)]
        public readonly AssemblyVersion Version;

        [Render(16)]
        public readonly @string TargetFramework;
        
        [Render(48)]
        public readonly EcmaMvid Mvid;

        [Render(1)]
        public readonly Hash128 ContentHash;
        
        [MethodImpl(Inline)]
        public AssemblyKey(@string name, AssemblyVersion version, @string framework, EcmaMvid mvid, Hash128 chash)
        {
            Name = name;
            TargetFramework = framework;
            Version = version;
            Mvid = mvid;
            ContentHash = chash;
        }

        public @string Identifier
        {
            [MethodImpl(Inline)]
            get => $"{Name}/{Version}";
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Mvid.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty || Mvid.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty && Mvid.IsNonEmpty;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Identifier;

        public override string ToString()
            => Format();
            
        [MethodImpl(Inline)]
        public int CompareTo(AssemblyKey src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
            {
                result = Version.CompareTo(src.Version);
                if(result == 0)
                {
                    result = TargetFramework.CompareTo(src.TargetFramework); 
                    if(result == 0)
                        result = Mvid.CompareTo(src.Mvid);
                }
            }
            return result;
        }
 
        public bool Equals(AssemblyKey key)
            => Mvid == key.Mvid;

        public static AssemblyKey Empty => new AssemblyKey(@string.Empty, AssemblyVersion.Empty, @string.Empty, EcmaMvid.Empty, default);
    }
}