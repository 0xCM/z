//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Build;

    /// <summary>
    /// Defines a symver-aligned build/publication version specifier
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct BuildVersion
    {
        public readonly int Major;

        public readonly int Minor;

        public readonly int Patch;

        readonly int Pad;

        [MethodImpl(Inline)]
        public BuildVersion(int major, int minor, int patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            Pad = 0;
        }
    
        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Algs.hash((ushort)Major, (ushort)Minor, (ushort)Patch);
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Major}.{Minor}.{Patch}";

        public override string ToString()
            => Format();

        public int CompareTo(BuildVersion src)
            => api.cmp(this,src);

        [MethodImpl(Inline)]
        public static implicit operator Version128(BuildVersion src)
            => Algs.@as<BuildVersion,Version128>(src);
        
        [MethodImpl(Inline)]
        public static implicit operator BuildVersion(Version128 src)
            => Algs.@as<Version128,BuildVersion>(src);
    }
}