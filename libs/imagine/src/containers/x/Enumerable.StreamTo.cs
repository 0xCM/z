//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Fills an allocated span from a sequence
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="dst">The target spn</param>
        /// <typeparam name="T">The element type</typeparam>
        public static Span<T> StreamTo<T>(this IEnumerable<T> src, Span<T> dst)
        {
            var i = 0;
            var e = src.GetEnumerator();
            while(e.MoveNext() && i < dst.Length)
                dst[i++] = e.Current;
            return dst;
        }
    }
}