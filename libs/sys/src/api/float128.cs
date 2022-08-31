//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
       [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<decimal> float128<T>(Span<T> src)
            where T : struct
                => recover<T,decimal>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<decimal> float128<T>(ReadOnlySpan<T> src)
            where T : struct
                => recover<T,decimal>(src);
    }
}