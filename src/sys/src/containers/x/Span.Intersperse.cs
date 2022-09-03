//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        /// <summary>
        /// Creates a new span by interposing a specified element between each element of an existing span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="x">The value to place between each element in the new span</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static Span<T> Intersperse<T>(this ReadOnlySpan<T> src, T x)
        {
            var len = src.Length;
            if(len == 0)
                return sys.empty<T>();

            Span<T> dst = new T[len*2 - 1];
            for(int i=0, j=0; i<len; i++, j+= 2)
            {
                seek(dst, j) = skip(src, i);
                if(i != src.Length - 1)
                    seek(dst, j + 1) = x;
            }
            return dst;
        }

        /// <summary>
        /// Creates a new span by interposing a specified element between each element of an existing span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="x">The value to place between each element in the new span</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static Span<T> Intersperse<T>(this Span<T> src, T x)
            => src.ReadOnly().Intersperse(x);
    }
}