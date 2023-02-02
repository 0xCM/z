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
        [MethodImpl(Inline), Factory(Impl), Closures(Closure)]
        public static Impl<T> impl<T>()
            where T : unmanaged
                => default(Impl<T>);

        [MethodImpl(Inline), Factory(Impl), Closures(Closure)]
        public static VImpl128<T> vimpl<T>(W128 w)
            where T : unmanaged
                => default(VImpl128<T>);

        [MethodImpl(Inline), Factory(Impl), Closures(Closure)]
        public static VImpl256<T> vimpl<T>(W256 w)
            where T : unmanaged
                => default(VImpl256<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static Impl128<T> impl<T>(W128 w)
            where T : unmanaged
                => default(Impl128<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static Impl256<T> impl<T>(W256 w)
            where T : unmanaged
                => default(Impl256<T>);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static Span<T> impl<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(impl<T>(), a, b, dst);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static SpanBlock128<T> impl<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => impl<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static SpanBlock256<T> impl<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => impl<T>(w256).Invoke(a, b, dst);
    }
}