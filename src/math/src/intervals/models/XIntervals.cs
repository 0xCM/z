//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Creates a closed interval with endpoints from the existing interval
        /// </summary>
        [MethodImpl(Inline)]
        public static ClosedInterval<T> ToClosed<T>(this Interval<T> src)
            where T : unmanaged, IEquatable<T>
                => new ClosedInterval<T>(src.Left, src.Right);

        public static Index<T> Partition<T>(this Interval<T> src, T width, int? precision = null)
            where T : unmanaged
                => gcalc.partition(src,width,precision);

        public static Index<T> Partition<T>(this Interval<T> src)
            where T : unmanaged
                => gcalc.partition(src);

        public static Index<T> Partition<T>(this ClosedInterval<T> src)
            where T : unmanaged, IEquatable<T>
                => gcalc.partition<T>(src);

        [MethodImpl(Inline)]
        public static bool Contains<T>(this ClosedInterval<T> src, T point)
            where T : unmanaged, IEquatable<T>
               => gcalc.contains(src, point);

        /// <summary>
        /// Determines whether an interval contains a specified point
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="point">The point to test</param>
        /// <typeparam name="T">The primal numeric type over which the interval is defined</typeparam>
        [MethodImpl(Inline)]
        public static bool Contains<T>(this Interval<T> src, T point)
            where T : unmanaged
                => gcalc.contains(src,point);
    }
}