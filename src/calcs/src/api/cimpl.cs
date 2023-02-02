//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(CImpl), Closures(Closure)]
        public static CImpl<T> cimpl<T>()
            where T : unmanaged
                => default(CImpl<T>);

        [MethodImpl(Inline), Factory(CImpl), Closures(Closure)]
        public static VCImpl128<T> vcimpl<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VCImpl128<T>);

        [MethodImpl(Inline), Factory(CImpl), Closures(Closure)]
        public static VCImpl256<T> vcimpl<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VCImpl256<T>);

        [MethodImpl(Inline), Factory(CImpl), Closures(Closure)]
        public static CImpl128<T> cimpl<T>(W128 w)
            where T : unmanaged
                => default(CImpl128<T>);

        [MethodImpl(Inline), Factory(CImpl), Closures(Closure)]
        public static CImpl256<T> cimpl<T>(W256 w)
            where T : unmanaged
                => default(CImpl256<T>);

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static Span<T> cimpl<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(cimpl<T>(), a, b, dst);

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static SpanBlock128<T> cimpl<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => cimpl<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), CImpl, Closures(Closure)]
        public static SpanBlock256<T> cimpl<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => cimpl<T>(w256).Invoke(a, b, dst);
    }
}