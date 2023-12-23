//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    [MethodImpl(Inline), Max]
    public static sbyte max(sbyte a, sbyte b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static byte max(byte a, byte b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static short max(short a, short b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static ushort max(ushort a, ushort b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static int max(int a, int b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static uint max(uint a, uint b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static long max(long a, long b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static ulong max(ulong a, ulong b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static Int128 max(Int128 a, Int128 b)
        => a > b ? a : b;

    [MethodImpl(Inline), Max]
    public static UInt128 max(UInt128 a, UInt128 b)
        => a > b ? a : b;

}
