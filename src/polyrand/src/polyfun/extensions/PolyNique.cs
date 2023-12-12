//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public static class PolyNique
{
    /// <summary>
    /// Samples the source values without replacement
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="values">The data source</param>
    /// <param name="count">The number of values to sample</param>
    /// <typeparam name="T">The value type</typeparam>
    public static HashSet<T> Distinct<T>(this IBoundSource source, T[] values, int count)
        => source.Distinct(values.Length, count).Map(i => values[i]).ToHashSet();

    public static HashSet<T> Distinct<T>(this IBoundSource source, T pool, int count)
        where T : unmanaged, IEquatable<T>
    {
        var src = source.DataStream(default, pool);
        var set = src.Take(count).ToHashSet();
        while(set.Count < count)
            set.WithItems(src.Take(count / 2));
        return set;
    }

    public static HashSet<T> Distinct<T>(this IBoundSource source, T pool, T count)
        where T : unmanaged, IEquatable<T>
    {
        var src = source.DataStream(default, pool);
        var _count = Numeric.force<T,int>(count);
        var set = src.Take(_count).ToHashSet();
        while(set.Count < _count)
            set.WithItems(src.Take(_count / 2));
        return set;
    }

    /// <summary>
    /// Takes a specified number of distinct points from a source
    /// </summary>
    /// <param name="source">The random source</param>
    /// <param name="count">The number of points to take</param>
    /// <typeparam name="T">The element type</typeparam>
    public static HashSet<T> Distinct<T>(this ISource source, int count)
        where T : unmanaged
    {
        var stream = source.Stream<T>();
        var set = stream.Take(count).ToHashSet();
        while(set.Count < count)
            set.WithItems(stream.Take(set.Count - count));
        return set;
    }
}
