//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [Op, Closures(UInt8k)]
        public static ReadOnlySpan<byte> row<T>(AsciGrid<T> src, uint index)
            where T : unmanaged
                => slice(src.Rows, index*src.RowWidth, src.RowWidth);

        [Op, Closures(UInt8k)]
        public static ReadOnlySpan<byte> row(AsciGrid src, uint index)
            => slice(src.Rows, index*src.RowWidth, src.RowWidth);
    }
}