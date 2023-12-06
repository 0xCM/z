//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the arithmetic quotient of the first operand over the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Div]
    public static Half div(Half a, Half b)
        => a / b;

    /// <summary>
    /// Computes the arithmetic quotient of the first operand over the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Div]
    public static float div(float a, float b)
        => a / b;

    /// <summary>
    /// Computes the arithmetic quotient of the first operand over the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Div]
    public static double div(double a, double b)
        => a / b;
}