//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CalcHosts;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(TestZ), Closures(Closure)]
        public static VTestZ128<T> vtestz<T>(W128 w, T t = default)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(TestZ), Closures(Closure)]
        public static VTestZ256<T> vtestz<T>(W256 w, T t = default)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(TestZ), Closures(Closure)]
        public static TestZ128<T> testz<T>(W128 w)
            where T : unmanaged
                => default(TestZ128<T>);

        [MethodImpl(Inline), Factory(TestZ), Closures(Closure)]
        public static TestZ256<T> testz<T>(W256 w)
            where T : unmanaged
                => default(TestZ256<T>);

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static Span<bit> testz<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, Span<bit> dst)
            where T : unmanaged
                => testz<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), TestZ, Closures(Closure)]
        public static Span<bit> testz<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, Span<bit> dst)
            where T : unmanaged
                => testz<T>(w256).Invoke(a, b, dst);
    }
}