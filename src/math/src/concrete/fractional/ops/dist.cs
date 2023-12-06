//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the nonnegative distance between two values
    /// </summary>
    /// <param name="a">The first number</param>
    /// <param name="b">The second number</param>
    [MethodImpl(Inline), Dist]
    public static Half dist(Half a, Half b)
        => a >= b ? a - b : b - a;

    /// <summary>
    /// Computes the nonnegative distance between two values
    /// </summary>
    /// <param name="a">The first number</param>
    /// <param name="b">The second number</param>
    [MethodImpl(Inline), Dist]
    public static float dist(float a, float b)
        => a >= b ? a - b : b - a;

    /// <summary>
    /// Computes the nonnegative distance between two values
    /// </summary>
    /// <param name="a">The first number</param>
    /// <param name="b">The second number</param>
    [MethodImpl(Inline), Dist]
    public static double dist(double a, double b)
        => a >= b ? a - b : b - a;
}