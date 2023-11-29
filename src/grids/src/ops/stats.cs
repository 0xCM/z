//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct grids
{
    [MethodImpl(Inline), Op]
    public static GridStats stats(in GridMetrics src)
        => new (
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

    /// <summary>
    /// Calculates memory block statistics for specified function and type parameters
    /// </summary>
    /// <param name="bc">The block count</param>
    /// <param name="bw">The block width representative</param>
    /// <param name="t">The block cell type representative</param>
    /// <typeparam name="N">The type that dermines block width</typeparam>
    /// <typeparam name="T">The type that determines cell width</typeparam>
    [MethodImpl(Inline)]
    public static BlockedGridStats<W,T> stats<W,T>(int bc, W bw = default, T t = default)
        where W : unmanaged, ITypeWidth
        where T : unmanaged
            => new (bc);
}
