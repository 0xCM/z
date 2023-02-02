//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static SFx;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Not), Closures(Closure)]
        public static Not<T> not<T>()
            where T : unmanaged
                => default(Not<T>);

        [MethodImpl(Inline), Factory(Not), Closures(Closure)]
        public static BvNot<T> bvnot<T>()
            where T : unmanaged
                => sfunc<BvNot<T>>();

        [MethodImpl(Inline), Factory(Not), Closures(Closure)]
        public static VNot128<T> vnot<T>(W128 w)
            where T : unmanaged
                => default(VNot128<T>);

        [MethodImpl(Inline), Factory(Not), Closures(Closure)]
        public static VNot256<T> vnot<T>(W256 w)
            where T : unmanaged
                => default(VNot256<T>);

        [MethodImpl(Inline), Factory(Not), Closures(Closure)]
        public static Not128<T> not<T>(W128 w)
            where T : unmanaged
                => default(Not128<T>);

        [MethodImpl(Inline), Factory(Not), Closures(Closure)]
        public static Not256<T> not<T>(W256 w)
            where T : unmanaged
                => default(Not256<T>);

        [MethodImpl(Inline), Not, Closures(Closure)]
        public static Span<T> not<T>(ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(not<T>(), src, dst);

        [MethodImpl(Inline), Not, Closures(Closure)]
        public static SpanBlock128<T> not<T>(SpanBlock128<T> a, SpanBlock128<T> dst)
            where T : unmanaged
                => not<T>(w128).Invoke(a, dst);

        [MethodImpl(Inline), Not, Closures(Closure)]
        public static SpanBlock256<T> not<T>(SpanBlock256<T> a, SpanBlock256<T> dst)
            where T : unmanaged
                => not<T>(w256).Invoke(a, dst);

    }
}