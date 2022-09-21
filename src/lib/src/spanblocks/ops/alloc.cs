//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CellCalcs;

    partial struct SpanBlocks
    {
        /// <summary>
        /// Allocates a specified number of 8-bit blocks, filled with an optional pattern
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock8<T> alloc<T>(W8 w, ulong count)
            where T : unmanaged
                => new SpanBlock8<T>(new T[count * (ulong)blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 16-bit blocks, filled with an optional pattern
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock16<T> alloc<T>(W16 w, ulong count)
            where T : unmanaged
                => new SpanBlock16<T>(new T[count * (ulong)blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 32-bit blocks, filled with an optional pattern
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock32<T> alloc<T>(W32 w, ulong count)
            where T : unmanaged
                => new SpanBlock32<T>(new T[count * (ulong)blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 64-bit blocks, filled with an optional pattern
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock64<T> alloc<T>(W64 w, ulong count)
            where T : unmanaged
                => new SpanBlock64<T>(new T[count * (ulong)blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 128-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock128<T> alloc<T>(W128 w, ulong count)
            where T : unmanaged
                => new SpanBlock128<T>(new T[count * (ulong)blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 256-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock256<T> alloc<T>(W256 w, ulong count)
            where T : unmanaged
                => new SpanBlock256<T>(new T[count * (ulong)blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 512-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="blocks">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock512<T> alloc<T>(W512 w, ulong blocks)
            where T : unmanaged
                => new SpanBlock512<T>(new T[blocks * (ulong)blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 8-bit blocks, filled with an optional pattern
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock8<T> alloc<T>(W8 w, long count)
            where T : unmanaged
                => new SpanBlock8<T>(new T[count * blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 16-bit blocks, filled with an optional pattern
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock16<T> alloc<T>(W16 w, long count)
            where T : unmanaged
                => new SpanBlock16<T>(new T[count * blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 32-bit blocks, filled with an optional pattern
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock32<T> alloc<T>(W32 w, long count)
            where T : unmanaged
                => new SpanBlock32<T>(new T[count * blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 64-bit blocks, filled with an optional pattern
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock64<T> alloc<T>(W64 w, long count)
            where T : unmanaged
                => new SpanBlock64<T>(new T[count * blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 128-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="count">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock128<T> alloc<T>(W128 w, long count)
            where T : unmanaged
                => new SpanBlock128<T>(new T[count * blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 256-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="blocks">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock256<T> alloc<T>(W256 w, long blocks)
            where T : unmanaged
                => new SpanBlock256<T>(new T[blocks * blocklength<T>(w)]);

        /// <summary>
        /// Allocates a specified number of 512-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="blocks">The block allocation count</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static SpanBlock512<T> alloc<T>(W512 w, long blocks)
            where T : unmanaged
                => new SpanBlock512<T>(new T[blocks * blocklength<T>(w)]);

        /// <summary>
        /// Allocates the minimum number of blocks required to block-align tabular data in 8-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        public static SpanBlock8<T> alloc<T>(W8 w, ulong m, ulong n)
            where T : unmanaged
                => alloc<T>(w, cellcover<T>(w, m*n));

        /// <summary>
        /// Allocates the minimum number of blocks required to block-align tabular data in 16-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        public static SpanBlock16<T> alloc<T>(W16 w, ulong m, ulong n)
            where T : unmanaged
                => alloc<T>(w, cellcover<T>(w, m*n));

        /// <summary>
        /// Allocates the minimum number of blocks required to block-align tabular data in 32-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        public static SpanBlock32<T> alloc<T>(W32 w, ulong m, ulong n)
            where T : unmanaged
                => alloc<T>(w, cellcover<T>(w, m*n));

        /// <summary>
        /// Allocates the minimum number of blocks required to block-align tabular data in 64-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        public static SpanBlock64<T> alloc<T>(W64 w, ulong m, ulong n)
            where T : unmanaged
                => alloc<T>(w, cellcover<T>(w, m*n));

        /// <summary>
        /// Allocates the minimum number of blocks required to block-align tabular data in 64-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        public static SpanBlock128<T> alloc<T>(W128 w, ulong m, ulong n)
            where T : unmanaged
                => alloc<T>(w, cellcover<T>(w, m*n));

        /// <summary>
        /// Allocates the minimum number of blocks required to block-align tabular data in 256-bit blocks
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <param name="m">The row count</param>
        /// <param name="n">The col count</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        public static SpanBlock256<T> alloc<T>(W256 w, ulong m, ulong n)
            where T : unmanaged
                => alloc<T>(w, cellcover<T>(w, m*n));
    }
}