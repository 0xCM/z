//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class fmath
{
    /// <summary>
    /// Decrements the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Dec]
    public static Half dec(Half src)
        => --src;

    /// <summary>
    /// Decrements the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Dec]
    public static float dec(float src)
        => --src;

    /// <summary>
    /// Decrements the source value
    /// </summary>
    /// <param name="src">The source value</param>
    [MethodImpl(Inline), Dec]
    public static double dec(double src)
        => --src;
}