//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static byte Sum(this ReadOnlySpan<byte> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static sbyte Sum(this ReadOnlySpan<sbyte> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static short Sum(this ReadOnlySpan<short> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ushort Sum(this ReadOnlySpan<ushort> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static int Sum(this ReadOnlySpan<int> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static uint Sum(this ReadOnlySpan<uint> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ulong Sum(this ReadOnlySpan<ulong> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static long Sum(this ReadOnlySpan<long> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static float Sum(this ReadOnlySpan<float> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static double Sum(this ReadOnlySpan<double> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this ReadOnlySpan<byte> src)
            => gcalc.sumzx(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this ReadOnlySpan<sbyte> src)
            => gcalc.sumsx(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this ReadOnlySpan<ushort> src)
            => gcalc.sumzx(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this ReadOnlySpan<short> src)
            => gcalc.sumsx(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this ReadOnlySpan<uint> src)
            => gcalc.sumzx(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this ReadOnlySpan<int> src)
            => gcalc.sumsx(src);

        [MethodImpl(Inline), Op]
        public static byte Sum(this Span<byte> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static sbyte Sum(this Span<sbyte> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static short Sum(this Span<short> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ushort Sum(this Span<ushort> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static int Sum(this Span<int> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static uint Sum(this Span<uint> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ulong Sum(this Span<ulong> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static long Sum(this Span<long> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static float Sum(this Span<float> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static double Sum(this Span<double> src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this Span<byte> src)
            => gcalc.sumzx<byte>(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this Span<sbyte> src)
            => gcalc.sumsx<sbyte>(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this Span<ushort> src)
            => gcalc.sumzx<ushort>(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this Span<short> src)
            => gcalc.sumsx<short>(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this Span<uint> src)
            => gcalc.sumzx<uint>(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this Span<int> src)
            => gcalc.sumsx<int>(src);

        [MethodImpl(Inline), Op]
        public static byte Sum(this byte[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static sbyte Sum(this sbyte[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static short Sum(this short[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ushort Sum(this ushort[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static int Sum(this int[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static uint Sum(this uint[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ulong Sum(this ulong[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static long Sum(this long[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static float Sum(this float[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static double Sum(this double[] src)
            => gcalc.sum(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this byte[] src)
            => gcalc.sumzx<byte>(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this sbyte[] src)
            => gcalc.sumsx<sbyte>(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this ushort[] src)
            => gcalc.sumzx<ushort>(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this short[] src)
            => gcalc.sumsx<short>(src);

        [MethodImpl(Inline), Op]
        public static ulong SumZx(this uint[] src)
            => gcalc.sumzx<uint>(src);

        [MethodImpl(Inline), Op]
        public static long SumSx(this int[] src)
            => gcalc.sumsx<int>(src);
    }
}