//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    unsafe partial class Bytes
    {
        /// <summary>
        /// Returns a sequence of 8-bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N2 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,2));

        /// <summary>
        /// Returns a sequence of 8-bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N4 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,4));

        /// <summary>
        /// Returns a sequence of 8-bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N8 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,8));

        /// <summary>
        /// Returns a sequence of 8-bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N16 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,16));

        /// <summary>
        /// Returns a sequence of 8-bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N32 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,32));

        /// <summary>
        /// Returns a sequence of 8-bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N64 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,64));

        /// <summary>
        /// Returns a sequence of 8-bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N128 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,128));

        /// <summary>
        /// Returns a sequence of 8-bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N256 n)
            where T : unmanaged
                => recover<byte,T>(B256x8u);

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W16 w, N2 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x16u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W16 w, N4 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x16u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W16 w, N8 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x16u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W16 w, N16 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x16u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W16 w, N32 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x16u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W16 w, N64 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x16u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W16 w, N128 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x16u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W16 w, N256 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x16u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W32 w, N2 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x32u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W32 w, N4 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x32u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W32 w, N8 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x32u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W32 w, N16 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x32u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W32 w, N32 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x32u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W32 w, N64 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x32u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W32 w, N128 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x32u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W32 w, N256 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x32u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W64 w, N2 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x64u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W64 w, N4 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x64u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W64 w, N8 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x64u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W64 w, N16 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x64u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W64 w, N32 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x64u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W64 w, N64 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x64u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W64 w, N128 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x64u, 0, n));

        /// <summary>
        /// Returns a sequence of <paramref name='w'/> bit values of length <paramref name='n'/> expressed as a sequence of <typeparamref name='T'/> cells
        /// </summary>
        /// <param name="n">The source sequence length</param>
        /// <param name="w">The source width selector</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(W64 w, N256 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x64u, 0, n));
    }
}