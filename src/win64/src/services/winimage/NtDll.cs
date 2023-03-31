//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class WinImage
    {
        public sealed class NtDll : NativeImage<NtDll>
        {
            public static NtDll load()
                => load(FS.path("ntdll.dll"));

            class Delegates
            {

            }

            protected override void OnImageLoad(ImageHandle handle)
            {
                
            }

        }
    }
}
