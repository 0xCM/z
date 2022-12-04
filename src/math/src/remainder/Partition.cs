//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Numeric;
    using static IntervalKind;

    [ApiHost]
    public class Partitions
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T length<T>(Interval<T> src)
            where T : unmanaged
                => gmath.abs(gmath.sub(src.Right, src.Left));

        /// <summary>
        /// Computes the points that determine a partitioning predicated on partition width
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="width">The partition width</param>
        /// <typeparam name="T">The interval primal type</typeparam>
        public static Span<T> measured<T>(Interval<T> src, T width)
            where T : unmanaged
                => NumericKinds.fractional<T>() ? floating<T>(src, width) : integral<T>(src,width);

        /// <summary>
        /// Calculates the points that determine a partitioning predicated on partition count
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="count">The number of desired partitions</param>
        /// <typeparam name="T">The interval primal type</typeparam>
        public static Span<T> counted<T>(Interval<T> src, int count)
            where T : unmanaged
                => measured(src,gmath.div(gmath.sub(src.Right, src.Left), Numeric.force<T>(count - 1)));

        /// <summary>
        /// Partitions an interval predicated on a specified partition count
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="count">The number of partitions</param>
        /// <typeparam name="T">The interval primal type</typeparam>
        public static Span<Interval<T>> counted<S,T>(Interval<T> src, int count)
            where T : unmanaged
                => width(src,gmath.div(gmath.sub(src.Right, src.Left), Numeric.force<T>(count)));

        /// <summary>
        /// Partitions an interval predicated on a specified partition width
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="width">The partition width</param>
        /// <typeparam name="T">The interval primal type</typeparam>
        [Op, Closures(AllNumeric)]
        public static Span<Interval<T>> width<T>(Interval<T> src, T width)
            where T : unmanaged
        {
            var points = measured(src,width);
            var dst = span<Interval<T>>(points.Length - 1);
            var lastIx = points.Length - 1;
            var lastCycleIx = lastIx - 1;
            var model = default(Interval<T>);

            for(var i = 0; i < lastIx; i++)
            {
                var left = points[i];
                var right = points[i + 1];
                if(i == 0)
                    if(src.Open || src.LeftOpen)
                        dst[i] =  model.New(left,right, Open);
                    else
                        dst[i] = model.New(left,right, LeftClosed);
                else if(i == lastCycleIx)
                    if(src.Closed || src.RightClosed)
                        dst[i] = model.New(left,right, Closed);
                    else
                        dst[i] = model.New(left,right, LeftClosed);
                else
                    dst[i] = model.New(left,right, LeftClosed);
            }
            return dst;
        }

        /// <summary>
        /// Populates a span of length n with consecutive values 0,1,...n - 1
        /// </summary>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Span<T> increments<T>(Span<T> dst)
            where T : unmanaged
        {
            var count = dst.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = force<T>(i);
            return dst;
        }

        /// <summary>
        /// Populates a memory target with values first, first + 1, ... first + (n - 1)
        /// </summary>
        /// <param name="first">The first value</param>
        /// <param name="count">The number of values to populate</param>
        /// <param name="dst">The target memory reference</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void increments<T>(T first, uint count, ref T dst)
            where T : unmanaged
        {
            for(var i=0; i<count; i++)
                seek(dst,i) = gmath.add(first, force<T>(i));
        }

        /// <summary>
        /// Emits a monotonic integral sequence with a specified number of terms to a target reference
        /// </summary>
        /// <param name="count">The number of terms to populate</param>
        /// <param name="dst">The target reference</param>
        /// <typeparam name="T">The sequence term type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void increments<T>(uint count, ref T dst)
            where T : unmanaged
        {
            for(var i=0; i<count; i++)
                seek(dst,i) = force<T>(i);
        }

        /// <summary>
        /// Produces a monotonic sequence k, k + 1, ... k + (N - 1) where N denotes the length of the target
        /// </summary>
        /// <param name="k">The value of the first term</param>
        /// <param name="dst">The target span</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void increments<T>(T k, Span<T> dst)
            where T : unmanaged
                => increments(k, (uint)dst.Length, ref first(dst));

        public static T[] increments<T>(ClosedInterval<T> src)
            where T : unmanaged, IEquatable<T>
        {
            var count = (int)src.Width + 1;
            var dst = sys.alloc<T>(count);
            increments(src,dst);
            return dst;
        }

        [Op, Closures(Closure)]
        public static void increments<T>(ClosedInterval<T> src, Span<T> dst)
            where T : unmanaged, IEquatable<T>
        {
            var min = src.Min;
            var max = src.Max;
            var count = (int)src.Width + 1;
            var index = 0;
            var current = min;
            while(gmath.lteq(current, max) && index < count)
            {
                seek(dst, index++) = current;
                if(gmath.lt(current, max))
                    current = gmath.inc(current);
                else
                    break;
            }
        }
        /// <summary>
        /// Computes the points that determine a partitioning predicated on partition width
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="width">The partition width</param>
        /// <typeparam name="T">The interval primal type</typeparam>
        [Op, Closures(Integers)]
        static Span<T> integral<T>(Interval<T> src, T width)
            where T : unmanaged
        {
            var len =  Partitions.length(src);
            var count = Numeric.force<T,int>(gmath.div(len, width));
            var dst = span<T>(count + 1);
            var point = src.Left;
            var lastix = dst.Length - 1;

            for(var i=0; i < dst.Length; i++)
            {
                if(i == 0)
                    dst[i] = src.Left;
                else if(i == dst.Length - 1)
                    dst[i] = src.Right;
                else
                    dst[i] = point;

                if(i != lastix)
                    point = gmath.add(point, width);
            }

            return dst;
        }

        [Op, Closures(Floats)]
        static Span<T> floating<T>(Interval<T> src, T width)
            where T : unmanaged
        {
            var scale = 4;
            var len =  gfp.round(Partitions.length(src), scale);
            var fcount = gfp.div(len, width);
            var count = Numeric.force<T,int>(gfp.ceil(fcount));
            var dst = sys.span<T>(count + 1);

            var point = src.Left;
            var lastix = dst.Length - 1;
            for(var i=0; i < dst.Length; i++)
            {
                if(i > 0 && i < lastix)
                    dst[i] = point;
                else if(i == 0)
                    dst[i] = src.Left;
                else if(i == lastix)
                    dst[i] = src.Right;

                if(i != lastix)
                    point = gfp.round(gfp.add(point, width), scale);
            }

            return dst;
        }
    }
}