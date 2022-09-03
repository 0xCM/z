//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface WNumeric<W> : INumericWidth<W>
        where W : struct, WNumeric<W>
    {
        NumericWidth INumericWidth.NumericWidth
            => Widths.numeric<W>();

        NativeTypeWidth ITypeWidth.TypeWidth
            => Widths.type<W>();
    }
}