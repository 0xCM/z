//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AssemblyKey : IDataType<AssemblyKey>
    {
        [Render(64)]
        public readonly VersionedName AssemblyName;

        [Render(12)]
        public readonly AssemblyVersion Version;

        [Render(16)]
        public readonly @string TargetFramework;
        
        [Render(48)]
        public readonly EcmaMvid Mvid;

        [Render(1)]
        public readonly Hash128 ContentHash;
        
        [MethodImpl(Inline)]
        public AssemblyKey(VersionedName name, AssemblyVersion version, @string framework, EcmaMvid mvid, Hash128 chash)
        {
            AssemblyName = name;
            TargetFramework = framework;
            Version = version;
            Mvid = mvid;
            ContentHash = chash;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Mvid.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => AssemblyName.IsEmpty || Mvid.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => AssemblyName.IsNonEmpty && Mvid.IsNonEmpty;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => AssemblyName.Format();

        public override string ToString()
            => Format();
            
        [MethodImpl(Inline)]
        public int CompareTo(AssemblyKey src)
        {
            var result = AssemblyName.CompareTo(src.AssemblyName);
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

        public static AssemblyKey Empty => new AssemblyKey(VersionedName.Empty, AssemblyVersion.Empty, @string.Empty, EcmaMvid.Empty, default);
    }
}