//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XTend
{
    [MethodImpl(Inline)]
    public static byte Min(this byte[] src)
        => gmath.min(@readonly(src));

    [MethodImpl(Inline)]
    public static byte Min(this Span<byte> src)
        => gmath.min(src.ReadOnly());

    [MethodImpl(Inline)]
    public static byte Min(this ReadOnlySpan<byte> src)
        => gmath.min(src);

    [MethodImpl(Inline)]
    public static sbyte Min(this sbyte[] src)
        => gmath.min(@readonly(src));

    [MethodImpl(Inline)]
    public static sbyte Min(this Span<sbyte> src)
        => gmath.min(src.ReadOnly());

    [MethodImpl(Inline)]
    public static sbyte Min(this ReadOnlySpan<sbyte> src)
        => gmath.min(src);

    [MethodImpl(Inline)]
    public static short Min(this short[] src)
        => gmath.min(@readonly(src));

    [MethodImpl(Inline)]
    public static short Min(this Span<short> src)
        => gmath.min(src.ReadOnly());

    [MethodImpl(Inline)]
    public static short Min(this ReadOnlySpan<short> src)
        => gmath.min(src);

    [MethodImpl(Inline)]
    public static ushort Min(this ushort[] src)
        => gmath.min(@readonly(src));

    [MethodImpl(Inline)]
    public static ushort Min(this Span<ushort> src)
        => gmath.min(src.ReadOnly());

    [MethodImpl(Inline)]
    public static ushort Min(this ReadOnlySpan<ushort> src)
        => gmath.min(src);

    [MethodImpl(Inline)]
    public static int Min(this int[] src)
        => gmath.min(@readonly(src));

    [MethodImpl(Inline)]
    public static int Min(this Span<int> src)
        => gmath.min(src.ReadOnly());

    [MethodImpl(Inline)]
    public static int Min(this ReadOnlySpan<int> src)
        => gmath.min(src);

    [MethodImpl(Inline)]
    public static uint Min(this uint[] src)
        => gmath.min(@readonly(src));

    [MethodImpl(Inline)]
    public static uint Min(this Span<uint> src)
        => gmath.min(src.ReadOnly());

    [MethodImpl(Inline)]
    public static uint Min(this ReadOnlySpan<uint> src)
        => gmath.min(src);

    [MethodImpl(Inline)]
    public static long Min(this long[] src)
        => gmath.min(@readonly(src));

    [MethodImpl(Inline)]
    public static long Min(this Span<long> src)
        => gmath.min(src.ReadOnly());

    [MethodImpl(Inline)]
    public static long Min(this ReadOnlySpan<long> src)
        => gmath.min(src);

    [MethodImpl(Inline)]
    public static ulong Min(this ulong[] src)
        => gmath.min(@readonly(src));

    [MethodImpl(Inline)]
    public static ulong Min(this Span<ulong> src)
        => gmath.min(src.ReadOnly());

    [MethodImpl(Inline)]
    public static ulong Min(this ReadOnlySpan<ulong> src)
        => gmath.min(src);
}
