//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class PolyRange
    {
        /// <summary>
        /// Produces a random closed interval [a,b] where a >= min and b < max
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="min">The inclusive minimum left endpoint value</param>
        /// <param name="max">The exclusive maximum right endpoint value</param>
        /// <typeparam name="T">The primal numeric type over which the interval is defined</typeparam>
        public static Interval<T> Interval<T>(this IBoundSource src, T min, T max)
            where T : unmanaged
        {
            var cut = src.Next(min,max);
            return (src.Next(min, cut), src.Next(cut,max));
        }

        /// <summary>
        /// Produces a stream of random closed intervals [a,b] where a >= min and b < max
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="min">The inclusive minimum left endpoint value</param>
        /// <param name="max">The exclusive maximum right endpoint value</param>
        /// <typeparam name="T">The primal numeric type over which the interval is defined</typeparam>
        public static IEnumerable<Interval<T>> Intervals<T>(this IBoundSource src, T min, T max)
            where T : unmanaged
        {
            while(true)
                yield return src.Interval(min,max);
        }
    }
}
