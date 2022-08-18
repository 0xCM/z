//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CellCalcs
    {
        /// <summary>
        /// Calculates the number of cells that comprise a specified number of blocks
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellblocks<T>(W8 w, int blocks)
            where T : unmanaged
                => blocks * (int)cells<T>(w);

        /// <summary>
        /// Calculates the number of cells that comprise a specified number of blocks
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellblocks<T>(W16 w, int blocks)
            where T : unmanaged
                => blocks * (int)cells<T>(w);

        /// <summary>
        /// Calculates the number of cells that comprise a specified number of blocks
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellblocks<T>(W32 w, int blocks)
            where T : unmanaged
                => blocks * (int)cells<T>(w);

        /// <summary>
        /// Calculates the number of cells that comprise a specified number of blocks
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellblocks<T>(W64 w, int blocks)
            where T : unmanaged
                => blocks * (int)cells<T>(w);

        /// <summary>
        /// Calculates the number of cells that comprise a specified number of blocks
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellblocks<T>(W128 w, int blocks)
            where T : unmanaged
                => blocks * (int)cells<T>(w);

        /// <summary>
        /// Calculates the number of cells that comprise a specified number of blocks
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellblocks<T>(W256 w, int blocks)
            where T : unmanaged
                => blocks * (int)cells<T>(w);

        /// <summary>
        /// Calculates the number of cells that comprise a specified number of blocks
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int cellblocks<T>(W512 w, int blocks)
            where T : unmanaged
                => blocks * (int)cells<T>(w);
    }
}