//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static T[] OrderBy<T,K>(this ReadOnlySpan<T> src, Func<T,K> f)
            => src.ToArray().OrderBy(f);

        public static T[] OrderBy<T,K>(this Span<T> src, Func<T,K> f)
            => src.ToArray().OrderBy(f);
    }
}