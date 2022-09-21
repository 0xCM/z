//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct grids
    {
        /// <summary>
        /// Computes the number of bytes that can be covered by a specified number of cells of parametric type
        /// </summary>
        /// <param name="cells">The number of cells</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int bytes<T>(int cells)
            where T : unmanaged
                => (int)(cells * size<T>());

        /// <summary>
        /// Computes the number of bytes required to cover a grid, predicated on row/col counts
        /// </summary>
        /// <param name="rows">The number of grid rows</param>
        /// <param name="cols">The number of grid columns</param>
        [MethodImpl(Inline), Op]
        public static int bytes(int rows, int cols)
        {
            var points = rows*cols;
            return (points >> 3) + (points % 8 != 0 ? 1 : 0);
        }

        /// <summary>
        /// Computes the number of bytes required to cover a grid, predicated on row/col counts
        /// </summary>
        /// <param name="rows">The number of grid rows</param>
        /// <param name="cols">The number of grid columns</param>
        [MethodImpl(Inline), Op]
        public static int bytes(ulong rows, ulong cols)
        {
            var points = (int)(rows*cols);
            return (points >> 3) + (points % 8 != 0 ? 1 : 0);
        }
    }
}