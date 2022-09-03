//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct ClrAssemblyNames
    {
        [MethodImpl(Inline), Op]
        public static ClrAssemblyName from(AssemblyName src)
            => new ClrAssemblyName(src);

        [MethodImpl(Inline), Op]
        public static ClrAssemblyName from(Assembly src)
            => new ClrAssemblyName(src);

        [MethodImpl(Inline), Op]
        public static AssemblyVersion version(AssemblyName src)
        {
            var version = src.Version;
            var dst = new AssemblyVersion((ushort)version.Major, (ushort)version.Minor, (ushort)version.Build, (ushort)version.Revision);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static string format(ClrAssemblyName src, AssemblyNameKind kind = AssemblyNameKind.Simple)
            => kind == AssemblyNameKind.Full ? src.FullName : src.SimpleName;
    }
}