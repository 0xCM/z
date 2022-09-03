//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SortedSpans
    {
        [MethodImpl(Inline)]
        public static SortedSpan<T> define<T>(T[] src)
            => new SortedSpan<T>(src);

        [MethodImpl(Inline)]
        public static SortedSpan<T> define<T>(Span<T> src)
            => new SortedSpan<T>(src);

        [MethodImpl(Inline)]
        public static SortedReadOnlySpan<T> define<T>(ReadOnlySpan<T> src)
            => new SortedReadOnlySpan<T>(src);

    }
}