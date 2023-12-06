//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Increments the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Inc]
    public static Half inc(Half src)
        => ++src;

    /// <summary>
    /// Increments the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Inc]
    public static float inc(float src)
        => ++src;

    /// <summary>
    /// Increments the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Inc]
    public static double inc(double src)
        => ++src;
}