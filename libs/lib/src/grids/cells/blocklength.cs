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
        /// Computes the number of T-cells that comprise a single 8-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8k)]
        public static int blocklength<T>(W8 w)
            where T : unmanaged
                => (int)size<T>();

        /// <summary>
        /// Computes the number of T-cells that comprise a single 16-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8x16k)]
        public static int blocklength<T>(W16 w)
            where T : unmanaged
                => 2/(int)size<T>();

        /// <summary>
        /// Computes the number of T-cells that comprise a single 32-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Numeric8x16x32k)]
        public static int blocklength<T>(W32 w)
            where T : unmanaged
                => 4/(int)size<T>();

        /// <summary>
        /// Computes the number of T-cells that comprise a single 64-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static int blocklength<T>(W64 w)
            where T : unmanaged
                => 8/(int)size<T>();

        /// <summary>
        /// Computes the number of T-cells that comprise a single 128-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int blocklength<T>(W128 w)
            where T : unmanaged
                => 16/(int)size<T>();

        /// <summary>
        /// Computes the number of T-cells that comprise a 256-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int blocklength<T>(W256 w)
            where T : unmanaged
                => 32/(int)size<T>();

        /// <summary>
        /// Computes the number of T-cells that comprise a 512-bit block
        /// </summary>
        /// <param name="w">The block width selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int blocklength<T>(W512 w)
            where T : unmanaged
                => 64/(int)size<T>();

        /// <summary>
        /// Computes the number of T-cells that comprise an W-width block
        /// </summary>
        /// <param name="w">The block width representative</param>
        /// <param name="t">The cell type representative</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static int blocklength<W,T>(W w = default, T t = default)
            where W : unmanaged, IDataWidth
            where T : unmanaged
                => (int)((NatCalc.wdiv(w, default(N8)))/size<T>());
    }
}