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
        [MethodImpl(Inline), Factory(Or), Closures(Closure)]
        public static Or<T> or<T>()
            where T : unmanaged
                => default(Or<T>);

        [MethodImpl(Inline), Factory(Or), Closures(UnsignedInts)]
        public static BvOr<T> bvor<T>()
            where T : unmanaged
                => sfunc<BvOr<T>>();

        [MethodImpl(Inline), Factory(Or), Closures(Closure)]
        public static VOr128<T> vor<T>(W128 w)
            where T : unmanaged
                => default(VOr128<T>);

        [MethodImpl(Inline), Factory(Or), Closures(Closure)]
        public static VOr256<T> vor<T>(W256 w)
            where T : unmanaged
                => default(VOr256<T>);

        [MethodImpl(Inline), Factory(Or), Closures(Closure)]
        public static Or128<T> or<T>(W128 w)
            where T : unmanaged
                => default(Or128<T>);

        [MethodImpl(Inline), Factory(Or), Closures(Closure)]
        public static Or256<T> or<T>(W256 w)
            where T : unmanaged
                => default(Or256<T>);

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static T or<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var result = default(T);
            for(var i=0; i<src.Length; i++)
                result = or<T>().Invoke(result, core.skip(src,(uint)i));
            return result;
        }

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static Span<T> or<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(or<T>(), a, b, dst);

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static ref readonly SpanBlock128<T> or<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref or<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Or, Closures(Closure)]
        public static ref readonly SpanBlock256<T> or<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref or<T>(w256).Invoke(a, b, dst);
    }
}