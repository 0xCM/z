//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Computes the base-e log of the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static Half ln(Half src)
        => Half.Log(src);

    /// <summary>
    /// Computes the base-e log of the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static float ln(float src)
        => MathF.Log(src);

    /// <summary>
    /// Computes the base-e log of the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Op]
    public static double ln(double src)
        => Math.Log(src);
}