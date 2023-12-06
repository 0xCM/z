//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the log of the source value relative to an optionally-specified base
    /// which otherwise defaults to base-10
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="b">The log base</param>
    [MethodImpl(Inline), Op]
    public static Half log(Half src, Half? b = null)
        => Half.Log(src, b ?? (Half)10);

    /// <summary>
    /// Computes the log of the source value relative to an optionally-specified base
    /// which otherwise defaults to base-10
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="b">The log base</param>
    [MethodImpl(Inline), Op]
    public static float log(float src, float? b = null)
        => MathF.Log(src, b ?? 10);

    /// <summary>
    /// Computes the log of the source value relative to an optionally-specified base
    /// which otherwise defaults to base-10
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="b">The log base</param>
    [MethodImpl(Inline), Op]
    public static double log(double src, double? b = null)
        => Math.Log(src, b ?? 10);
}