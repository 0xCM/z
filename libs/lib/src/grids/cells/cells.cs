//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct CellCalcs
    {
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
}