//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Constructs a span from a (presumeably finite) sequence selection
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="offset">The number of elements to skip from the head of the sequence</param>
        /// <param name="length">The number of elements to take from the sequence</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> ToSpan<T>(this IEnumerable<T> src)
            => src.ToArray();

        /// <summary>
        /// Constructs a span from a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> ToSpan<T>(this ReadOnlySpan<T> src)
            => src.ToArray();

        /// <summary>
        /// Constructs a span of specified length from a sequence
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="length">The length of the result span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> ToSpan<T>(this IEnumerable<T> src, int length)
            => src.Take(length).ToArray();

        /// <summary>
        /// Constructs a span of specified length from the sequence obtained by skipping a specified number of leading elements
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="offset">The number of elements to skip</param>
        /// <param name="length">The length of the result span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> ToSpan<T>(this IEnumerable<T> src, int offset, int length)
            => src.Skip(offset).Take(length).ToArray();
    }
}