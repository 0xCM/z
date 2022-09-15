//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Intervals
    {
        /// <summary>
        /// Computes the points that determine a partitioning predicated on partition width
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="width">The partition width</param>
        [MethodImpl(Inline), Op]
        public static ulong[] partition(in ClosedInterval<ulong> src, ulong width)
        {
            var dst = alloc<ulong>((src.Width/width) + 1);
            partition(src.Min, src.Max, width, dst);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Partition<T> partition<T>(Span<T> src, ReadOnlySpan<uint> offsets)
            => new Partition<T>(src,offsets);

        /// <summary>
        /// Cleaves a closed interval over an intergral domain into manageable disjoint pieces
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="width">The partition width</param>
        /// <typeparam name="T">The integer type, at most 64-bits wide</typeparam>
        public static T[] partition<T>(in ClosedInterval<T> src, T width)
            where T : unmanaged, IEquatable<T>
        {
            var dst = list<T>();
            dst.Add(src.Min);

            var next = left(src) + uint64(width);

            while(next < right(src))
            {
                dst.Add(generic<T>(next));
                next = next + uint64(width);
            }

            dst.Add(src.Max);
            return dst.Array();
        }

        /// <summary>
        /// Computes a sequence of points that partitions an integral range
        /// </summary>
        /// <param name="min">The lower bound</param>
        /// <param name="min">The upper bound</param>
        /// <param name="width">The partition width</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void partition(ulong min, ulong max, ulong width, ulong[] dst)
        {
            var points = span(dst);
            var count = points.Length;
            var point = min;
            var final = count - 1;

            for(var i=0u; i<count; i++)
            {
                if(i == 0)
                    seek(points,i) = min;
                else if(i == final - 1)
                    seek(points,i) = max;
                else
                    seek(points,i) = point;

                if(i != final)
                    point = add(point, width);
            }
        }
    }
}