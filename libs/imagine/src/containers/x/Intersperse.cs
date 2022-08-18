//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    partial class XTend
    {
        /// <summary>
        /// Interleaves a specified value between each element of the source
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="x">The value to interleave</param>
        /// <typeparam name="T">The element type</typeparam>
        public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> src, T x)
        {
            var items = src.Array();
            var count = items.Length;
            var last = count - 1;
            for(var i=0; i<count; i++)
            {
                yield return items[i];
                if(i != last)
                    yield return x;
            }
        }

        /// <summary>
        /// Interleaves a specified value between each element of the source
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="x">The value to interleave</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static T[] Intersperse<T>(this T[] src, T x)
        {
            var buffer = sys.alloc<T>(src.Length*2);
            @readonly(src).Intersperse(x, span(buffer));
            return buffer;
        }

        /// <summary>
        /// Interleaves a specified value between each element of the source
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="x">The value to interleave</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static void Intersperse<T>(this ReadOnlySpan<T> src, T x, Span<T> dst)
        {
            var count = src.Length;
            var last = count - 1;
            for(uint i=0u, k=0u; i<count; i++)
            {
                seek(dst,k++) = skip(src, i);
                if(i != last)
                    seek(dst, k++) = x;
            }
        }
    }
}