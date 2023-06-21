//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;

    using static sys;

    [ApiHost]
    public static class TimeSeries
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SeriesEvolution<T> evolution<T>(ulong[] seed, Interval<T> domain, SeriesTerm<T> first, SeriesTerm<T> final, Duration time)
            where T : unmanaged
                => new SeriesEvolution<T>(seed, domain, first, final, time);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SeriesTerm<T> term<T>(long index, T value)
            where T : unmanaged
                => new SeriesTerm<T>(index, value);

        static long LastSeriesId;

        static readonly ConcurrentDictionary<long, IBoundSource> States
            = new ConcurrentDictionary<long, IBoundSource>();

        [Op,Closures(Closure)]
        public static SeriesTerm<T> next<T>(TimeSeries<T> series)
            where T : unmanaged
        {
            if(States.TryGetValue(series.Id, out IBoundSource source))
            {
                var _term = term(series.Observed.Index + 1, source.Next<T>(series.Domain));
                series.Witnessed(_term);
                return _term;
            }
            else
                return series.Observed;
        }

        [Op,Closures(Closure)]
        internal static IEnumerable<SeriesTerm<T>> evolve<T>(TimeSeries<T> series)
            where T : unmanaged
        {
            if(States.TryGetValue(series.Id, out IBoundSource source))
            {
                while(true)
                {
                    var _term = term(series.Observed.Index + 1, source.Next<T>(series.Domain));
                    series.Witnessed(_term);
                    yield return _term;
                }
            }
        }

        [Op,Closures(Closure)]
        public static TimeSeries<T> define<T>(Interval<T> domain, ulong[] seed)
            where T : unmanaged
        {
            var id = inc(ref LastSeriesId);
            var rng = Rng.xorShift1024(seed);
            if(!States.TryAdd(id,rng))
                throw new Exception($"Key {id} already exists");
            return new TimeSeries<T>(id, domain, term(0, zero<T>()));
        }

        [Op,Closures(Closure)]
        public static void evolve<T>(Interval<T> domain, ulong[] seed, int count, Action<TimeSeries<T>,Duration> complete)
            where T : unmanaged
        {
            var sw = Time.stopwatch();
            var series = define(domain, seed);
            var terms = evolve(series).ToSpan(count);
            var elapsed = Duration.init(sw.ElapsedTicks);
            Require.invariant(terms.Length == count,() =>"");
            Require.invariant(series.Observed.Observed.Equals(terms[count - 1].Observed), () => "");
            complete(series,elapsed);
        }

        [Op,Closures(Closure)]
        public static Task<SeriesEvolution<T>> evolve<T>(ulong[] seed, Interval<T> domain, int steps)
            where T : unmanaged
                => Task.Factory.StartNew(() => run(seed, domain, steps));

        [Op,Closures(Closure)]
        public static async Task evolve<T>(Interval<T> domain, Action<SeriesEvolution<T>> receiver, int count = Pow2.T06, int steps = (int)Pow2.T19)
            where T : unmanaged
        {
            var sw = Time.stopwatch();
            var variations = from i in gcalc.stream(count)
                    let seed = PolySeed1024.Entropic
                    let evolution = evolve(seed, domain, steps)
                    let status = evolution.ContinueWith(t => receiver(t.Result))
                    select evolution;

            await sys.start(() => Task.WaitAll(variations.ToArray()));
        }

        [Op,Closures(Closure)]
        static SeriesEvolution<T> run<T>(in ulong[] seed, in Interval<T> domain, int steps)
            where T : unmanaged
        {
            var sw = Time.stopwatch();
            var series = define(domain, seed);
            var s0 = series.Snapshot();
            var terms = evolve(series).ToSpan(steps);
            Require.invariant(terms.Length == steps, () => "");
            Require.invariant(series.Observed.Observed.Equals(terms[steps - 1].Observed), () => "");
            var elapsed = Duration.init(sw.ElapsedTicks);
            return evolution(seed, domain, s0.Observed, series.Observed, elapsed);
        }
    }
}