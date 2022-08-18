//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static float Avg(this Span<float> src)
            => gcalc.favg<float>(src);

        [MethodImpl(Inline)]
        public static double Avg(this Span<double> src)
            => gcalc.favg<double>(src);

        [MethodImpl(Inline), Op]
        public static float Avg(this ReadOnlySpan<float> src)
            => gcalc.favg(src);

        [MethodImpl(Inline), Op]
        public static double Avg(this ReadOnlySpan<double> src)
            => gcalc.favg(src);
    }
}