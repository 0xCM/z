//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the arithmetic sum of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Add]
    public static Half add(Half a, Half b)
        => a + b;

    /// <summary>
    /// Computes the arithmetic sum of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Add]
    public static float add(float a, float b)
        => a + b;

    /// <summary>
    /// Computes the arithmetic sum of the source operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Add]
    public static double add(double a, double b)
        => a + b;
}