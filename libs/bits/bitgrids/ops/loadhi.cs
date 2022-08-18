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
        /// Forms a 1x64 grid from the lower 64 bits of a vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <param name="fill">The value with which to fill the grid</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<N1,N64,T> loadhi<T>(Vector128<T> src, N1 m = default, N64 n = default)
            where T : unmanaged
                => src.AsUInt64().GetElement(1);

        /// <summary>
        /// Forms a 64x1 grid from the lower 64 bits of a vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <param name="fill">The value with which to fill the grid</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<N64,N1,T> loadhi<T>(Vector128<T> src, N64 m = default, N1 n = default)
            where T : unmanaged
                => src.AsUInt64().GetElement(1);

        /// <summary>
        /// Forms a 2x32 grid from the lower 64 bits of a vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <param name="fill">The value with which to fill the grid</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<N2,N32,T> loadhi<T>(Vector128<T> src, N2 m = default, N32 n = default)
            where T : unmanaged
                => src.AsUInt64().GetElement(1);

        /// <summary>
        /// Forms a 32x2 grid from the lower 64 bits of a vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <param name="fill">The value with which to fill the grid</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<N32,N2,T> loadhi<T>(Vector128<T> src, N32 m = default, N2 n = default)
            where T : unmanaged
                => src.AsUInt64().GetElement(1);

        /// <summary>
        /// Forms a 4x16 grid from the lower 64 bits of a vector
        /// </summary>
        /// <param name="block">The block size selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <param name="fill">The value with which to fill the grid</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<N4,N16,T> loadhi<T>(Vector128<T> src, N4 m = default, N16 n = default)
            where T : unmanaged
                => src.AsUInt64().GetElement(1);

        /// <summary>
        /// Forms a 16x4 from the lower 64 bits of a vector
        /// </summary>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <param name="fill">The value with which to fill the grid</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<N16,N4,T> loadhi<T>(Vector128<T> src, N16 m = default, N4 n = default)
            where T : unmanaged
                => src.AsUInt64().GetElement(1);

        /// <summary>
        /// Forms a 8x8 grid from the lower 64 bits of a vector
        /// </summary>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <param name="fill">The value with which to fill the grid</param>
        /// <typeparam name="T">The primal cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<N8,N8,T> loadhi<T>(Vector128<T> src, N8 m = default, N8 n = default)
            where T : unmanaged
                => src.AsUInt64().GetElement(1);
    }
}