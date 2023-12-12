//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public static class PolyFill
{
    /// <summary>
    /// Fills a caller-allocated buffer with random values
    /// </summary>
    /// <param name="source">The data source</param>
    /// <param name="dst">The target span</param>
    /// <typeparam name="T">The cell type</typeparam>
    public static void Fill<T>(this IBoundSource source, Index<T> dst)
        where T : unmanaged, IEquatable<T>
            => source.Fill(ClosedInterval<T>.Full, dst.Length, ref dst.First);

    /// <summary>
    /// Fills a caller-allocated span with random values
    /// </summary>
    /// <param name="source">The data source</param>
    /// <param name="dst">The target span</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The exclusive upper bound</param>
    /// <typeparam name="T">The cell type</typeparam>
    public static Index<T> Fill<T>(this IBoundSource source, T min, T max, Index<T> dst, Func<T,bool> filter = null)
        where T : unmanaged, IEquatable<T>
    {
        source.Fill((min,max), dst.Length, ref dst.First, filter);
        return dst;
    }

    /// <summary>
    /// Fills a caller-allocated target with a specified number of values from a random source
    /// </summary>
    /// <param name="random">The data source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <param name="count">The number of values to send to the target</param>
    /// <param name="dst">A reference to the target location</param>
    /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void Fill<T>(this IBoundSource src, Interval<T> domain, int count, ref T dst, Func<T,bool> filter = null)
        where T : unmanaged, IEquatable<T>
    {
        var counter = 0;
        while(counter < count)
        {
            var candidate = src.Next(domain);
            if(filter != null)
            {
                if(filter(candidate))
                {
                    seek(dst, counter) = candidate;
                    counter++;
                }
            }
            else
            {
                seek(dst, counter) = candidate;
                counter++;
            }
        }
    }

    /// <summary>
    /// Fills a caller-allocated target with a specified number of values from a random source
    /// </summary>
    /// <param name="random">The data source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <param name="count">The number of values to send to the target</param>
    /// <param name="dst">A reference to the target location</param>
    /// <param name="filter">If specified, values that do not satisfy the predicate are excluded from the stream</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void Fill<T>(this IPolySource random, Interval<T> domain, int count, ref T dst, Func<T,bool> filter = null)
        where T : unmanaged, IEquatable<T>
    {
        var points = @readonly(random.Stream<T>(domain, filter).Take(count).Array());
        for(var i=0; i<count; i++)
            seek(dst, i) = skip(points, i);
    }

    /// <summary>
    /// Fills a caller-allocated buffer with random values
    /// </summary>
    /// <param name="source">The data source</param>
    /// <param name="dst">The target span</param>
    /// <typeparam name="T">The cell type</typeparam>
    public static void Fill<T>(this IBoundSource source, Span<T> dst)
        where T : unmanaged, IEquatable<T>
            => source.Fill(ClosedInterval<T>.Full, dst.Length, ref first(dst));

    /// <summary>
    /// Fills a caller-allocated span with random values
    /// </summary>
    /// <param name="source">The data source</param>
    /// <param name="dst">The target span</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The exclusive upper bound</param>
    /// <typeparam name="T">The cell type</typeparam>
    public static Span<T> Fill<T>(this IBoundSource source, T min, T max, Span<T> dst, Func<T,bool> filter = null)
        where T : unmanaged, IEquatable<T>
    {
        source.Fill((min,max), dst.Length, ref first(dst), filter);
        return dst;
    }

    /// <summary>
    /// Fills a caller-allocated span with random values
    /// </summary>
    /// <param name="random">The data source</param>
    /// <param name="dst">The target span</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The exclusive upper bound</param>
    /// <typeparam name="T">The cell type</typeparam>
    public static Span<T> Fill<T>(this IBoundSource random, Interval<T> domain, Span<T> dst, Func<T,bool> filter = null)
        where T : unmanaged, IEquatable<T>
    {
        random.Fill(domain, dst.Length, ref first(dst), filter);
        return dst;
    }

    /// <summary>
    /// Fills a caller-allocated target with a specified number of values from the source
    /// </summary>
    /// <param name="source">The data source</param>
    /// <param name="count">The number of values to send to the target</param>
    /// <param name="dst">A reference to the target location</param>
    /// <typeparam name="T">The element type</typeparam>
    public static void Fill<T>(this ISource source, int count, ref T dst)
        where T : unmanaged
    {
        var it = source.Stream<T>().Take(count).GetEnumerator();
        var counter = 0;
        while(it.MoveNext())
            seek(dst, counter++) = it.Current;
    }
}
