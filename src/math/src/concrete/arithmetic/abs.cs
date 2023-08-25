//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Computes the absolute value of the source without branching
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static sbyte abs(sbyte a)
        => (sbyte)(a + (a >> 7)^(a >> 7));

    /// <summary>
    /// Returns the source value
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static byte abs(byte a)
        => a;

    /// <summary>
    /// Computes the absolute value of the source without branching
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static short abs(short a)
        => (short)(a + (a >> 15)^(a >> 15));

    /// <summary>
    /// Returns the source value
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static ushort abs(ushort a)
        => a;

    /// <summary>
    /// Computes the absolute value of the source without branching
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static int abs(int a)
        => (a + (a >> 31)^(a >> 31));

    /// <summary>
    /// Returns the source value
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static uint abs(uint a)
        => a;

    /// <summary>
    /// Computes the absolute value of the source without branching
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static long abs(long a)
        => (a + (a >> 63)^(a >> 63));

    /// <summary>
    /// Returns the source value
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static ulong abs(ulong a)
        => a;

    /// <summary>
    /// Computes the absolute value of the source
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static float abs(float a)
        => MathF.Abs(a);

    /// <summary>
    /// Computes the absolute value of the source
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Abs]
    public static double abs(double a)
        => Math.Abs(a);
}
