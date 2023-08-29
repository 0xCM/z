//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


using static PolySeq;

[ApiHost]
public static class PolyTuples
{
    const NumericKind Closure = AllNumeric;

    /// <summary>
    /// Yields a source-provided heterogenous pairs
    /// </summary>
    /// <param name="src">The value source</param>
    /// <typeparam name="S">The left value type</typeparam>
    /// <typeparam name="T">The right value type</typeparam>
    public static Paired<S,T> Paired<S,T>(this ISource src)
        where S : struct
        where T : struct
            => paired<S,T>(src);

    public static Pair<T> Pair<T>(this ISource src)
        where T : struct
            => pair<T>(src);

    public static Pairs<T> Pairs<T>(this ISource src, int count)
        where T : struct
            => pairs<T>(src, count);

    public static Pairs<T> Pairs<T>(this ISource src, uint count)
        where T : struct
            => pairs<T>(src, (int)count);

    /// <summary>
    /// Yields the next source-provided pair
    /// </summary>
    /// <param name="src">The value source</param>
    /// <param name="a">The first element in the pair</param>
    /// <param name="t">A primal type representative</param>
    /// <typeparam name="T">The primal type</typeparam>
    [MethodImpl(Inline)]
    public static ConstPair<T> ConstPair<T>(this ISource src)
        where T : struct
            => kpair<T>(src);

    /// <summary>
    /// Yields the next source-provided pair over a specified domain
    /// </summary>
    /// <param name="src">The value source</param>
    /// <param name="min">The inclusive minimum value</param>
    /// <param name="max">The exclusive maximum value</param>
    /// <typeparam name="T">The primal type</typeparam>
    public static ConstPair<T> ConstPair<T>(this IBoundSource src, T min, T max)
        where T : unmanaged
            => kpair(src, min, max);

    /// <summary>
    /// Fills the target with parings taken from the source
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The receiver</param>
    /// <typeparam name="S">The left value type</typeparam>
    /// <typeparam name="T">The right value type</typeparam>
    public static Pairings<S,T> Pairings<S,T>(this ISource src, uint count)
        where S : struct
        where T : struct
    {
        var dst = new Pairings<S,T>(new Paired<S,T>[count]);
        src.Pairings(dst);
        return dst;
    }

    /// <summary>
    /// Fills the target with parings taken from the source
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The receiver</param>
    /// <typeparam name="S">The left value type</typeparam>
    /// <typeparam name="T">The right value type</typeparam>
    public static void Pairings<S,T>(this ISource src, Pairings<S,T> dst)
        where S : struct
        where T : struct
            => pairings(src, dst);

    /// <summary>
    /// Yields a stream of source-provided heterogenous pairs
    /// </summary>
    /// <param name="src">The data source</param>
    /// <typeparam name="S">The left value type</typeparam>
    /// <typeparam name="T">The right value type</typeparam>
    public static IEnumerable<Paired<S,T>> Pairings<S,T>(this ISource src)
        where S : struct
        where T : struct
            => pairings<S,T>(src);

    public static Triple<T> Triple<T>(this ISource src)
        where T : struct
            => triple<T>(src);

    /// <summary>
    /// Produces the next source-provided triple
    /// </summary>
    /// <param name="src">The value source</param>
    /// <param name="a">The first element in the pair</param>
    /// <param name="t">A primal type representative</param>
    /// <typeparam name="T">The primal type</typeparam>
    public static ConstTriple<T> ConstTriple<T>(this ISource src)
        where T : struct
            => ktriple<T>(src);

    /// <summary>
    /// Produces the next source-provided triple over a specified domain
    /// </summary>
    /// <param name="src">The value source</param>
    /// <param name="min">The inclusive minimum value</param>
    /// <param name="max">The exclusive maximum value</param>
    /// <typeparam name="T">The primal type</typeparam>
    public static ConstTriple<T> ConstTriple<T>(this IBoundSource src, T min, T max)
        where T : unmanaged
            => ktriple<T>(src, min, max);

