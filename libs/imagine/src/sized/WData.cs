//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface WData<W> : IDataWidth<W>
        where W : struct, WData<W>
    {
        DataWidth IDataWidth.DataWidth
            => (DataWidth)DataWidths.measure<W>();

        bool IEquatable<W>.Equals(W src)
            => src.BitWidth == BitWidth;
    }
}