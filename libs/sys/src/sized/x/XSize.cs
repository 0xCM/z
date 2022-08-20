//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Sized;

    public static class XDataSize
    {
        [MethodImpl(Inline), Op]
        public static DataSize Sum(this ReadOnlySpan<DataSize> src)
            => sum(src);

        [MethodImpl(Inline), Op]
        public static DataSize Sum(this DataSize[] src)
            => sum(src);

        [MethodImpl(Inline), Op]
        public static DataSize Sum(this Span<DataSize> src)
            => sum(src);

        [MethodImpl(Inline), Op]
        public static DataSize Max(this ReadOnlySpan<DataSize> src)
            => max(src);

        [MethodImpl(Inline), Op]
        public static DataSize Max(this DataSize[] src)
            => max(src);

        [MethodImpl(Inline), Op]
        public static DataSize Max(this Span<DataSize> src)
            => max(src);

        [MethodImpl(Inline), Op]
        public static DataSize Min(this ReadOnlySpan<DataSize> src)
            => min(src);

        [MethodImpl(Inline), Op]
        public static DataSize Min(this DataSize[] src)
            => min(src);

        [MethodImpl(Inline), Op]
        public static DataSize Min(this Span<DataSize> src)
            => min(src);
    }
}