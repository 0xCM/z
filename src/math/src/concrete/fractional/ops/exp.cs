//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Raises e to a specified exponent
    /// </summary>
    /// <param name="pow">The exponent</param>
    [MethodImpl(Inline), Op]
    public static Half exp(Half pow)
        => Half.Exp(pow);

    /// <summary>
    /// Raises e to a specified exponent
    /// </summary>
    /// <param name="pow">The exponent</param>
    [MethodImpl(Inline), Op]
    public static float exp(float pow)
        => MathF.Exp(pow);

    /// <summary>
    /// Raises e to a specified exponent
    /// </summary>
    /// <param name="pow">The exponent</param>
    [MethodImpl(Inline), Op]
    public static double exp(double pow)
        => Math.Exp(pow);
}