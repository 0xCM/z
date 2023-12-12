//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public static class PolyRaze
{
    const NumericKind Closure = AllNumeric;

    /// <summary>
    /// Produces an array of random values
    /// </summary>
    /// <param name="src">The random source</param>
    /// <param name="length">The length of the produced array</param>
    /// <param name="domain">An optional domain to which values are constrained</param>
    /// <param name="filter">An optional filter that refines the domain</param>
    /// <typeparam name="T">The generated value type</typeparam>
    [Op, Closures(Closure)]
    public static T[] Array<T>(this ISource src, int length)
        where T : unmanaged
            => src.Stream<T>().TakeArray(length);

    /// <summary>
    /// Produces an array of random values
    /// </summary>
    /// <param name="src">The random source</param>
    /// <param name="length">The length of the produced array</param>
    /// <param name="domain">An optional domain to which values are constrained</param>
    /// <param name="filter">An optional filter that refines the domain</param>
    /// <typeparam name="T">The generated value type</typeparam>
    [Op, Closures(Closure)]
    public static T[] Array<T>(this ISource src, uint length)
        where T : unmanaged
            => src.Stream<T>().TakeArray((int)length);

    /// <summary>
    /// Produces an array of random values
    /// </summary>
    /// <param name="src">The random source</param>
    /// <param name="length">The length of the produced array</param>
    /// <param name="domain">An optional domain to which values are constrained</param>
    /// <param name="filter">An optional filter that refines the domain</param>
    /// <typeparam name="T">The generated value type</typeparam>
    [Op, Closures(Closure)]
    public static T[] Array<T>(this IBoundSource src, int length, Interval<T> domain)
        where T : unmanaged, IEquatable<T>
            => src.Stream(domain).TakeArray(length);

    /// <summary>
    /// Produces an array of random values between specified lower and upper bounds
    /// </summary>
    /// <param name="src">The random source</param>
    /// <param name="length">The length of the produced array</param>
    /// <param name="min">The inclusive minimum potential value</param>
    /// <param name="min">The exclusive maximum potential value</param>
    /// <param name="filter">An optional filter that refines the domain</param>
    /// <typeparam name="T">The generated value type</typeparam>
    [Op, Closures(Closure)]
    public static T[] Array<T>(this IBoundSource src, int length, T min, T max, Func<T,bool> filter)
        where T : unmanaged, IEquatable<T>
            => src.Stream((min,max),filter).TakeArray(length);

    /// <summary>
    /// Produces an array of random values between specified lower and upper bounds
    /// </summary>
    /// <param name="src">The random source</param>
    /// <param name="length">The length of the produced array</param>
    /// <param name="min">The inclusive minimum potential value</param>
    /// <param name="min">The exclusive maximum potential value</param>
    /// <param name="filter">An optional filter that refines the domain</param>
    /// <typeparam name="T">The generated value type</typeparam>
    [Op, Closures(Closure)]
    public static T[] Array<T>(this IBoundSource src, int length, T min, T max)
        where T : unmanaged, IEquatable<T>
            => src.Array<T>(length, (min, max));
}
