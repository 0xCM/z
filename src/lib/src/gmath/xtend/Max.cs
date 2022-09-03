//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static byte Max(this byte[] src)
            => gcalc.max(core.@readonly(src));

        [MethodImpl(Inline)]
        public static byte Max(this Span<byte> src)
            => gcalc.max(src.ReadOnly());

        [MethodImpl(Inline)]
        public static byte Max(this ReadOnlySpan<byte> src)
            => gcalc.max(src);

        [MethodImpl(Inline)]
        public static sbyte Max(this sbyte[] src)
            => gcalc.max(core.@readonly(src));

        [MethodImpl(Inline)]
        public static sbyte Max(this Span<sbyte> src)
            => gcalc.max(src.ReadOnly());

        [MethodImpl(Inline)]
        public static sbyte Max(this ReadOnlySpan<sbyte> src)
            => gcalc.max(src);

        [MethodImpl(Inline)]
        public static short Max(this short[] src)
            => gcalc.max(core.@readonly(src));

        [MethodImpl(Inline)]
        public static short Max(this Span<short> src)
            => gcalc.max(src.ReadOnly());

        [MethodImpl(Inline)]
        public static short Max(this ReadOnlySpan<short> src)
            => gcalc.max(src);

        [MethodImpl(Inline)]
        public static ushort Max(this ushort[] src)
            => gcalc.max(core.@readonly(src));

        [MethodImpl(Inline)]
        public static ushort Max(this Span<ushort> src)
            => gcalc.max(src.ReadOnly());

        [MethodImpl(Inline)]
        public static ushort Max(this ReadOnlySpan<ushort> src)
            => gcalc.max(src);

        [MethodImpl(Inline)]
        public static int Max(this int[] src)
            => gcalc.max(core.@readonly(src));

        [MethodImpl(Inline)]
        public static int Max(this Span<int> src)
            => gcalc.max(src.ReadOnly());

        [MethodImpl(Inline)]
        public static int Max(this ReadOnlySpan<int> src)
            => gcalc.max(src);

        [MethodImpl(Inline)]
        public static uint Max(this uint[] src)
            => gcalc.max(core.@readonly(src));

        [MethodImpl(Inline)]
        public static uint Max(this Span<uint> src)
            => gcalc.max(src.ReadOnly());

        [MethodImpl(Inline)]
        public static uint Max(this ReadOnlySpan<uint> src)
            => gcalc.max(src);

        [MethodImpl(Inline)]
        public static long Max(this long[] src)
            => gcalc.max(core.@readonly(src));

        [MethodImpl(Inline)]
        public static long Max(this Span<long> src)
            => gcalc.max(src.ReadOnly());

        [MethodImpl(Inline)]
        public static long Max(this ReadOnlySpan<long> src)
            => gcalc.max(src);

        [MethodImpl(Inline)]
        public static ulong Max(this ulong[] src)
            => gcalc.max(core.@readonly(src));

        [MethodImpl(Inline)]
        public static ulong Max(this Span<ulong> src)
            => gcalc.max(src.ReadOnly());

        [MethodImpl(Inline)]
        public static ulong Max(this ReadOnlySpan<ulong> src)
            => gcalc.max(src);
    }
}