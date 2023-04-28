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
}