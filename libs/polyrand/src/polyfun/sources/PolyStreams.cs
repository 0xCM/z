//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    [ApiHost]
    public static class PolyStreams
    {
        const NumericKind Closure = NumericKind.U64;

        /// <summary>
        /// Produces an interminable stream of <see cref='bit'/> values
        /// </summary>
        /// <param name="random">The value source</param>
        [Op]
        public static IEnumerable<bit> bitstream(ISource src)
        {
            while(true)
            {
                var data = src.Next<ulong>();
                for(byte i=0; i<64; i++)
                    yield return bit.test(data,i);
            }
        }

        /// <summary>
        /// Produces an interminable stream of random values from a numeric domain {0,1}
        /// </summary>
        /// <param name="random">The random source</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [Op, Closures(Closure)]
        public static IEnumerable<T> bitstream<T>(ISource src)
            where T : unmanaged
        {
            while(true)
            {
                var data = src.Next<ulong>();
                for(byte i=0; i<64; i++)
                    yield return Numeric.force<byte,T>((byte)bit.test(data,i));
            }
        }

        /// <summary>
        /// Transforms an primal source stream into a bitstream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static IEnumerable<bit> bitstream<T>(IEnumerable<T> src)
            where T : struct
                => bitstream<T>(src.GetEnumerator());

        /// <summary>
        /// Transforms an primal enumerator into a bitstream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static IEnumerable<bit> bitstream<T>(IEnumerator<T> src)
            where T : struct
        {
            var buffer = alloc<bit>(size<T>());
            while(src.MoveNext())
            {
                bit.unpack(src.Current, buffer.Clear());
                foreach(var b in buffer)
                    yield return b;
            }
        }

        /// <summary>
        /// Produces a random stream of unfiltered/unbounded points from a source
        /// </summary>
        /// <param name="src">The point source</param>
        /// <typeparam name="T">The point type</typeparam>
        public static DeferredSource<T> Stream<T>(this IPolySource src)
            where T : unmanaged
                => create<T>(src);

        /// <summary>
        /// Produces a stream values from the source subject to a specified range and optional filter
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">If specified, the domain of the random variable</param>
        /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
        /// <typeparam name="T">The element type</typeparam>
        public static DeferredSource<T> Stream<T>(this IPolySource src, T min, T max)
            where T : unmanaged
                => create<T>(src, (min,max));

        /// <summary>
        /// Produces a stream of values from the random source
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">The domain of the random variable</param>
        /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
        /// <typeparam name="T">The element type</typeparam>
        public static DeferredSource<T> Stream<T>(this IBoundSource src, Interval<T> domain)
            where T : unmanaged
                => create(src, domain);

        /// <summary>
        /// Produces a stream of values from the random source
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">The domain of the random variable</param>
        /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
        /// <typeparam name="T">The element type</typeparam>
        public static DeferredSource<T> Stream<T>(this IPolySource src, Interval<T> domain)
            where T : unmanaged
                => create(src, domain);

        public static IEnumerable<T> Stream<T>(this IBoundSource src, Interval<T> domain, Func<T,bool> filter = null)
            where T : unmanaged
        {
            while(true)
            {
                var candidate = src.Next(domain);
                if(filter != null && filter(candidate))
                    yield return candidate;
                else
                    yield return candidate;
            }
        }

        public static IEnumerable<T> Stream<T>(this ISource src)
        {
            while(true)
                yield return src.Next<T>();
        }

        /// <summary>
        /// Produces a stream values from the source subject to a specified range and optional filter
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">If specified, the domain of the random variable</param>
        /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
        /// <typeparam name="T">The element type</typeparam>
        public static DeferredSource<T> DataStream<T>(this ISource src)
            where T : unmanaged
                => create(src.Stream<T>());

        /// <summary>
        /// Produces a stream values from the source subject to a specified range and optional filter
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">If specified, the domain of the random variable</param>
        /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
        /// <typeparam name="T">The element type</typeparam>
        public static DeferredSource<T> DataStream<T>(this IBoundSource src, T min, T max)
            where T : unmanaged
                => create(src.Stream<T>((min,max)));

        /// <summary>
        /// Produces a stream values from the source subject to a specified range and optional filter
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">If specified, the domain of the random variable</param>
        /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
        /// <typeparam name="T">The element type</typeparam>
        public static DeferredSource<T> DataStream<T>(this IBoundSource src, Interval<T> domain)
            where T : unmanaged
                => src.DataStream<T>(domain.Left, domain.Right);

        /// <summary>
        /// Produces a stream of values from the random source
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">The domain of the random variable</param>
        /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
        /// <typeparam name="T">The element type</typeparam>
        public static DeferredSource<T> DataStream<T>(this IBoundSource src, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => create(src.Stream(domain, filter));

        /// <summary>
        /// Produces a stream of nonzero uniformly random values
        /// </summary>
        /// <param name="source">The random source</param>
        /// <param name="domain">The domain of the random variable</param>
        /// <typeparam name="T">The element type</typeparam>
        public static ISourceStream<T> NonZStream<T>(this IBoundSource source, Interval<T> domain)
            where T : unmanaged
                => create<T>(source, domain, x => core.nonzero(x));

        /// <summary>
        /// Queries the source for the next nonzero value within a range
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="min">The inclusive min value</param>
        /// <param name="max">The exclusive max value</param>
        /// <typeparam name="T">The element type</typeparam>
        public static T NonZ<T>(this IBoundSource src, T min, T max)
            where T : unmanaged
                => src.NonZStream<T>((min,max)).First();

        /// <summary>
        /// Queries the source for the next nonzero value within a range
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">The range of potential values</param>
        /// <typeparam name="T">The element type</typeparam>
        public static T NonZ<T>(this IBoundSource src, Interval<T> domain)
            where T : unmanaged
                => src.NonZStream<T>(domain).First();

        /// <summary>
        /// Queries the source for the next nonzero value less than a specified upper bound
        /// </summary>
        /// <param name="src">The random source</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="max">The exclusive upper bound</param>
        [MethodImpl(Inline)]
        public static T NonZ<T>(this IBoundSource src, T max)
            where T : unmanaged
                => src.NonZStream<T>((Limits.minval<T>(),max)).First();

        /// <summary>
        /// Queries the source for the next nonzero value
        /// </summary>
        /// <param name="src">The random source</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline)]
        public static T NonZ<T>(this IBoundSource src)
            where T : unmanaged
                => src.NonZStream<T>((Limits.minval<T>(), Limits.maxval<T>())).First();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DeferredSource<T> create<T>(IEnumerable<T> src, ulong classifier = 0)
            where T : struct
                => new DeferredSource<T>(src, classifier);

        /// <summary>
        /// Produces a random stream of unfiltered/unbounded points from a source
        /// </summary>
        /// <param name="src">The point source</param>
        /// <typeparam name="T">The point type</typeparam>
        [Op, Closures(Closure)]
        public static DeferredSource<T> create<T>(IBoundSource src)
            where T : unmanaged
                => create(forever<T>(src));

        [Op, Closures(Closure)]
        public static DeferredSource<T> create<T>(IBoundSource src, T min, T max)
            where T : unmanaged
                => create(forever(src,min,max));

        [Op, Closures(Closure)]
        public static DeferredSource<T> create<T>(IBoundSource src, ClosedInterval<T> domain, Func<T,bool> filter = null)
            where T : unmanaged, IEquatable<T>
                => create(forever(src, domain, filter));

        /// <summary>
        /// Produces a stream of values from the random source
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">The domain of the random variable</param>
        /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static DeferredSource<T> create<T>(IBoundSource src, Interval<T> domain, Func<T,bool> filter = null)
            where T : unmanaged
                => create(forever(src, domain, filter));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DeferredSource<T> create<T>(ISource src)
            => new DeferredSource<T>(forever<T>(src));

        /// <summary>
        /// Fills a caller-supplied span with data produced by a T-enumerable
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="T">The element type</typeparam>
        public static T[] deposit<T>(IEnumerable<T> src, Index<T> dst)
        {
            var i = 0u;
            var e = sys.enumerator(src);
            while(sys.next(e) && i < dst.Count)
                dst[i] = sys.current(e);
            return dst;
        }

        [Op, Closures(Closure)]
        static IEnumerable<T> forever<T>(ISource src)
        {
            while(true)
                yield return src.Next<T>();
        }

        [Op, Closures(Closure)]
        static IEnumerable<T> forever<T>(IBoundSource src, ClosedInterval<T> domain, Func<T,bool> filter)
            where T : unmanaged, IEquatable<T>
                => filter != null
                ? some(src, Intervals.closed(domain.Min, domain.Max), filter)
                : forever(src, domain);

        [Op, Closures(Closure)]
        static IEnumerable<T> forever<T>(IBoundSource src, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
                => filter != null
                ? some(src, domain, filter)
                : forever(src, domain);

        [Op, Closures(Closure)]
        static IEnumerable<T> forever<T>(IBoundSource src, T min, T max)
            where T : unmanaged
        {
            while(true)
                yield return src.Next<T>(min, max);
        }

        [Op, Closures(Closure)]
        static IEnumerable<T> forever<T>(IBoundSource src)
            where T : unmanaged
        {
            while(true)
                yield return src.Next<T>();
        }

        [Op, Closures(Closure)]
        static IEnumerable<T> forever<T>(IBoundSource src, Interval<T> domain)
            where T : unmanaged
                => domain.IsEmpty ? forever<T>(src) : forever(src, domain.Left, domain.Right);

        [Op, Closures(Closure)]
        static IEnumerable<T> forever<T>(IBoundSource src, ClosedInterval<T> domain)
            where T : unmanaged, IEquatable<T>
                => domain.IsDegenerate ? forever<T>(src) : forever(src, domain.Min, domain.Max);

        /// <summary>
        /// Creates a stream predicated on a specified source over which a filter is applied
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="domain">The source domain</param>
        /// <param name="filter">The filter predicate</param>
        /// <typeparam name="T">The production type</typeparam>
        [Op, Closures(Closure)]
        static IEnumerable<T> some<T>(IBoundSource src, Interval<T> domain, Func<T,bool> filter)
            where T : unmanaged
        {
            var next = default(T);
            var tries = 0;
            var tryMax = 10;

            while(true)
            {
                next = src.Next<T>(domain);
                if(filter(next))
                {
                    tries = 0;
                    yield return next;
                }
                else
                {
                    ++tries;
                    if(tries > tryMax)
                        throw new Exception($"Filter too rigid over {domain}; last failed value: {next}");
                }
            }
        }
    }
}