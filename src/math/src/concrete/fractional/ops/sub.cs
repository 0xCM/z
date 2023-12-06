//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the arithmetic difference between the first operand and the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Sub]
    public static Half sub(Half a, Half b)
        => a - b;

    /// <summary>
    /// Computes the arithmetic difference between the first operand and the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Sub]
    public static float sub(float a, float b)
        => a - b;

    /// <summary>
    /// Computes the arithmetic difference between the first operand and the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Sub]
    public static double sub(double a, double b)
        => a - b;
}