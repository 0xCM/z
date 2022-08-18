//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial class XTend
    {
        /// <summary>
        /// Presents selected span content as a span of bytes
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The source offset</param>
        /// <param name="length">The source length</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static Span<byte> Bytes<T>(this Span<T> src, int offset, int ? length = null)
            where T : struct
                => Algs.bytes(src, offset, length);

        /// <summary>
        /// Presents a span of generic values as a span of bytes
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline)]
        public static Span<byte> Bytes<T>(this Span<T> src)
            where T : struct
                => Algs.bytes(src);

        /// <summary>
        /// Presents a readonly span of generic values as a span of readonly bytes
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source span element type</typeparam>
        [MethodImpl(Inline)]
        public static ReadOnlySpan<byte> Bytes<T>(this ReadOnlySpan<T> src)
            where T : struct
                => Algs.bytes(src);
    }
}