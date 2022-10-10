//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        public static Deferred<T> Defer<T>(this IEnumerable<T> src)
            => Deferrals.defer(src);
    }

    [ApiHost]
    public class Deferrals
    {
        const NumericKind Closure = Integers;

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Deferred<X> defer<X>(IEnumerable<X> src)
            => new Deferred<X>(src);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Deferred<T> concat<T>(Deferred<T> head, Deferred<T> tail)
            => new Deferred<T>(head.Content.Concat(tail.Content));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static Deferred<T> concat<T>(Deferred<T> s1, Deferred<T> s2, Deferred<T> s3)
            => concat(concat(s1,s2),s3);

        /// <summary>
        /// Constructs a nonempty stream
        /// </summary>
        /// <param name="head">The first element in the stream</param>
        /// <param name="tail">The remaining elements of the stream</param>
        /// <typeparam name="T">The streamed element type</typeparam>
        [Op, Closures(Closure)]
        public static Deferred<T> defer<T>(T head, params T[] tail)
            => defer(NonEmptyStream(head, tail));

        /// <summary>
        /// Constructs a stream, possibly empty
        /// </summary>
        /// <param name="src">The stream elements</param>
        /// <typeparam name="T">The streamed element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Deferred<T> defer<T>(params T[] src)
            => src;

        [Op, Closures(Closure)]
        static IEnumerable<T> NonEmptyStream<T>(T head, params T[] tail)
        {
            yield return head;
            foreach (var t in tail)
                yield return t;
        }
    }
}