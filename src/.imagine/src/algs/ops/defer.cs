//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Deferred<T> defer<T>(IEnumerable<T> src)
            => new Deferred<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Deferred<T> defer<T>()
            => new Deferred<T>(sys.empty<T>());

        /// <summary>
        /// Constructs a nonempty stream
        /// </summary>
        /// <param name="head">The first element in the stream</param>
        /// <param name="tail">The remaining elements of the stream</param>
        /// <typeparam name="T">The streamed element type</typeparam>
        [Op, Closures(Closure)]
        public static Deferred<T> defer<T>(T head, params T[] tail)
            => defer(nes(head, tail));

        /// <summary>
        /// Constructs a stream, possibly empty
        /// </summary>
        /// <param name="src">The stream elements</param>
        /// <typeparam name="T">The streamed element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Deferred<T> defer<T>(params T[] src)
            => src;

        [Op, Closures(Closure)]
        static IEnumerable<T> nes<T>(T head, params T[] tail)
        {
            yield return head;
            foreach (var t in tail)
                yield return t;
        }
    }
}