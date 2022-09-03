//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitGrid
    {
        /// <summary>
        /// Creates a 66-bit generic grid initialized with a specified fill-value
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="data">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16k)]
        public static BitGrid16<T> init<T>(N16 w, T data)
            where T : unmanaged
                => new BitGrid16<T>(gcpu.broadcast<T,ushort>(data));

        /// <summary>
        /// Creates a 32-bit generic grid initialized with a specified fill-value
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16x32k)]
        public static BitGrid32<T> init<T>(N32 w, T data)
            where T : unmanaged
                => new BitGrid32<T>(gcpu.broadcast<T,uint>(data));

        /// <summary>
        /// Creates a 64-bit generic grid initialized with a specified fill-value
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="data">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid64<T> init<T>(N64 w, T data)
            where T : unmanaged
                => new BitGrid64<T>(gcpu.broadcast<T,ulong>(data));

        /// <summary>
        /// Creates a populated 1x16 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16k)]
        public static BitGrid16<N1,N16,T> init<T>(N16 w, N1 m = default, N16 n = default, T d = default)
            where T : unmanaged
                => init16(m,n,d);

        /// <summary>
        /// Creates a populated 16x1 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16k)]
        public static BitGrid16<N16,N1,T> init<T>(N16 w, N16 m = default, N1 n = default, T d = default)
            where T : unmanaged
                => init16(m,n,d);

        /// <summary>
        /// Creates a populated 2x8 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16k)]
        public static BitGrid16<N2,N8,T> init<T>(N16 w, N2 m = default, N8 n = default, T d = default)
            where T : unmanaged
                => init16(m,n,d);

        /// <summary>
        /// Creates a populated 8x2 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16k)]
        public static BitGrid16<N8,N2,T> init<T>(N16 w, N8 m = default, N2 n = default, T d = default)
            where T : unmanaged
                => init16(m,n,d);

        /// <summary>
        /// Creates a populated 4x4 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16k)]
        public static BitGrid16<N4,N4,T> init<T>(N16 w, N4 m = default, N4 n = default, T d = default)
            where T : unmanaged
                => init16(m,n,d);

        /// <summary>
        /// Creates a populated 1x32 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16x32k)]
        public static BitGrid32<N1,N32,T> init<T>(N32 w, N1 m = default, N32 n = default, T d = default)
            where T : unmanaged
                => init32(m,n,d);

        /// <summary>
        /// Creates a populated 32x1 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16x32k)]
        public static BitGrid32<N32,N1,T> init<T>(N32 w, N32 m = default, N1 n = default, T d = default)
            where T : unmanaged
                => init32(m,n,d);

        /// <summary>
        /// Creates a populated 16x2 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16x32k)]
        public static BitGrid32<N16,N2,T> init<T>(N32 w, N16 m = default, N2 n = default, T d = default)
            where T : unmanaged
                => init32(m,n,d);

        /// Creates a populated 2x16 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16x32k)]
        public static BitGrid32<N2,N16,T> init<T>(N32 w, N2 m = default, N16 n = default, T d = default)
            where T : unmanaged
                => init32(m,n,d);

        /// <summary>
        /// Creates a populated 8x4 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16x32k)]
        public static BitGrid32<N8,N4,T> init<T>(N32 w, N8 m = default, N4 n = default, T d = default)
            where T : unmanaged
                => init32(m,n,d);

        /// <summary>
        /// Creates a populated 4x8 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(UInt8x16x32k)]
        public static BitGrid32<N4,N8,T> init<T>(N32 w, N4 m = default, N8 n = default, T d = default)
            where T : unmanaged
                => init32(m,n,d);

        /// <summary>
        /// Creates a populated 1x64 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid64<N1,N64,T> init<T>(N64 w, N1 m = default, N64 n = default, T d = default)
            where T : unmanaged
                => init64(m,n,d);

        /// <summary>
        /// Creates a populated 64x1 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid64<N64,N1,T> init<T>(N64 w, N64 m = default, N1 n = default, T d = default)
            where T : unmanaged
                => init64(m,n,d);

        /// <summary>
        /// Creates a populated 2x32 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid64<N2,N32,T> init<T>(N64 w, N2 m = default, N32 n = default, T d = default)
            where T : unmanaged
                => init64(m,n,d);

        /// <summary>
        /// Creates a populated 32x2 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid64<N32,N2,T> init<T>(N64 w, N32 m = default, N2 n = default, T d = default)
            where T : unmanaged
                => init64(m,n,d);

        /// <summary>
        /// Creates a populated 4x16 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid64<N4,N16,T> init<T>(N64 w, N4 m = default, N16 n = default, T d = default)
            where T : unmanaged
                => init64(m,n,d);

        /// <summary>
        /// Creates a populated 16x4 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The  cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid64<N16,N4,T> init<T>(N64 w, N16 m = default, N4 n = default, T d = default)
            where T : unmanaged
                => init64(m,n,d);

        /// <summary>
        /// Creates a populated 8x8 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid64<N8,N8,T> init<T>(N64 w, N8 m = default, N8 n = default, T d = default)
            where T : unmanaged
                => init64(m,n,d);

        /// <summary>
        /// Creates a populated 1x128 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid128<N1,N128,T> init<T>(N128 w, N1 m = default, N128 n = default, T d = default)
            where T : unmanaged
                => init128(m,n,d);

        /// <summary>
        /// Creates a populated 128x1 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid128<N128,N1,T> init<T>(N128 w, N128 m = default, N1 n = default, T d = default)
            where T : unmanaged
                => init128(m,n,d);

        /// <summary>
        /// Creates a populated 2x64 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid128<N2,N64,T> init<T>(N128 w, N2 m = default, N64 n = default,T d = default)
            where T : unmanaged
                => init128(m,n,d);

        /// <summary>
        /// Creates a populated 64x2 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid128<N64,N2,T> init<T>(N128 w, N64 m = default, N2 n = default, T d = default)
            where T : unmanaged
                => init128(m,n,d);

        /// <summary>
        /// Creates a populated 4x32 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid128<N4,N32,T> init<T>(N128 w, N4 m = default, N32 n = default, T d = default)
            where T : unmanaged
                => init128(m,n,d);

        /// <summary>
        /// Creates a populated 32x4 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid128<N32,N4,T> init<T>(N128 w, N32 m = default, N4 n = default, T d = default)
            where T : unmanaged
                => init128(m,n,d);

        /// <summary>
        /// Creates a populated 8x16 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid128<N8,N16,T> init<T>(N128 w, N8 m = default, N16 n = default, T d = default)
            where T : unmanaged
                => init128(m,n,d);

        /// <summary>
        /// Creates a populated 16x8 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid128<N16,N8,T> init<T>(N128 w, N16 m = default, N8 n = default, T d = default)
            where T : unmanaged
                => init128(m,n,d);

        /// <summary>
        /// Creates a populated 1x256 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid256<N1,N256,T> init<T>(N256 w, N1 m = default, N256 n = default, T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a populated 256x1 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid256<N256,N1,T> init<T>(N256 w, N256 m = default, N1 n = default, T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a populated 2x128 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static BitGrid256<N2,N128,T> init<T>(N256 w, N2 m = default, N128 n = default, T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a populated 128x2 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid256<N128,N2,T> init<T>(N256 w, N128 m = default, N2 n = default, T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a populated 4x64 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid256<N4,N64,T> init<T>(N256 w, N4 m = default, N64 n = default,T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a populated 64x4 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid256<N64,N4,T> init<T>(N256 w, N64 m = default, N4 n = default, T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a populated 8x32 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid256<N8,N32,T> init<T>(N256 w, N8 m = default, N32 n = default, T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a populated 32x8 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid256<N32,N8,T> init<T>(N256 w, N32 m = default, N8 n = default, T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a populated 16x16 grid
        /// </summary>
        /// <param name="w">The grid width selector</param>
        /// <param name="m">The row count representative</param>
        /// <param name="n">The col count representative</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitGrid256<N16,N16,T> init<T>(N256 w, N16 m = default, N16 n = default, T d = default)
            where T : unmanaged
                => init256(m,n,d);

        /// <summary>
        /// Creates a dynamically-sized grid of soft dimensions filled with specified data
        /// </summary>
        /// <param name="m">The number of grid rows</param>
        /// <param name="n">The number of grid columns</param>
        /// <param name="d">The fill data</param>
        /// <typeparam name="T">The segment type</typeparam>
        [MethodImpl(Inline), Init, Closures(Closure)]
        public static BitSpanBlocks256<T> init<T>(uint m, uint n, T d = default)
            where T : unmanaged
        {
            var w = W256.W;
            var blocks = Z0.SpanBlocks.alloc<T>(w, CellCalcs.blockcount<T>(w, m, n));
            broadcast(d, blocks);
            return new BitSpanBlocks256<T>(blocks,(int)m,(int)n);
        }

        /// <summary>
        /// Initializes 16-bit grid
        /// </summary>
        /// <param name="data">The grid data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        internal static BitGrid16<T> init16<T>(ushort data)
            where T : unmanaged
                => new BitGrid16<T>(data);

        /// <summary>
        /// Initializes 32-bit grid
        /// </summary>
        /// <param name="data">The grid data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        internal static BitGrid32<T> init32<T>(uint data)
            where T : unmanaged
                => new BitGrid32<T>(data);

        /// <summary>
        /// Initializes 64-bit grid
        /// </summary>
        /// <param name="data">The grid data</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        internal static BitGrid64<T> init64<T>(ulong data)
            where T : unmanaged
                => new BitGrid64<T>(data);
    }
}