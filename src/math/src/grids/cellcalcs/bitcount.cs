//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct CellCalcs
{
    /// <summary>
    /// Computes the number of bits covered by a specified cell count and width
    /// </summary>
    /// <param name="cellcount">The number of allocated cells</param>
    /// <param name="cellwidth">The bit-width of a cell</param>
    [MethodImpl(Inline), Op]
    public static uint bitcount(uint cellcount, uint cellwidth)
        => cellcount * cellwidth;

    /// <summary>
    /// Computes  the number of bits covered by a specified cell count of parametric type
    /// </summary>
    /// <param name="cellcount">The number of allocated cells</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static uint bitcount<T>(uint cellcount)
        => bitcount(cellcount, width<T>());
}
