//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public static class PolySpan
    {
        const NumericKind Closure = AllNumeric;

        /// <summary>
        /// Produces a span of random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="length">The span length</param>
        /// <param name="t">A cell type representative</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static Span<T> Span<T>(this ISource src, int length)
            where T : unmanaged
        {
            var dst = span<T>(length);
            src.Fill(length, ref first(dst));
            return dst;
        }

        /// <summary>
        /// Produces a span of random values constraint to a specified domain
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="length">The length of the produced data</param>
        /// <param name="domain">The interval domain to which values are constrained</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static Span<T> Span<T>(this IBoundSource src, int length, T min, T max, Func<T,bool> filter = null)
            where T : unmanaged
                => polyspan<T>(src, length, (min, max), filter);

        /// <summary>
        /// Produces a span of random values
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="length">The length of the produced data</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static Span<T> Span<T>(this IBoundSource src, int length, Interval<T> domain)
            where T : unmanaged
        {
            var dst = span<T>(length);
            src.Fill(domain, length, ref first(dst));
            return dst;
        }

        /// <summary>
        /// Produces a span of random values constraint to a specified domain
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="length">The length of the produced data</param>
        /// <param name="domain">The interval domain to which values are constrained</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static Span<T> Span<T>(this IBoundSource src, int length, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
        {
            var dst = span<T>(length);
            src.Fill(domain, length, ref first(dst), filter);
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        static bool nonzero<T>(T src)
            where T : unmanaged
                => bw64(src) != 0;
 
        /// <summary>
        /// Allocates and produces a punctured span populated with nonzero random values
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="length">The length of the produced data</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static Span<T> NonZeroSpan<T>(this IBoundSource src, int length, Interval<T> domain)
            where T : unmanaged
                => src.Span<T>(length, domain, x => nonzero(x));

        /// <summary>
        /// Allocates and produces a punctured span populated with nonzero random values
        /// </summary>
        /// <param name="source">The random source</param>
        /// <param name="length">The length of the produced data</param>
        /// <param name="domain">An optional domain to which values are constrained</param>
        /// <param name="filter">An optional filter that refines the domain</param>
        /// <typeparam name="T">The primal random value type</typeparam>
        public static Span<T> NonZeroSpan<T>(this IBoundSource source, int length)
            where T : unmanaged, IEquatable<T>
                => source.Span<T>(length, ClosedInterval<T>.Full, x => nonzero(x));

        [Op, Closures(Closure)]
        public static Span<T> polyspan<T>(IBoundSource src, int length, Interval<T> domain, Func<T,bool> filter = null)
            where T : unmanaged
        {
            var dst = span<T>(length);
            src.Fill(domain, length, ref first(dst), filter);
            return dst;
        }
    }
}