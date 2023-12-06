//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    [MethodImpl(Inline), Div]
    public static sbyte div(sbyte a, sbyte b)
        => (sbyte)(a / b);

    [MethodImpl(Inline), Div]
    public static byte div(byte a, byte b)
        => (byte)(a / b);

    [MethodImpl(Inline), Div]
    public static short div(short a, short b)
        => (short)(a / b);

    [MethodImpl(Inline), Div]
    public static ushort div(ushort a, ushort b)
        => (ushort)(a / b);

    [MethodImpl(Inline), Div]
    public static int div(int a, int b)
        => a / b;

    [MethodImpl(Inline), Div]
    public static uint div(uint a, uint b)
        => a / b;

    [MethodImpl(Inline), Div]
    public static long div(long a, long b)
        => a / b;

    [MethodImpl(Inline), Div]
    public static ulong div(ulong a, ulong b)
        => a / b;

    [MethodImpl(Inline), Div]
    public static float div(float a, float b)
        => a / b;

    [MethodImpl(Inline), Div]
    public static double div(double a, double b)
        => a / b;
}
