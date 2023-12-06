//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the base-2 log of the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static Half log2(Half src)
        => Half.Log2(src);

    /// <summary>
    /// Computes the base-2 log of the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static float log2(float src)
        => MathF.Log2(src);

    /// <summary>
    /// Computes the base-2 log of the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static double log2(double src)
        => Math.Log2(src);
}