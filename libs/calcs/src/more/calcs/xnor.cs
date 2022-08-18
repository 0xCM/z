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
        [MethodImpl(Inline), Factory, Closures(Integers)]
        public static Xnor<T> xnor<T>()
            where T : unmanaged
                => default(Xnor<T>);

        [MethodImpl(Inline), Factory(Xnor), Closures(UnsignedInts)]
        public static BvXnor<T> bvxnor<T>()
            where T : unmanaged
                => sfunc<BvXnor<T>>();

        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static VXnor128<T> vxnor<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VXnor128<T>);

        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static VXnor256<T> vxnor<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VXnor256<T>);

        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static Xnor128<T> xnor<T>(W128 w)
            where T : unmanaged
                => default(Xnor128<T>);

        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static Xnor256<T> xnor<T>(W256 w)
            where T : unmanaged
                => default(Xnor256<T>);

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static Span<T> xnor<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(xnor<T>(), a, b, dst);

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static ref readonly SpanBlock128<T> xnor<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref xnor<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static ref readonly SpanBlock256<T> xnor<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref xnor<T>(w256).Invoke(a, b, dst);
    }
}