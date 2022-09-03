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
        public static ref readonly SpanBlock128<T> impl<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref impl<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static ref readonly SpanBlock256<T> impl<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref impl<T>(w256).Invoke(a, b, dst);
    }
}