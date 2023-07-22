//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vgcpu
    {
        /// <summary>
        /// Extracts the lower 128-bit lane from a source vector
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="index">The lane selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vlane<T>(Vector256<T> src, N0 index)
            where T : unmanaged
                => Vector256.GetLower(src);

        /// <summary>
        /// Extracts the lower 128-bit lane from a source vector
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="index">The lane selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vlane<T>(Vector256<T> src, N1 index)
            where T : unmanaged
             => Vector256.GetUpper(src);

        /// <summary>
        /// Extracts the lower 128-bit lane from a source vector
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="index">The lane selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vlane<T>(Vector256<T> src, [Imm] LaneIndex index)
            where T : unmanaged
             => index == 0 ? vlane(src, n0) : vlane(src, n1);
    }
}