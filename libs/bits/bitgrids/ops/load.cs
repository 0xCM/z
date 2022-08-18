//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial class BitGrid
    {
        /// <summary>
        /// Loads a 1x16 grid from the first 16-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid16<N1,N16,T> load<T>(in SpanBlock16<T> src, N1 m = default, N16 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 16x1 grid from the first 16-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid16<N16,N1,T> load<T>(in SpanBlock16<T> src, N16 m = default, N1 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 2x8 grid from the first 16-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid16<N8,N2,T> load<T>(in SpanBlock16<T> src, N2 m = default, N8 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 8x2 grid from the first 16-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid16<N8,N2,T> load<T>(in SpanBlock16<T> src, N8 m = default, N2 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 4x4 grid from the first 16-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid16<N4,N4,T> load<T>(in SpanBlock16<T> src, N4 m = default, N4 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 1x32 grid from the first 32-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid32<N1,N32,T> load<T>(in SpanBlock32<T> src, N1 m = default, N32 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 32x1 grid from the first 32-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid32<N32,N1,T> load<T>(in SpanBlock32<T> src, N32 m = default, N1 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 2x16 grid from the first 32-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid32<N2,N16,T> load<T>(in SpanBlock32<T> src, N2 m = default, N16 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 16x2 grid from the first 32-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid32<N16,N2,T> load<T>(in SpanBlock32<T> src, N16 m = default, N2 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 4x8grid from the first 32-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid32<N4,N8,T> load<T>(in SpanBlock32<T> src, N4 m = default, N8 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 8x4 grid from the first 32-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid32<N8,N4,T> load<T>(in SpanBlock32<T> src, N8 m = default, N4 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 1x64 grid from the first 64-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid64<N1,N64,T> load<T>(in SpanBlock64<T> src, N1 m = default, N64 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 64x1 grid from the first 64-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid64<N64,N1,T> load<T>(in SpanBlock64<T> src, N64 m = default, N1 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 2x32 grid from the first 64-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid64<N2,N32,T> load<T>(in SpanBlock64<T> src, N2 m = default, N32 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 32x2 grid from the first 64-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid64<N32,N2,T> load<T>(in SpanBlock64<T> src, N32 m = default, N2 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 4x16 grid from the first 64-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid64<N4,N16,T> load<T>(in SpanBlock64<T> src, N4 m = default, N16 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 16x4 grid from the first 64-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid64<N16,N4,T> load<T>(in SpanBlock64<T> src, N16 m = default, N4 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads an 8x8 grid from the first 64-bit source block
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid64<N8,N8,T> load<T>(in SpanBlock64<T> src, N8 m = default, N8 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 1x128 grid from a 128-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid128<N1,N128,T> load<T>(Vector128<T> src, N1 m = default, N128 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 128x1 grid from a 128-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid128<N128,N1,T> load<T>(Vector128<T> src,  N128 m = default, N1 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 2x64 grid from a 128-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid128<N2,N64,T> load<T>(Vector128<T> src, N2 m = default, N64 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 64x2 grid from a 128-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid128<N64,N2,T> load<T>(Vector128<T> src, N64 m = default, N2 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 4x32 grid from a 128-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid128<N4,N32,T> load<T>(Vector128<T> src, N4 m = default, N32 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 32x4 grid from a 128-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid128<N32,N4,T> load<T>(Vector128<T> src, N32 m = default, N4 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 8x16 grid from a 128-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid128<N8,N16,T> load<T>(Vector128<T> src, N8 m = default, N16 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 16x8 grid from a 128-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid128<N16,N8,T> load<T>(Vector128<T> src, N16 m = default, N8 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 1x256 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N1,N256,T> load<T>(Vector256<T> src, N1 m = default, N256 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 256x1 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N256,N1,T> load<T>(Vector256<T> src, N256 m = default, N1 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 2x128 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N2,N128,T> load<T>(Vector256<T> src, N2 m = default, N128 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 128x2 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N128,N2,T> load<T>(Vector256<T> src, N128 m = default, N2 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 4x64 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N4,N64,T> load<T>(Vector256<T> src, N4 m = default, N64 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 64x4 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N64,N4,T> load<T>(Vector256<T> src, N64 m = default, N4 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Forms a 8x32 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N8,N32,T> load<T>(Vector256<T> src, N8 m = default, N32 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 32x8 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N32,N8,T> load<T>(Vector256<T> src, N32 m = default, N8 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a 16x16 grid from a 256-bit vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The grid cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitGrid256<N16,N16,T> load<T>(Vector256<T> src, N16 m = default, N16 n = default)
            where T : unmanaged
                => src;

        /// <summary>
        /// Loads a generic bitgrid from a 256-bit block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="map">The grid map</param>
        /// <typeparam name="T">The segment type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitSpanBlocks256<T> load<T>(in SpanBlock256<T> src, ushort rows, ushort cols)
            where T : unmanaged
                => new BitSpanBlocks256<T>(src, rows, cols);

        /// <summary>
        /// Loads a natural bitgrid from a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="zero">The storage representative</param>
        /// <typeparam name="M">The row count type</typeparam>
        /// <typeparam name="N">The col type</typeparam>
        /// <typeparam name="T">The storage segment type</typeparam>
        [MethodImpl(Inline)]
        public static BitGrid<M,N,T> load<M,N,T>(SpanBlock256<T> src, M m = default, N n = default, T zero = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid<M, N, T>(src);

        public static BitGrid<M,N,T> load<M,N,T>(M m, N n, SpanBlock256<T> src)
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
            where T : unmanaged
                => new BitGrid<M,N,T>(src);
    }
}