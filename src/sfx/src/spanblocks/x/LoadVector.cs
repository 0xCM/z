//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XSb
    {

        /// <summary>
        /// Loads a 128-bit vector from the first 128-bit block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> LoadVector<T>(this SpanBlock128<T> src)
            where T : unmanaged
                => SpanBlocks.vload(src, 0);

        /// <summary>
        /// Loads a 256-bit vector from the first 256-bit block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this SpanBlock256<T> src)
            where T : unmanaged
                => SpanBlocks.vload(src);

        /// <summary>
        /// Loads a 512-bit vector from the first 512-bit block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector512<T> LoadVector<T>(this in SpanBlock512<T> src)
            where T : unmanaged
                => SpanBlocks.vload(src);

        /// <summary>
        /// Loads a block-identified 128-bit vector
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> LoadVector<T>(this SpanBlock128<T> src, int block)
            where T : unmanaged
                => SpanBlocks.vload(src, block);

        /// <summary>
        /// Loads a 256-bit vector from an index-identified block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this SpanBlock256<T> src, int block)
            where T : unmanaged
                => SpanBlocks.vload(src,block);

        /// <summary>
        /// Loads a 256-bit vector from an index-identified block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> LoadVector<T>(this SpanBlock256<T> src, uint block)
            where T : unmanaged
                => SpanBlocks.vload(src, (int)block);

        /// <summary>
        /// Loads 512-bit vector from an index-identified block
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The primitive type</typeparam>
        [MethodImpl(Inline)]
        public static Vector512<T> LoadVector<T>(this in SpanBlock512<T> src, int block)
            where T : unmanaged
                => SpanBlocks.vload(src,block);
    }
}