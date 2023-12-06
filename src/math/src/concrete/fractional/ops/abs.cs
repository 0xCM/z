//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the absolute value of the source
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static Half abs(Half a)
        => Half.Abs(a);

    /// <summary>
    /// Computes the absolute value of the source
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static float abs(float a)
        => MathF.Abs(a);

    /// <summary>
    /// Computes the absolute value of the source
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static double abs(double a)
        => Math.Abs(a);
}