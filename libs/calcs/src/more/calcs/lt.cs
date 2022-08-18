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
        [MethodImpl(Inline), Factory(Lt), Closures(Closure)]
        public static Lt<T> lt<T>()
            where T : unmanaged
                => default(Lt<T>);

        [MethodImpl(Inline), Factory(Lt), Closures(Closure)]
        public static Lt128<T> lt<T>(W128 w)
            where T : unmanaged
                => default(Lt128<T>);

        [MethodImpl(Inline), Factory(Lt), Closures(Closure)]
        public static Lt256<T> lt<T>(W256 w)
            where T : unmanaged
                => default(Lt256<T>);

        [MethodImpl(Inline), Factory(Lt), Closures(Closure)]
        public static VLt128<T> vlt<T>(W128 w)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Lt), Closures(Closure)]
        public static VLt256<T> vlt<T>(W256 w)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Lt, Closures(Closure)]
        public static Span<bit> lt<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<bit> dst)
            where T : unmanaged
                => gcalc.apply(Calcs.lt<T>(), a, b, dst);

        [MethodImpl(Inline), Lt, Closures(Closure)]
        public static ref readonly SpanBlock128<T> lt<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref lt<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Lt, Closures(Closure)]
        public static ref readonly SpanBlock256<T> lt<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref lt<T>(w256).Invoke(a, b, dst);
    }
}