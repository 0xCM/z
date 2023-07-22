//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        const NumericKind Closure = UnsignedInts;
        
        /// <summary>
        /// Stores vector content to a caller-supplied block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe void StoreTo<T>(this Vector128<T> src, SpanBlock128<T> dst)
            where T : unmanaged
                => SpanBlocks.vstore(src, dst);

        /// <summary>
        /// Stores vector content to a specified block in a blocked container
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        /// <param name="block">The 0-based block index at which storage should begin</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe void StoreTo<T>(this Vector128<T> src, SpanBlock128<T> dst, int block)
            where T : unmanaged
                => SpanBlocks.vstore(src, dst, block);

        /// <summary>
        /// Stores vector content to a caller-supplied block
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe void StoreTo<T>(this Vector256<T> src, SpanBlock256<T> dst)
            where T : unmanaged
                => SpanBlocks.vstore(src, dst);

        /// <summary>
        /// Stores vector content to a specified block in a blocked container
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        /// <param name="block">The 0-based block index at which storage should begin</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe void StoreTo<T>(this Vector256<T> src, SpanBlock256<T> dst, int block)
            where T : unmanaged
                => SpanBlocks.vstore(src, dst, block);
    }
}