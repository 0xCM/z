//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static AssemblyVersion version(AssemblyName src)
        {
            var version = src.Version;
            var dst = new AssemblyVersion((ushort)version.Major, (ushort)version.Minor, (ushort)version.Build, (ushort)version.Revision);
            return dst;
        }
    }
}