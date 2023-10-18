//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    [MethodImpl(Inline), LtEq]
    public static bit le(sbyte a, sbyte b)
        => a <= b;

    [MethodImpl(Inline), LtEq]
    public static bit le(byte a, byte b)
        => a <= b;

    [MethodImpl(Inline), LtEq]
    public static bit le(short a, short b)
        => a <= b;

    [MethodImpl(Inline), LtEq]
    public static bit le(ushort a, ushort b)
        => a <= b;

    [MethodImpl(Inline), LtEq]
    public static bit le(int a, int b)
        => a <= b;

    [MethodImpl(Inline), LtEq]
    public static bit le(uint a, uint b)
        => a <= b;

    [MethodImpl(Inline), LtEq]
    public static bit le(long a, long b)
        => a <= b;

    [MethodImpl(Inline), LtEq]
    public static bit le(ulong a, ulong b)
        => a <= b;
}
