//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class WinImage
    {
        public sealed class NtDll : NativeImage<NtDll>
        {
            public static NtDll load()
                => load(FS.path("c:/windows/system32/ntdll.dll"));
        }
    }
}
