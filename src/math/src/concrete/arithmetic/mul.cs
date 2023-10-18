//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    [MethodImpl(Inline), Mul]
    public static sbyte mul(sbyte a, sbyte rhs)
        => (sbyte)(a * rhs);

    [MethodImpl(Inline), Mul]
    public static byte mul(byte a, byte b)
        => (byte)(a * b);

    [MethodImpl(Inline), Mul]
    public static short mul(short a, short b)
        => (short)(a * b);

    [MethodImpl(Inline), Mul]
    public static ushort mul(ushort a, ushort b)
        => (ushort)(a * b);

    [MethodImpl(Inline), Mul]
    public static int mul(int a, int b)
        => a * b;

    [MethodImpl(Inline), Mul]
    public static uint mul(uint a, uint b)
        => a * b;

    [MethodImpl(Inline), Mul]
    public static long mul(long a, long b)
        => a * b;

    [MethodImpl(Inline), Mul]
    public static ulong mul(ulong a, ulong b)
        => a * b;

    /// <summary>
    /// Computes the arithmetic product of the operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Mul]
    public static float mul(float a, float b)
        => a * b;

    /// <summary>
    /// Computes the arithmetic product of the operands
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    [MethodImpl(Inline), Mul]
    public static double mul(double a, double b)
        => a * b;
}
