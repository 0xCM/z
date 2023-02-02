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
        [MethodImpl(Inline), Factory(Inc), Closures(Closure)]
        public static Inc<T> inc<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Inc), Closures(Closure)]
        public static VInc128<T> vinc<T>(W128 w)
            where T : unmanaged
                => default(VInc128<T>);

        [MethodImpl(Inline), Factory(Inc), Closures(Closure)]
        public static VInc256<T> vinc<T>(W256 w)
            where T : unmanaged
                => default(VInc256<T>);

        [MethodImpl(Inline), Factory(Inc), Closures(Closure)]
        public static Inc128<T> inc<T>(W128 w)
            where T : unmanaged
                => default(Inc128<T>);

        [MethodImpl(Inline), Factory(Inc), Closures(Closure)]
        public static Inc256<T> inc<T>(W256 w)
            where T : unmanaged
                => default(Inc256<T>);

        [MethodImpl(Inline), Inc, Closures(Closure)]
        public static Span<T> inc<T>(ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(inc<T>(), src, dst);

        [MethodImpl(Inline), Inc, Closures(Closure)]
        public static SpanBlock128<T> inc<T>(SpanBlock128<T> a, SpanBlock128<T> dst)
            where T : unmanaged
                => inc<T>(w128).Invoke(a, dst);

        [MethodImpl(Inline), Inc, Closures(Closure)]
        public static SpanBlock256<T> inc<T>(SpanBlock256<T> a, SpanBlock256<T> dst)
            where T : unmanaged
                => inc<T>(w256).Invoke(a, dst);
    }
}