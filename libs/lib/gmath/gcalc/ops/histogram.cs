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
        /// Creates a histogram over the T-domain and allocates a bin count commensurate with the number of points in T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [Op, Closures(Closure)]
        public static Histogram<T> histogram<T>()
            where T : unmanaged, IEquatable<T>, IComparable<T>
        {
            var domain = new ClosedInterval<T>(Limits.minval<T>(), Limits.maxval<T>());
            var grain = domain.Width;
            return histogram<T>(domain, generic<T>(domain.Width));
        }

        [Op, Closures(Closure)]
        public static Histogram<T> histogram<T>(in ClosedInterval<T> src, T grain)
            where T : unmanaged, IEquatable<T>, IComparable<T>
        {
            var parts = Intervals.partition(src,grain);
            var counts = alloc<uint>(parts.Length);
            return new Histogram<T>(src, grain, parts, counts);
        }
    }
}