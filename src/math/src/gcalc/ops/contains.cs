//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static gmath;

    partial struct gcalc
    {
        /// <summary>
        /// Determines whether an interval contains a specified point
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="point">The point to test</param>
        /// <typeparam name="T">The primal numeric type over which the interval is defined</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static bit contains<T>(Interval<T> src, T point)
            where T : unmanaged, IEquatable<T>
        {
            switch(src.Kind)
            {
                case IntervalKind.Closed:
                    return gteq(point, src.Left) && lteq(point, src.Right);
                case IntervalKind.Open:
                    return gt(point, src.Left) && lt(point, src.Right);
                case IntervalKind.LeftClosed:
                    return gteq(point, src.Left) && lt(point, src.Right);
                default:
                    return gt(point, src.Left) && lteq(point, src.Right);
            }
        }

        [MethodImpl(Inline), Op, Closures(UInt32k)]
        public static bit contains<T>(Span<T> xs, T match)
            where T : unmanaged
                => contains(sys.first(xs), match, (uint)xs.Length);

        /// <summary>
        ///  Adapted from corefx repo
        /// </summary>
        [MethodImpl(Inline), Op, Closures(UInt32k)]
        public static bit contains<T>(in T src, T match, uint length)
            where T : unmanaged
        {
            var index = 0u;

            while (length >= 8)
            {
                length -= 8;
                if(search(n8, src, match, index))
                    return true;
                index += 8;
            }

            if (length >= 4)
            {
                length -= 4;
                if(search(n4, src, match, index))
                    return true;
                index += 4;
            }

            while (length > 0)
            {
                length -= 1;
                if (eq(match, sys.add(src, index)))
                    return true;
                index += 1;
            }
            return false;
        }
    }
}