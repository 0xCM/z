//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct grids
{
    /// <summary>
    /// Computes the 0-based linear index determined by a row/col coordinate
    /// </summary>
    /// <param name="row">The 0-based row index</param>
    /// <param name="col">The 0-based col index</param>
    [MethodImpl(Inline), Op]
    public static uint offset(in GridMetrics src, uint row, uint col)
        => CellCalcs.offset(src.ColCount, row, col);
}