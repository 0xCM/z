//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        /// <summary>
        /// Presents the histogram state as a sequence of bins
        /// </summary>
        /// <param name="src">The histogram to query</param>
        /// <typeparam name="T">The point domain</typeparam>
        public static Span<Bin<T>> bins<T>(in Histogram<T> src)
            where T : unmanaged, IEquatable<T>, IComparable<T>
        {
            var segments = src.Partitions.Length;
            var dst = span<Bin<T>>(src.Partitions.Length - 1);
            bins(src,dst);
            return dst;
        }

        /// <summary>
        /// Presents the histogram state as a sequence of bins
        /// </summary>
        /// <param name="src">The histogram to query</param>
        /// <typeparam name="T">The point domain</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void  bins<T>(in Histogram<T> src, Span<Bin<T>> dst)
            where T : unmanaged, IEquatable<T>, IComparable<T>
        {
            var segments = src.Partitions.Length;
            for(var i = 1u; i<segments; i++)
                seek(dst,i-1) = bin(segment(src, i), count(src, i));
        }
    }
}