//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct grids
{
    /// <summary>
    /// Computes the number of packed cells required to cover a rectangular area
    /// </summary>
    /// <param name="rows">The grid row count</param>
    /// <param name="cols">The grid col count</param>
    /// <param name="cellwidth">The storage cell width</param>
    [MethodImpl(Inline), Op]
    public static uint cellcount(uint rows, uint cols, uint cellwidth)
    {
        var sz = (uint)grids.size(rows, cols);
        var size = cellwidth/8u;
        return sz/size + (sz % size != 0u ? 1u : 0u);
    }

    /// <summary>
    /// Computes the number of cells required to cover a rectangular region predicated on the
    /// parametric cell type and supplied row/col dimensions
    /// </summary>
    /// <param name="rows">The number of rows in the grid</param>
    /// <param name="cols">The number of columns in the grid</param>
    /// <typeparam name="T">The storage cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint cellcount<T>(uint rows, uint cols)
        where T : unmanaged
            => cellcount(rows, cols, width<T>());

    /// <summary>
    /// Computes the number of segments required cover a grid as characterized by parametric type information
    /// </summary>
    /// <param name="m">The row count representative</param>
    /// <param name="n">The col count representative</param>
    /// <param name="t">The segment type zero representative</param>
    /// <typeparam name="M">The row type</typeparam>
    /// <typeparam name="N">The col type</typeparam>
    /// <typeparam name="T">The storage segment type</typeparam>
    [MethodImpl(Inline)]
    public static uint cellcount<M,N,T>(M m = default, N n = default, T t = default)
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => cellcount((uint)nat64u(m), (uint)nat64u(n), width<T>());
}
