//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static gcpu;

    partial struct vmask
    {
        /// <summary>
        /// Clears a sequence of bits from each component
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="start">The cell-relative start index</param>
        /// <param name="count">The number of bits to disable</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vdisable<T>(Vector128<T> src, byte start, byte count)
            where T : unmanaged
                => vand(vbroadcast(w128, eraser<T>(start, count)), src);

        /// <summary>
        /// Clears a sequence of bits from each component
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="start">The cell-relative start index</param>
        /// <param name="count">The number of bits to disable</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline),Op, Closures(Integers)]
        public static Vector256<T> vdisable<T>(Vector256<T> src, byte start, byte count)
            where T : unmanaged
                => vand(vbroadcast(w256, eraser<T>(start,count)), src);
    }
}