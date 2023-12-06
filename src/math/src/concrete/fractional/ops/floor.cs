//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the largest integral value less than or equal to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static Half floor(Half src)
        => Half.Floor(src);

    /// <summary>
    /// Computes the largest integral value less than or equal to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static float floor(float src)
        => MathF.Floor(src);

    /// <summary>
    /// Computes the largest integral value less than or equal to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static double floor(double src)
        => Math.Floor(src);
}