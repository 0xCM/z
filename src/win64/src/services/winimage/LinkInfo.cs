//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class WinImage
    {
        public sealed class LinkInfo : NativeImage<LinkInfo>
        {
            public static LinkInfo load()
                => load<LinkInfo>();
        }
    }
}
