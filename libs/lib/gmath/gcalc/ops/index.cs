//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcalc
    {
        /// <summary>
        /// Searches for the bucket containing the point; if found, returns the bucket index; otherwise returns a failure code
        /// </summary>
        /// <param name="src">The histogram to search</param>
        /// <param name="point">A point contained in some bucket, hopefully </param>
        /// <typeparam name="T">The point domain</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static uint index<T>(in Histogram<T> src, T point)
            where T : unmanaged, IEquatable<T>, IComparable<T>
        {
            var partitions = src.Partitions.Length;
            for(var i = 1u; i<partitions; i++)
                if(Intervals.contains(segment(src, i), point))
                    return i;
            return uint.MaxValue;
        }
    }
}