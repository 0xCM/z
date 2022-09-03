//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static byte Min(this byte[] src)
            => gcalc.min(core.@readonly(src));

        [MethodImpl(Inline)]
        public static byte Min(this Span<byte> src)
            => gcalc.min(src.ReadOnly());

        [MethodImpl(Inline)]
        public static byte Min(this ReadOnlySpan<byte> src)
            => gcalc.min(src);

        [MethodImpl(Inline)]
        public static sbyte Min(this sbyte[] src)
            => gcalc.min(core.@readonly(src));

        [MethodImpl(Inline)]
        public static sbyte Min(this Span<sbyte> src)
            => gcalc.min(src.ReadOnly());

        [MethodImpl(Inline)]
        public static sbyte Min(this ReadOnlySpan<sbyte> src)
            => gcalc.min(src);

        [MethodImpl(Inline)]
        public static short Min(this short[] src)
            => gcalc.min(core.@readonly(src));

        [MethodImpl(Inline)]
        public static short Min(this Span<short> src)
            => gcalc.min(src.ReadOnly());

        [MethodImpl(Inline)]
        public static short Min(this ReadOnlySpan<short> src)
            => gcalc.min(src);

        [MethodImpl(Inline)]
        public static ushort Min(this ushort[] src)
            => gcalc.min(core.@readonly(src));

        [MethodImpl(Inline)]
        public static ushort Min(this Span<ushort> src)
            => gcalc.min(src.ReadOnly());

        [MethodImpl(Inline)]
        public static ushort Min(this ReadOnlySpan<ushort> src)
            => gcalc.min(src);

        [MethodImpl(Inline)]
        public static int Min(this int[] src)
            => gcalc.min(core.@readonly(src));

        [MethodImpl(Inline)]
        public static int Min(this Span<int> src)
            => gcalc.min(src.ReadOnly());

        [MethodImpl(Inline)]
        public static int Min(this ReadOnlySpan<int> src)
            => gcalc.min(src);

        [MethodImpl(Inline)]
        public static uint Min(this uint[] src)
            => gcalc.min(core.@readonly(src));

        [MethodImpl(Inline)]
        public static uint Min(this Span<uint> src)
            => gcalc.min(src.ReadOnly());

        [MethodImpl(Inline)]
        public static uint Min(this ReadOnlySpan<uint> src)
            => gcalc.min(src);

        [MethodImpl(Inline)]
        public static long Min(this long[] src)
            => gcalc.min(core.@readonly(src));

        [MethodImpl(Inline)]
        public static long Min(this Span<long> src)
            => gcalc.min(src.ReadOnly());

        [MethodImpl(Inline)]
        public static long Min(this ReadOnlySpan<long> src)
            => gcalc.min(src);

        [MethodImpl(Inline)]
        public static ulong Min(this ulong[] src)
            => gcalc.min(core.@readonly(src));

        [MethodImpl(Inline)]
        public static ulong Min(this Span<ulong> src)
            => gcalc.min(src.ReadOnly());

        [MethodImpl(Inline)]
        public static ulong Min(this ReadOnlySpan<ulong> src)
            => gcalc.min(src);
    }
}