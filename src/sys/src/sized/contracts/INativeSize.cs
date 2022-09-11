//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeSize<W> : ITypeWidth<W>
        where W : struct, INativeSize<W>
    {
        NativeTypeWidth ITypeWidth.TypeWidth
            => Widths.type<W>();
    }
}