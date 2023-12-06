//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the cube root of the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static Half cbrt(Half src)
        => Half.Cbrt(src);

    /// <summary>
    /// Computes the cube root of the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static float cbrt(float src)
        => MathF.Cbrt(src);

    /// <summary>
    /// Computes the cube root of the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static double cbrt(double src)
        => Math.Cbrt(src);
}