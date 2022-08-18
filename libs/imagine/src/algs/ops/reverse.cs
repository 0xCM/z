//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        /// <summary>
        /// Reflects the immutable self
        /// </summary>
        /// <param name="src">The self</param>
        /// <typeparam name="T">The self cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> @readonly<T>(Span<T> src)
            => src;

        /// <summary>
        /// Reflects the content of an array as a readonly span
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> @readonly<T>(T[] src)
            => src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void reverse<T>(ReadOnlySpan<T> src, Span<T> dst)
        {
            var count = src.Length;
            var j=0;
            for(var i=count-1; i>= 0; i--,j++)
                Spans.seek(dst,j) = Spans.skip(src,i);
        }
    }
}