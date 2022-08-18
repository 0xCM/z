//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XSb
    {
        /// <summary>
        /// Presents 32-bit blocks as 8-bit blocks
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="w">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock8<T> Reblock<T>(this in SpanBlock32<T> src, W8 w)
             where T : unmanaged
                => new SpanBlock8<T>(src.Storage);

        /// <summary>
        /// Presents 32-bit blocks as 16-bit blocks
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="w">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock16<T> Reblock<T>(this in SpanBlock32<T> src, W16 w)
             where T : unmanaged
                => new SpanBlock16<T>(src.Storage);

        /// <summary>
        /// Presents 32-bit blocks as 64-bit blocks
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="w">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock64<T> Reblock<T>(this in SpanBlock32<T> src, W64 w)
             where T : unmanaged
                => new SpanBlock64<T>(src.Storage);

        /// <summary>
        /// Presents 32-bit blocks as 128-bit blocks
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="w">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock128<T> Reblock<T>(this in SpanBlock32<T> src, W128 w)
             where T : unmanaged
                => new SpanBlock128<T>(src.Storage);

        /// <summary>
        /// Presents 32-bit blocks as 256-bit blocks
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="w">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock256<T> Reblock<T>(this in SpanBlock32<T> src, W256 w)
             where T : unmanaged
                => new SpanBlock256<T>(src.Storage);

        /// <summary>
        /// Presents 32-bit blocks as 512-bit blocks
        /// </summary>
        /// <param name="src">The source blocks</param>
        /// <param name="w">The target block width</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanBlock512<T> Reblock<T>(this in SpanBlock32<T> src, W512 w)
             where T : unmanaged
                => new SpanBlock512<T>(src.Storage);
    }
}