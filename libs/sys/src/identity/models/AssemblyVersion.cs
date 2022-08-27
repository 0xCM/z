//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a four-part asemembly version number
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AssemblyVersion
    {
        public readonly ushort Major;

        public readonly ushort Minor;

        public readonly ushort Build;

        public readonly ushort Revision;

        [MethodImpl(Inline)]
        public AssemblyVersion(ushort a, ushort b, ushort c, ushort d)
        {
            Major = a;
            Minor = b;
            Build = c;
            Revision = d;
        }

        public string Format()
            =>$"{Major}.{Minor}.{Build}.{Revision}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static explicit operator ulong(AssemblyVersion src)
            => sys.uint64(src);

        [MethodImpl(Inline)]
        public static implicit operator AssemblyVersion(Version src)
            => new AssemblyVersion((ushort)src.Major, (ushort)src.Minor, (ushort)src.Build, (ushort)src.Revision);

        [MethodImpl(Inline)]
        public static implicit operator Version(AssemblyVersion src)
            => new Version(src.Major, src.Minor, src.Build, src.Revision);
    }
}