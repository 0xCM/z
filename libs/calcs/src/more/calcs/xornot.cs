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
        [MethodImpl(Inline), Factory(XorNot), Closures(Closure)]
        public static VXorNot128<T> vxornot<T>(W128 w)
            where T : unmanaged
                => default(VXorNot128<T>);

        [MethodImpl(Inline), Factory(XorNot), Closures(Closure)]
        public static VXorNot256<T> vxornot<T>(W256 w)
            where T : unmanaged
                => default(VXorNot256<T>);

        [MethodImpl(Inline), Factory(XorNot), Closures(Integers)]
        public static XorNot128<T> xornot<T>(W128 w)
            where T : unmanaged
                => default(XorNot128<T>);

        [MethodImpl(Inline), Factory(XorNot), Closures(Integers)]
        public static XorNot256<T> xornot<T>(W256 w)
            where T : unmanaged
                => default(XorNot256<T>);

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static ref readonly SpanBlock128<T> xornot<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref xornot<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static ref readonly SpanBlock256<T> xornot<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref xornot<T>(w256).Invoke(a, b, dst);
    }
}