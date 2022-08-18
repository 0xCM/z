//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface WType<W> : ITypeWidth<W>
        where W : struct, WType<W>
    {
        NativeTypeWidth ITypeWidth.TypeWidth
            => Widths.type<W>();
    }
}