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
        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static Select<T> select<T>()
            where T : unmanaged
                => default(Select<T>);

        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static VSelect128<T> vselect<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VSelect128<T>);

        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static VSelect256<T> vselect<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VSelect256<T>);

        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static Select128<T> select<T>(W128 w)
            where T : unmanaged
                => default(Select128<T>);

        [MethodImpl(Inline), Factory(Select), Closures(Closure)]
        public static Select256<T> select<T>(W256 w)
            where T : unmanaged
                => default(Select256<T>);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static Span<T> select<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, ReadOnlySpan<T> c, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(select<T>(), a, b, c, dst);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static ref readonly SpanBlock128<T> select<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> c, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref select<T>(w128).Invoke(a, b, c, dst);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static ref readonly SpanBlock256<T> select<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> c, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref select<T>(w256).Invoke(a, b, c, dst);
    }
}