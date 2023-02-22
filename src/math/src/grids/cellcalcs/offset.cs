//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;


    partial struct CellCalcs
    {
        /// <summary>
        /// Computes the 0-based linear index determined by column width and a row/col coordinate
        /// </summary>
        /// <param name="colwidth">The bit-width of a grid column</param>
        /// <param name="row">The 0-based row index</param>
        /// <param name="col">The 0-based col index</param>
        [MethodImpl(Inline), Op]
        public static uint offset(uint colwidth, uint row, uint col)
            => row*colwidth + col;

        /// <summary>
        /// Computes the 0-based linear index determined by column width and a row/col coordinate
        /// </summary>
        /// <param name="colwidth">The bit-width of a grid column</param>
        /// <param name="row">The 0-based row index</param>
        /// <param name="col">The 0-based col index</param>
        [MethodImpl(Inline), Op]
        public static uint offset<T>(GridDim<T> dim, uint row, uint col)
            where T : unmanaged
                => offset(uint32(dim.ColCount), row, col);

        /// <summary>
        /// Computes the 0-based linear index determined by a row/col coordinate
        /// </summary>
        /// <param name="row">The 0-based row index</param>
        /// <param name="col">The 0-based col index</param>
        [MethodImpl(Inline), Op]
        public static uint offset(in GridMetrics src, uint row, uint col)
            => offset(src.ColCount, row, col);

        /// <summary>
        /// Computes the 0-based linear index determined by column width and a row/col coordinate
        /// </summary>
        /// <param name="colwidth">The bit-width of a grid column</param>
        /// <param name="row">The 0-based row index</param>
        /// <param name="col">The 0-based col index</param>
        [MethodImpl(Inline), Op]
        public static uint offset(GridDim dim, CellIndex point)
            => point.Row*dim.N + point.Col;

        /// <summary>
        /// Computes the 0-based linear index determined by column width and a row/col coordinate
        /// </summary>
        /// <param name="colwidth">The bit-width of a grid column</param>
        /// <param name="row">The 0-based row index</param>
        /// <param name="col">The 0-based col index</param>
        [MethodImpl(Inline), Op]
        public static uint offset(GridDim dim, uint row, uint col)
            => dim.N*row + col;

        /// <summary>
        /// Computes the 0-based linear index determined by a row/col coordinate and natural column width
        /// </summary>
        /// <param name="row">The grid row</param>
        /// <param name="col">The grid columns</param>
        /// <typeparam name="N">The grid column type</typeparam>
        [MethodImpl(Inline)]
        public static uint offset<W>(uint row, uint col, W w = default)
            where W : unmanaged, IDataWidth
                => (uint)row * (uint)DataWidths.measure(w) + col;
    }
}