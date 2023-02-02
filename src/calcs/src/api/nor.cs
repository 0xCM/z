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
        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static Nor<T> nor<T>()
            where T : unmanaged
                => default(Nor<T>);

        [MethodImpl(Inline), Factory(Nor), Closures(UnsignedInts)]
        public static BvNor<T> bvnor<T>()
            where T : unmanaged
                => sfunc<BvNor<T>>();

        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static VNor128<T> vnor<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VNor128<T>);

        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static VNor256<T> vnor<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VNor256<T>);

        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static Nor128<T> nor<T>(W128 w)
            where T : unmanaged
                => default(Nor128<T>);

        [MethodImpl(Inline), Factory(Nor), Closures(Closure)]
        public static Nor256<T> nor<T>(W256 w)
            where T : unmanaged
                => default(Nor256<T>);

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static Span<T> nor<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(nor<T>(), a, b, dst);

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static SpanBlock128<T> nor<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => nor<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static SpanBlock256<T> nor<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => nor<T>(w256).Invoke(a, b, dst);
    }
}