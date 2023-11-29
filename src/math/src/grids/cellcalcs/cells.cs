//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct CellCalcs
{
    /// <summary>
    /// Computes the number of bytes required to cover a rectangular area, predicated on natural row/col counts
    /// </summary>
    /// <param name="m">The row count representative</param>
    /// <param name="n">The col count representative</param>
    /// <typeparam name="M">The row type</typeparam>
    /// <typeparam name="N">The col type</typeparam>
    [MethodImpl(Inline)]
    public static ByteSize gridsize<M,N,T>(M m = default, N n = default, T t = default)
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => NatCalc.mul(m,n)*size<T>();

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

    /// <summary>
    /// Computes the number of packed cells required to cover a rectangular area
    /// </summary>
    /// <param name="rows">The grid row count</param>
    /// <param name="cols">The grid col count</param>
    /// <param name="cellwidth">The storage cell width</param>
    [MethodImpl(Inline), Op]
    public static uint gridcells(uint rows, uint cols, uint cellwidth)
    {
        var sz = (uint)bytes(rows, cols);
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
    public static uint gridcells<T>(uint rows, uint cols)
        where T : unmanaged
            => gridcells(rows, cols, width<T>());

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
    public static uint gridcells<M,N,T>(M m = default, N n = default, T t = default)
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => gridcells((uint)nat64u(m), (uint)nat64u(n), width<T>());

    /// <summary>
    /// Computes the whole number of <typeparamref name='T'/> cells covered by a specified <see cref='MemoryRange'/>
    /// </summary>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint cells<T>(MemoryRange src)
        => (uint)(src.ByteCount/size<T>());

    /// <summary>
    /// Computes the number of <typeparamref name='T'/> cells that comprise a single 8-bit block
    /// </summary>
    /// <param name="w">The block width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8k)]
    public static uint cells<T>(W8 w)
        where T : unmanaged
            => size<T>();

    /// <summary>
    /// Computes the number of <typeparamref name='T'/> cells that comprise a single 16-bit block
    /// </summary>
    /// <param name="w">The block width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8x16k)]
    public static uint cells<T>(W16 w)
        where T : unmanaged
            => 2/size<T>();

    /// <summary>
    /// Computes the number of <typeparamref name='T'/> cells that comprise a single 32-bit block
    /// </summary>
    /// <param name="w">The block width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8x16x32k)]
    public static uint cells<T>(W32 w)
        where T : unmanaged
            => 4/size<T>();

    /// <summary>
    /// Computes the number of <typeparamref name='T'/> cells that comprise a single 64-bit block
    /// </summary>
    /// <param name="w">The block width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint cells<T>(W64 w)
        where T : unmanaged
            => 8/size<T>();

    /// <summary>
    /// Computes the number of <typeparamref name='T'/> cells that comprise a single 128-bit block
    /// </summary>
    /// <param name="w">The block width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint cells<T>(W128 w)
        where T : unmanaged
            => 16/size<T>();

    /// <summary>
    /// Computes the number of <typeparamref name='T'/> cells that comprise a 256-bit block
    /// </summary>
    /// <param name="w">The block width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint cells<T>(W256 w)
        where T : unmanaged
            => 32/size<T>();

    /// <summary>
    /// Computes the number of <typeparamref name='T'/> cells that comprise a 512-bit block
    /// </summary>
    /// <param name="w">The block width selector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint cells<T>(W512 w)
        where T : unmanaged
            => 64/size<T>();
}
