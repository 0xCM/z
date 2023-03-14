//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct AssemblyKey
    {
        [Render(64)]
        public readonly @string Name;

        [Render(12)]
        public readonly AssemblyVersion Version;

        [Render(1)]
        public readonly Guid Mvid;

        [MethodImpl(Inline)]
        public AssemblyKey(@string name, AssemblyVersion version, Guid mvid)
        {
            Name = name;
            Version = version;
            Mvid = mvid;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash | sys.hash(@as<AssemblyVersion,ulong>(Version)) | nhash(Mvid);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(AssemblyKey src)
        {
            var result = Name.CompareTo(src.Name);
            if(result == 0)
            {
                result = Version.CompareTo(src.Version);
                if(result == 0)
                    result = Mvid.CompareTo(src.Mvid);
            }
            return result;
        }
    }
}