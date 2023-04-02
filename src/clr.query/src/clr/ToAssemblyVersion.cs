//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static AssemblyVersion ToAssemblyVersion(this Version64 src)
            => sys.@as<Version64,AssemblyVersion>(src);

        [MethodImpl(Inline), Op]
        public static AssemblyVersion ToAssemblyVersion(this Version128 src)
            => new AssemblyVersion((ushort)src.A, (ushort)src.B, (ushort)src.C, (ushort)src.D);
    }
}
