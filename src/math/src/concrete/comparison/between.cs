//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Defines the test between:bit := (x >= min) && (x <= max)
    /// </summary>
    /// <param name="src">The test value</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The inclusive upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(byte src, byte min, byte max)
        => src >= min && src <= max;

    /// <summary>
    /// Defines the test between:bit := (x >= min) && (x <= max)
    /// </summary>
    /// <param name="src">The test value</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The inclusive upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(sbyte src, sbyte min, sbyte max)
        => src >= min && src <= max;

    /// <summary>
    /// Defines the test between:bit := (x >= min) && (x <= max)
    /// </summary>
    /// <param name="src">The test value</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The inclusive upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(short src, short min, short max)
        => src >= min && src <= max;

    /// <summary>
    /// Defines the test between:bit := (x >= min) && (x <= max)
    /// </summary>
    /// <param name="src">The test value</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The inclusive upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(ushort src, ushort min, ushort max)
        => src >= min && src <= max;

    /// <summary>
    /// Defines the test between:bit := (x >= min) && (x <= max)
    /// </summary>
    /// <param name="src">The test value</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The inclusive upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(int src, int min, int max)
        => src >= min && src <= max;

    /// <summary>
    /// Defines the test between:bit := (x >= min) && (x <= max)
    /// </summary>
    /// <param name="src">The test value</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The inclusive upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(uint src, uint min, uint max)
        => src >= min && src <= max;

    /// <summary>
    /// Defines the test between:bit := (x >= min) && (x <= max)
    /// </summary>
    /// <param name="src">The test value</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The inclusive upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(long src, long min, long max)
        => src >= min && src <= max;

    /// <summary>
    /// Defines the test between:bit := (x >= min) && (x <= max)
    /// </summary>
    /// <param name="src">The test value</param>
    /// <param name="min">The inclusive lower bound</param>
    /// <param name="max">The inclusive upper bound</param>
    [MethodImpl(Inline), Between]
    public static bit between(ulong src, ulong min, ulong max)
        => src >= min && src <= max;
}
