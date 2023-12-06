//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Negates the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Negate]
    public static Half negate(Half src)
        => -src;

    /// <summary>
    /// Negates the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Negate]
    public static float negate(float src)
        => -src;

    /// <summary>
    /// Negates the operand
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Negate]
    public static double negate(double src)
        => -src;
}