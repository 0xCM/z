//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class WinImage
    {
        public sealed class PsApi : NativeImage<PsApi>
        {
            public static PsApi load()
                => load(SystemDll<PsApi>());
        }
    }
}
