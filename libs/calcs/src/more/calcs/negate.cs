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
    using static SFx;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Negate), Closures(Closure)]
        public static Negate<T> negate<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Negate), Closures(Closure)]
        public static Negate128<T> negate<T>(W128 w)
            where T : unmanaged
                => default(Negate128<T>);

        [MethodImpl(Inline), Factory(Negate), Closures(Closure)]
        public static Negate256<T> negate<T>(W256 w)
            where T : unmanaged
                => default(Negate256<T>);

        [MethodImpl(Inline), Factory(Negate), Closures(Closure)]
        public static VNegate128<T> vnegate<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VNegate128<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VNegate256<T> vnegate<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VNegate256<T>);

        [MethodImpl(Inline), Negate, Closures(Closure)]
        public static Span<T> negate<T>(ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(negate<T>(), src, dst);

        [MethodImpl(Inline), Negate, Closures(Closure)]
        public static ref readonly SpanBlock128<T> negate<T>(in SpanBlock128<T> a, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref negate<T>(w128).Invoke(a, dst);

        [MethodImpl(Inline), Negate, Closures(Closure)]
        public static ref readonly SpanBlock256<T> negate<T>(in SpanBlock256<T> a, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref negate<T>(w256).Invoke(a, dst);
    }
}