    public static Triples<T> Triples<T>(this ISource src, int count, T t = default)
        where T : struct
            => triples(src, count, t);

    public static Triples<T> Triples<T>(this ISource src, Triples<T> dst)
        where T : struct
            => triples(src, dst);

    public static DeferredSource<Pair<T>> PairStream<T>(this ISource src)
        where T : struct
            => new DeferredSource<Pair<T>>(pairstream<T>(src));

    public static IEnumerable<Triple<T>> TripleStream<T>(this ISource src)
        where T : struct
            => triplestream<T>(src);

    [Op, Closures(Closure)]
    public static IEnumerable<Pair<T>> pairs<T>(ISource src)
        where T : struct
    {
        while(true)
            yield return pair<T>(src);
    }

    [Op, Closures(Closure)]
    public static Pairs<T> pairs<T>(ISource src, int count)
        where T : struct
            => pairs<T>(src).Take(count).Array();


    [Op, Closures(Closure)]
    public static IEnumerable<Pair<T>> pairstream<T>(ISource src)
        where T : struct
    {
        while(true)
            yield return pair<T>(src);
    }

    /// <summary>
    /// Yields a stream of source-provided heterogenous pairs
    /// </summary>
    /// <param name="src">The data source</param>
    /// <typeparam name="S">The left value type</typeparam>
    /// <typeparam name="T">The right value type</typeparam>
    public static IEnumerable<Paired<S,T>> pairings<S,T>(ISource src)
        where S : struct
        where T : struct
    {
        while(true)
            yield return paired<S,T>(src);
    }

    /// <summary>
    /// Fills the target with parings taken from the source
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The receiver</param>
    /// <typeparam name="S">The left value type</typeparam>
    /// <typeparam name="T">The right value type</typeparam>
    public static void pairings<S,T>(ISource src, Pairings<S,T> dst)
        where S : struct
        where T : struct
    {
        var count = dst.Count;
        var values = pairings<S,T>(src).Take(count).Array();
        for(var i=0; i<count; i++)
            dst[i] = sys.skip(values,i);
    }

    /// <summary>
    /// Yields a source-provided heterogenous pairs
    /// </summary>
    /// <param name="src">The value source</param>
    /// <typeparam name="S">The left value type</typeparam>
    /// <typeparam name="T">The right value type</typeparam>
    public static Paired<S,T> paired<S,T>(ISource src)
        where S : struct
        where T : struct
            => Tuples.paired(src.Next<S>(), src.Next<T>());

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Pair<T> pair<T>(ISource src)
        where T : struct
            => Tuples.pair(next<T>(src), next<T>(src));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Triple<T> triple<T>(ISource src)
        where T : struct
            => Tuples.triple(next<T>(src), next<T>(src), next<T>(src));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Triples<T> triples<T>(ISource src, int count, T t = default)
        where T : struct
            => triplestream<T>(src).Take(count).Array();

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Triples<T> triples<T>(ISource src, Triples<T> dst, T t = default)
        where T : struct
            => PolyStreams.deposit(triplestream<T>(src).Take(dst.Count), dst.Storage);


    [MethodImpl(Inline), Op, Closures(Closure)]
    public static IEnumerable<Triple<T>> triplestream<T>(ISource source)
        where T : struct
    {
        while(true)
            yield return triple<T>(source);
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ConstTriple<T> ktriple<T>(ISource source, T t = default)
        where T : struct
            => (next<T>(source), next<T>(source), next<T>(source));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ConstTriple<T> ktriple<T>(IBoundSource source, T min, T max)
        where T : unmanaged
            => (next(source,min,max), next(source,min,max), next(source,min,max));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ConstPair<T> kpair<T>(ISource source, T t = default)
        where T : struct
            => (next<T>(source), next<T>(source));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ConstPair<T> kpair<T>(IBoundSource source, T min, T max)
        where T : unmanaged
            => (next(source, min, max), next(source, min, max));
}
