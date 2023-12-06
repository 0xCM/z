//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the square root of the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Sqrt]
    public static Half sqrt(Half src)
        => Half.Sqrt(src);

    /// <summary>
    /// Computes the square root of the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Sqrt]
    public static float sqrt(float src)
        => MathF.Sqrt(src);

    /// <summary>
    /// Computes the square root of the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Sqrt]
    public static double sqrt(double src)
        => Math.Sqrt(src);
}