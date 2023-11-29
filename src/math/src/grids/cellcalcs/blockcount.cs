//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct CellCalcs
{
    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8k)]
    public static int blockcount<T>(W8 w, int cells)
        where T : unmanaged
            => cells/blocklength<T>(w);

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8x16k)]
    public static int blockcount<T>(W16 w, int cells)
        where T : unmanaged
            => cells/blocklength<T>(w);

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8x16x32k)]
    public static int blockcount<T>(W32 w, int cells)
        where T : unmanaged
            => cells/blocklength<T>(w);

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static int blockcount<T>(W64 w, int cells)
        where T : unmanaged
            => cells/blocklength<T>(w);

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static int blockcount<T>(W128 w, int cells)
        where T : unmanaged
            => cells/blocklength<T>(w);

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static int blockcount<T>(W256 w, int cells)
        where T : unmanaged
            => cells/blocklength<T>(w);

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static int blockcount<T>(W512 w, int cells)
        where T : unmanaged
            => cells/blocklength<T>(w);

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// and reveals the number of cells that remain uncovered
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <param name="remainder">The number of cells that remain uncovered</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8k)]
    public static int blockcount<T>(W8 w, int length, out int remainder)
        where T : unmanaged
    {
        remainder = length % blocklength<T>(w);
        return length/blocklength<T>(w);
    }

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// and reveals the number of cells that remain uncovered
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <param name="remainder">The number of cells that remain uncovered</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8x16k)]
    public static int blockcount<T>(W16 w, int length, out int remainder)
        where T : unmanaged
    {
        remainder = length % blocklength<T>(w);
        return length/blocklength<T>(w);
    }

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// and reveals the number of cells that remain uncovered
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <param name="remainder">The number of cells that remain uncovered</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Numeric8x16x32k)]
    public static int blockcount<T>(W32 w, int length, out int remainder)
        where T : unmanaged
    {
        remainder = length % blocklength<T>(w);
        return length/blocklength<T>(w);
    }

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// and reveals the number of cells that remain uncovered
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <param name="remainder">The number of cells that remain uncovered</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static int blockcount<T>(W64 w, int length, out int remainder)
        where T : unmanaged
    {
        remainder = length % blocklength<T>(w);
        return length/blocklength<T>(w);
    }

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// and reveals the number of cells that remain uncovered
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <param name="remainder">The number of cells that remain uncovered</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static int blockcount<T>(W128 w, int length, out int remainder)
        where T : unmanaged
    {
        remainder = length % blocklength<T>(w);
        return length/blocklength<T>(w);
    }

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// and reveals the number of cells that remain uncovered
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <param name="remainder">The number of cells that remain uncovered</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static int blockcount<T>(W256 w, int length, out int remainder)
        where T : unmanaged
    {
        remainder = length % blocklength<T>(w);
        return length/blocklength<T>(w);
    }

    /// <summary>
    /// Computes the whole number of blocks that cover a specified count of T-cells
    /// and reveals the number of cells that remain uncovered
    /// </summary>
    /// <param name="w">The block width</param>
    /// <param name="cells">The cell count</param>
    /// <param name="remainder">The number of cells that remain uncovered</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static int blockcount<T>(W512 w, int length, out int remainder)
        where T : unmanaged
    {
        remainder = length % blocklength<T>(w);
        return length/blocklength<T>(w);
    }

    /// <summary>
    /// Computes the minimum number of 256-bit blocks that can hold a table of data
    /// </summary>
    /// <param name="srclen">The length of the source data</param>
    /// <typeparam name="M">The row type </typeparam>
    /// <typeparam name="N">The column type</typeparam>
    /// <typeparam name="T">The scalar type</typeparam>
    [MethodImpl(Inline)]
    public static int blockcount<M,N,T>(N256 w)
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {
        var srclen = (int)NatCalc.mul<M,N>();
        var bz = blockcount<T>(w,srclen, out int remainder);
        return remainder == 0 ? bz : bz + 1;
    }

    /// <summary>
    /// Computes the minimum number of 512-bit blocks that can hold a table of data
    /// </summary>
    /// <param name="srclen">The length of the source data</param>
    /// <typeparam name="M">The row type </typeparam>
    /// <typeparam name="N">The column type</typeparam>
    /// <typeparam name="T">The scalar type</typeparam>
    [MethodImpl(Inline)]
    public static int blockcount<M,N,T>(W512 w)
        where M : unmanaged, ITypeWidth
        where N : unmanaged, ITypeWidth
        where T : unmanaged
    {
        var srclen = ((int)Widths.type<M>()) * ((int)Widths.type<N>());
        var bz = blockcount<T>(w,srclen, out int remainder);
        return remainder == 0 ? bz : bz + 1;
    }

    /// <summary>
    /// Calculates the number of 256-bit blocks reqired to cover a grid with a specified number of rows/cols
    /// </summary>
    /// <param name="w">The block width selctor</param>
    /// <param name="rows">The row count</param>
    /// <param name="cols">The col count</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ulong blockcount<T>(W256 w, uint rows, uint cols)
        where T : unmanaged
            => cellcover<T>(w, gridcells<T>(rows,cols));

    /// <summary>
    /// Calculates the number of 256-bit blocks reqired to cover a grid with natural dimensions
    /// </summary>
    /// <param name="w">The block width selctor</param>
    /// <param name="m">The row count representative</param>
    /// <param name="n">The col count representative</param>
    /// <param name="t">The cell type representative</param>
    /// <typeparam name="M">The row count type</typeparam>
    /// <typeparam name="N">The col count type</typeparam>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline)]
    public static ulong blockcount<M,N,T>(N256 w, M m = default, N n = default, T t = default)
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => cellcover<T>(w, gridcells<T>(nat32u(m), nat32u(n)));
}
