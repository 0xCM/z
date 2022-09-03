//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cells
    {
        [MethodImpl(Inline), Op]
        public static Cell128 cell128(ulong lo, ulong hi)
            => new Cell128(lo, hi);

        /// <summary>
        /// Presents a 128-bit vector as a 128-bit cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Cell128 cell128<T>(Vector128<T> src)
            where T : unmanaged
                => @as<Vector128<T>,Cell128>(src);
    }
}