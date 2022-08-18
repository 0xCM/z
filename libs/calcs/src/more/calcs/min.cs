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
        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static Min<T> min<T>()
            where T : unmanaged
                => default(Min<T>);

        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static VMin128<T> vmin<T>(W128 w)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static VMin256<T> vmin<T>(W256 w)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static Min128<T> min<T>(W128 w)
            where T : unmanaged
                => default(Min128<T>);

        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static Min256<T> min<T>(W256 w)
            where T : unmanaged
                => default(Min256<T>);

        [MethodImpl(Inline), Min, Closures(Closure)]
        public static ref readonly SpanBlock128<T> min<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref min<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Min, Closures(Closure)]
        public static ref readonly SpanBlock256<T> min<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref min<T>(w256).Invoke(a, b, dst);
    }
}