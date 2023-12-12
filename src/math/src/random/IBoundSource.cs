//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Characterizes a value emitter that supports placing upper and/or lower bounds on the values produced
/// </summary>
/// <typeparam name="T">The production value type</typeparam>
[Free]
public interface IBoundSource<T> : IValueSource<T>
    where T : unmanaged
{
    /// <summary>
    /// Retrieves the next point from the source, constrained by an upper bound
    /// </summary>
    /// <param name="max">The exclusive upper bound</param>
    /// <typeparam name="T">The point type</typeparam>
    T Next(T max);

    /// <summary>
    /// Retrieves the next point from the source, constrained by upper and lower bounds
    /// </summary>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The exclusive max value</param>
    T Next(T min, T max);
}

/// <summary>
/// Characterizes a source that emits parametric value constrained to a specified domain
/// </summary>
[Free]
public interface IBoundSource : ISource
{
    /// <summary>
    /// Retrieves the next point from the source, constrained by an upper bounds
    /// </summary>
    /// <param name="max">The exclusive max value</param>
    /// <typeparam name="T">The point type</typeparam>
    T Next<T>(T max)
        where T : unmanaged;

    /// <summary>
    /// Retrieves the next point from the source, constrained by upper and lower bounds
    /// </summary>
    /// <param name="min">The inclusive min value</param>
    /// <param name="max">The exclusive max value</param>
    /// <typeparam name="T">The point type</typeparam>
    T Next<T>(T min, T max)
        where T : unmanaged;

    /// <summary>
    /// Retrieves the next point from the source, bound within a specified interval
    /// </summary>
    /// <param name="src">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <typeparam name="T">The point type</typeparam>
    T Next<T>(Interval<T> domain)
        where T : unmanaged, IEquatable<T>
            => Next(domain.Left, domain.Right);

    /// <summary>
    /// Retrieves the next point from the source, bound within a specified interval
    /// </summary>
    /// <param name="src">The random source</param>
    /// <param name="domain">The domain of the random variable</param>
    /// <typeparam name="T">The point type</typeparam>
    T Next<T>(ClosedInterval<T> domain)
        where T : unmanaged, IEquatable<T>
            => Next(domain.Min, domain.Max);
}
