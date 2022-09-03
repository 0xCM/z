//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a generic value as a bytespan
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> bytes<T>(in T src)
            where T : struct
                => cover(@as<T,byte>(src), size<T>());

        /// <summary>
        /// Converts a string to bytespan
        /// </summary>
        /// <param name="src">The source string</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> bytes(string src)
            => recover<char,byte>(span(src));

        /// <summary>
        /// Presents a span of generic values as bytespan
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> bytes<T>(Span<T> src)
            where T : struct
                => cover<byte>(u8<T>(first(src)), src.Length*size<T>());

        /// <summary>
        /// Presents a readonly span over T-cells as a readonly bytespan
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The source cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<byte> bytes<T>(ReadOnlySpan<T> src)
            where T : struct
                => cover<byte>(u8<T>(first(src)), src.Length*size<T>());

        /// <summary>
        /// Presents a selected segment of T-cells from a source span as a readonly bytespan
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The source offset</param>
        /// <param name="length">The source length</param>
        /// <typeparam name="T">The source cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> bytes<T>(Span<T> src, int offset)
            where T : struct
                => bytes(slice(src, offset));

        /// <summary>
        /// Converts a specified number of source elements to bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The number of source elements to convert</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> bytes<T>(Span<T> src, int offset, int count)
            where T : struct
                => bytes(slice(src,offset,count));

        /// <summary>
        /// Converts a specified number of source elements to bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The number of source elements to convert</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<byte> bytes<T>(Span<T> src, int offset, int? length)
            where T : struct
                => length == null ? bytes(src,offset) : bytes(src, offset, length.Value);

        /// <summary>
        /// Converts a specified number of source elements to bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The number of source elements to convert</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<byte> bytes<T>(ReadOnlySpan<T> src, int offset, int count)
            where T : struct
                => bytes(slice(src,offset,count));

        /// <summary>
        /// Presents a selected segment of a readonly span over T-cells as a readonly bytespan
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="offset">The source offset</param>
        /// <param name="length">The source length</param>
        /// <typeparam name="T">The source cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<byte> bytes<T>(ReadOnlySpan<T> src, int offset)
            where T : struct
                => bytes(slice(src,offset));
    }
}