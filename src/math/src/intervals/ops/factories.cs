//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static IntervalKind;

partial struct Intervals
{
    /// <summary>
    /// Defines an interval of specified sort
    /// </summary>
    /// <param name="min">The left endpoint</param>
    /// <param name="max">The right endpoint</param>
    /// <param name="kind">The interval kind</param>
    /// <typeparam name="T"></typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Interval<T> define<T>(T min, T max, IntervalKind kind)
        where T : unmanaged,IEquatable<T>
            => new Interval<T>(min, max, kind);

    /// <summary>
    /// Defines a closed interval [min,max]
    /// </summary>
    /// <param name="min">The inclusive left endpoint</param>
    /// <param name="max">The inclusive right endpoint</param>
    /// <typeparam name="T">The numeric type over which the interval is defined</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Interval<T> closed<T>(T min, T max)
        where T : unmanaged,IEquatable<T>
            => new (min, max, Closed);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Interval<T> lopen<T>(T min, T max)
        where T : unmanaged,IEquatable<T>
            => new (min, max, LeftOpen);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Interval<T> ropen<T>(T min, T max)
        where T : unmanaged,IEquatable<T>
            => new (min, max, RightOpen);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Interval<T> lclosed<T>(T min, T max)
        where T : unmanaged,IEquatable<T>
            => new (min, max, LeftClosed);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Interval<T> rclosed<T>(T min, T max)
        where T : unmanaged,IEquatable<T>
            => new (min, max, RightClosed);

    /// <summary>
    /// Defines an open interval (min,max)
    /// </summary>
    /// <param name="min">The exclusive left endpoint</param>
    /// <param name="max">The exclusive right endpoint</param>
    /// <typeparam name="T">The numeric type over which the interval is defined</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Interval<T> open<T>(T min, T max)
        where T : unmanaged,IEquatable<T>
            => new Interval<T>(min,max, Open);
}
