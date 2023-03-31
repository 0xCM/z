//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class WinImage
    {
        public sealed class PsApi : NativeImage<PsApi>
        {
            public static PsApi load()
                => load(FS.path("psapi.dll"));

            protected override void OnImageLoad(ImageHandle handle)
            {

            }
        }
    }
}
