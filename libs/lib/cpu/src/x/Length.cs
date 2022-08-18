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

    partial class XTend
    {
        /// <summary>
        /// Returns the number of source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int Length<T>(this Vector128<T> src)
            where T : unmanaged
                => cpu.vcount<T>(w128);

        /// <summary>
        /// Returns the number of source vector components
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int Length<T>(this Vector256<T> src)
            where T : unmanaged
                => cpu.vcount<T>(w256);
    }
}