//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcalc
    {
        /// <summary>
        /// Defines a scalar sequence {0,1,...,count-1}
        /// </summary>
        /// <param name="count">The number of elements in the sequence</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(UInt64k)]
        public static IEnumerable<T> stream<T>(T count)
            where T : unmanaged
                => stream(default(T), count);

        /// <summary>
        /// Creates an enumerable sequence that ranges between inclusive upper and lower bounds
        /// </summary>
        /// <param name="x0">The lower bound</param>
        /// <param name="x1">The upper bound</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(UInt64k)]
        public static IEnumerable<T> stream<T>(T x0, T x1)
            where T : unmanaged
                => range_1(x0, x1, null);

        /// <summary>
        /// Creates a numeric sequence that ranges between inclusive upper and lower bounds
        /// </summary>
        /// <param name="x0">The lower bound</param>
        /// <param name="x1">The upper bound</param>
        /// <param name="step">The step size</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [Op, Closures(UInt64k)]
        public static IEnumerable<T> stream<T>(T x0, T x1, T step)
            where T : unmanaged
                => range_1(x0, x1, step);
    }
}