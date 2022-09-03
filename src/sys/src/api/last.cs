//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T last<T>(T[] src)
             => ref seek(src, src.Length - 1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T last<T>(Span<T> src)
            => ref seek(src, src.Length - 1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T last<T>(ReadOnlySpan<T> src)
            => ref skip(src, src.Length - 1);
    }
}