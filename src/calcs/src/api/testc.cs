//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(TestC), Closures(Closure)]
        public static VTestC128<T> vtestc<T>(W128 w, T t = default)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(TestC), Closures(Closure)]
        public static VTestC256<T> vtestc<T>(W256 w, T t = default)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(TestC), Closures(Closure)]
        public static TestC128<T> testc<T>(W128 w)
            where T : unmanaged
                => default(TestC128<T>);

        [MethodImpl(Inline), Factory(TestC), Closures(Closure)]
        public static TestC256<T> testc<T>(W256 w)
            where T : unmanaged
                => default(TestC256<T>);

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static Span<bit> testc<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, Span<bit> dst)
            where T : unmanaged
                => testc<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static Span<bit> testc<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, Span<bit> dst)
            where T : unmanaged
                => testc<T>(w256).Invoke(a, b, dst);
    }
}