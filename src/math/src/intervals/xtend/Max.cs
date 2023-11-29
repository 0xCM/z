//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XTend
{
    [MethodImpl(Inline)]
    public static byte Max(this byte[] src)
        => gmath.max(@readonly(src));

    [MethodImpl(Inline)]
    public static byte Max(this Span<byte> src)
        => gmath.max(src.ReadOnly());

    [MethodImpl(Inline)]
    public static byte Max(this ReadOnlySpan<byte> src)
        => gmath.max(src);

    [MethodImpl(Inline)]
    public static sbyte Max(this sbyte[] src)
        => gmath.max(@readonly(src));

    [MethodImpl(Inline)]
    public static sbyte Max(this Span<sbyte> src)
        => gmath.max(src.ReadOnly());

    [MethodImpl(Inline)]
    public static sbyte Max(this ReadOnlySpan<sbyte> src)
        => gmath.max(src);

    [MethodImpl(Inline)]
    public static short Max(this short[] src)
        => gmath.max(@readonly(src));

    [MethodImpl(Inline)]
    public static short Max(this Span<short> src)
        => gmath.max(src.ReadOnly());

    [MethodImpl(Inline)]
    public static short Max(this ReadOnlySpan<short> src)
        => gmath.max(src);

    [MethodImpl(Inline)]
    public static ushort Max(this ushort[] src)
        => gmath.max(@readonly(src));

    [MethodImpl(Inline)]
    public static ushort Max(this Span<ushort> src)
        => gmath.max(src.ReadOnly());

    [MethodImpl(Inline)]
    public static ushort Max(this ReadOnlySpan<ushort> src)
        => gmath.max(src);

    [MethodImpl(Inline)]
    public static int Max(this int[] src)
        => gmath.max(@readonly(src));

    [MethodImpl(Inline)]
    public static int Max(this Span<int> src)
        => gmath.max(src.ReadOnly());

    [MethodImpl(Inline)]
    public static int Max(this ReadOnlySpan<int> src)
        => gmath.max(src);

    [MethodImpl(Inline)]
    public static uint Max(this uint[] src)
        => gmath.max(@readonly(src));

    [MethodImpl(Inline)]
    public static uint Max(this Span<uint> src)
        => gmath.max(src.ReadOnly());

    [MethodImpl(Inline)]
    public static uint Max(this ReadOnlySpan<uint> src)
        => gmath.max(src);

    [MethodImpl(Inline)]
    public static long Max(this long[] src)
        => gmath.max(@readonly(src));

    [MethodImpl(Inline)]
    public static long Max(this Span<long> src)
        => gmath.max(src.ReadOnly());

    [MethodImpl(Inline)]
    public static long Max(this ReadOnlySpan<long> src)
        => gmath.max(src);

    [MethodImpl(Inline)]
    public static ulong Max(this ulong[] src)
        => gmath.max(@readonly(src));

    [MethodImpl(Inline)]
    public static ulong Max(this Span<ulong> src)
        => gmath.max(src.ReadOnly());

    [MethodImpl(Inline)]
    public static ulong Max(this ReadOnlySpan<ulong> src)
        => gmath.max(src);
}
