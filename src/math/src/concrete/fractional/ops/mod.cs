//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    [MethodImpl(Inline), Mod]
    public static Half mod(Half a, Half b)
        => a % b;

    [MethodImpl(Inline), Mod]
    public static float mod(float a, float b)
        => a % b;

    [MethodImpl(Inline), Mod]
    public static double mod(double a, double b)
        => a % b;

    /// <summary>
    /// Computes the remainder of the quotient of the operands
    /// </summary>
    /// <param name="a">The dividend</param>
    /// <param name="b">The divisor</param>
    [MethodImpl(Inline), Op]
    public static float fmod(float a, float b)
        => MathF.IEEERemainder(a,b);

    /// <summary>
    /// Computes the remainder of the quotient of the operands
    /// </summary>
    /// <param name="a">The dividend</param>
    /// <param name="b">The divisor</param>
    [MethodImpl(Inline), Op]
    public static double fmod(double a, double b)
        => Math.IEEERemainder(a,b);

}