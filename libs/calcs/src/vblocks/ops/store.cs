//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct vblocks
    {
        /// <summary>
        /// Deposits vector content to an index-identified block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(Vector128<T> src, uint block, SpanBlock128<T> dst)
            where T : unmanaged
                => gcpu.vstore(src, ref dst.BlockLead(block));

        /// <summary>
        /// Deposits vector content to an index-identified block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(Vector256<T> src, uint block, SpanBlock256<T> dst)
            where T : unmanaged
                => gcpu.vstore(src, ref dst.BlockLead(block));

        /// <summary>
        /// Deposits vector content to an index-identified block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void store<T>(Vector512<T> src, uint block, SpanBlock512<T> dst)
            where T : unmanaged
                => gcpu.vstore(src, ref dst.BlockLead(block));
    }
}