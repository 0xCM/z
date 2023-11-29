//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct CellCalcs
{
    /// <summary>
    /// Determines whether a specified number of elements can be evenly covered by 8-bit segments
    /// </summary>
    /// <param name="count">The element count</param>
    /// <typeparam name="T">The block constituent type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers8x64k)]
    public static bool aligned<T>(W8 w, int count)
        where T : unmanaged
            => count % blocklength<T>(w) == 0;

    /// <summary>
    /// Determines whether a specified number of elements can be evenly covered by 16-bit segments
    /// </summary>
    /// <param name="count">The element count</param>
    /// <typeparam name="T">The block constituent type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers8x64k)]
    public static bool aligned<T>(W16 w, int count)
        where T : unmanaged
            => count % blocklength<T>(w) == 0;

    /// <summary>
    /// Determines whether a specified number of elements can be evenly covered by 32-bit segments
    /// </summary>
    /// <param name="count">The element count</param>
    /// <typeparam name="T">The block constituent type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers8x64k)]
    public static bool aligned<T>(W32 w, int count)
        where T : unmanaged
            => count % blocklength<T>(w) == 0;

    /// <summary>
    /// Determines whether a specified number of elements can be evenly covered by 64-bit segments
    /// </summary>
    /// <param name="count">The element count</param>
    /// <typeparam name="T">The block constituent type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers8x64k)]
    public static bool aligned<T>(W64 w, int count)
        where T : unmanaged
            => count % blocklength<T>(w) == 0;

    /// <summary>
    /// Determines whether a specified number of elements can be evenly covered by 128-bit segments
    /// </summary>
    /// <param name="count">The element count</param>
    /// <typeparam name="T">The block constituent type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers8x64k)]
    public static bool aligned<T>(W128 w, int count)
        where T : unmanaged
            => count % blocklength<T>(w) == 0;

    /// <summary>
    /// Determines whether a specified number of elements can be evenly covered by 256-bit segments
    /// </summary>
    /// <param name="count">The element count</param>
    /// <typeparam name="T">The block element type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers8x64k)]
    public static bool aligned<T>(W256 w, int count)
        where T : unmanaged
            => count % blocklength<T>(w) == 0;

    /// <summary>
    /// Determines whether a specified number of elements can be evenly covered by 512-bit segments
    /// </summary>
    /// <param name="count">The element count</param>
    /// <typeparam name="T">The block element type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers8x64k)]
    public static bool aligned<T>(W512 w, int count)
        where T : unmanaged
            => count % blocklength<T>(w) == 0;

    /// <summary>
    /// Computes the minimum number of w-cells required to evenly cover a grid of bit-dimensions mxn
    /// </summary>
    /// <param name="w">The cellwidth</param>
    /// <param name="rows">The number of grid rows</param>
    /// <param name="cols">The number of grid columns</param>
    [MethodImpl(Inline), Op]
    public static uint aligned(uint m, uint n, uint w)
    {
        var cells = m*n;
        var d = cells/w;
        var r = cells%w;
        return d + (r != 0 ? 1u : 0u);
    }
}
