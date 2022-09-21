//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct expr
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static GridSpec gridspec<T>(uint rows, uint cols)
            where T : unmanaged
                => gridspec((ushort)rows, (ushort)cols, (ushort)width<T>());

        /// <summary>
        /// Defines a grid specification predicated on specified row count, col count and bit width
        /// </summary>
        /// <param name="rows">The number of rows in the grid</param>
        /// <param name="cols">The number of columns in the grid</param>
        /// <param name="segwidth">The width of a grid cell</param>
        [MethodImpl(Inline), Op]
        static GridSpec gridspec(ushort rows, ushort cols, ushort segwidth)
        {
            var bytes = (uint)gridsize(rows, cols);
            var bits = bytes*8;
            var segs = grids.gridcells(rows, cols, segwidth);
            return new GridSpec(rows, cols, segwidth, bytes, bits, segs);
        }
    }
}