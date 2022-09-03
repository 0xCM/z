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
        [MethodImpl(Inline), Factory(Max), Closures(Closure)]
        public static VMax128<T> vmax<T>(W128 w)
            where T : unmanaged
                => default(VMax128<T>);

        [MethodImpl(Inline), Factory(Max), Closures(Closure)]
        public static VMax256<T> vmax<T>(W256 w)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Max), Closures(Integers)]
        public static Max128<T> max<T>(W128 w)
            where T : unmanaged
                => default(Max128<T>);

        [MethodImpl(Inline), Factory(Max), Closures(Integers)]
        public static Max256<T> max<T>(W256 w)
            where T : unmanaged
                => default(Max256<T>);

        [MethodImpl(Inline), Factory(Max), Closures(Integers)]
        public static Max<T> max<T>()
            where T : unmanaged
                => default(Max<T>);

        [MethodImpl(Inline), Max, Closures(Closure)]
        public static ref readonly SpanBlock128<T> max<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref max<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Max, Closures(Closure)]
        public static ref readonly SpanBlock256<T> max<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref max<T>(w256).Invoke(a, b, dst);
    }
}