//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void Iter<T>(this Span<T> src, Action<T> f)
            => iter(src, f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void Iter<T>(this ReadOnlySpan<T> src, Action<T> f)
            => iter(src, f);
    }
}