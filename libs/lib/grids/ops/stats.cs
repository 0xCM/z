//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct grids
    {
        [MethodImpl(Inline), Op]
        public static GridStats stats(in GridMetrics src)
            => new GridStats(
                RowCount : src.RowCount,
                ColCount : src.ColCount,
                SegWidth : src.CellWidth,
                StorageSegs : src.CellCount,
                StorageBits : src.StoreWidth,
                StorageBytes : src.StoreSize,
                PointCount : (uint)points(src.Dim),
                Vec128Count : coverage(src, W128.W),
                Vec128Remainder : remainder(src, W128.W),
                Vec256Count : coverage(src, W256.W),
                Vec256Remainder : remainder(src, W256.W)
            );
    }
}