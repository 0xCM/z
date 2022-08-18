//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    partial class XTend
    {
        /// <summary>
        /// Forms a new span via concatenation [head,tail]
        /// </summary>
        /// <param name="head">The first span</param>
        /// <param name="tail">The second span</param>
        /// <typeparam name="T">The span element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Concat<T>(this ReadOnlySpan<T> head, ReadOnlySpan<T> tail)
        {
            var dst = span<T>(head.Length + tail.Length);
            head.CopyTo(dst);
            tail.CopyTo(dst, head.Length);
            return dst;
        }

        /// <summary>
        /// Forms a new span via concatenation [head,tail]
        /// </summary>
        /// <param name="head">The first span</param>
        /// <param name="tail">The second span</param>
        /// <typeparam name="T">The span element type</typeparam>
        [MethodImpl(Inline), Op]
        public static Span<T> Concat<T>(this Span<T> head, ReadOnlySpan<T> tail)
            => @readonly(head).Concat(tail);
    }
}