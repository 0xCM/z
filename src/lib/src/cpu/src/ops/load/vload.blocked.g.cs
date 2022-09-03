//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        /// <summary>
        /// Loads a 128-bit vector from the first 128-bit source block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(in SpanBlock128<T> src)
            where T : unmanaged
                => vload(w128, src.Storage);

        /// <summary>
        /// Loads a 256-bit vector from the leading source block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(in SpanBlock256<T> src)
            where T : unmanaged
                => vload(w256, src.Storage);

        /// <summary>
        /// Loads a 512-bit vector from the leading source block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(in SpanBlock512<T> src)
            where T : unmanaged
                => vload(w512, src.Storage);

        /// <summary>
        /// Loads a block-identified 128-bit vector
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(in SpanBlock128<T> src, int block)
            where T : unmanaged
                => vload(src.BlockLead(block), out Vector128<T> x);

        /// <summary>
        /// Loads a block-identified 256-bit vector
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(in SpanBlock256<T> src, int block)
            where T : unmanaged
                => vload(src.BlockLead(block), out Vector256<T> x);

        /// <summary>
        /// Loads a block-identified 512-bit vector
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(in SpanBlock512<T> src, int block)
            where T : unmanaged
                => vload(src.BlockLead(block), out Vector512<T> x);
    }
}