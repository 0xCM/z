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
        [MethodImpl(Inline), Factory(CNonImpl), Closures(Closure)]
        public static CNonImpl<T> cnonimpl<T>()
            where T : unmanaged
                => default(CNonImpl<T>);

        [MethodImpl(Inline), Factory(CNonImpl), Closures(Closure)]
        public static VCNonImpl128<T> vcnonimpl<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VCNonImpl128<T>);

        [MethodImpl(Inline), Factory(CNonImpl), Closures(Closure)]
        public static VCNonImpl256<T> vcnonimpl<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VCNonImpl256<T>);

        [MethodImpl(Inline), Factory(CNonImpl), Closures(Closure)]
        public static CNonImpl128<T> cnonimpl<T>(W128 w)
            where T : unmanaged
                => default(CNonImpl128<T>);

        [MethodImpl(Inline), Factory(CNonImpl), Closures(Closure)]
        public static CNonImpl256<T> cnonimpl<T>(W256 w)
            where T : unmanaged
                => default(CNonImpl256<T>);

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static Span<T> cnonimpl<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(cnonimpl<T>(), a, b, dst);

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static SpanBlock128<T> cnonimpl<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => cnonimpl<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static SpanBlock256<T> cnonimpl<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => cnonimpl<T>(w256).Invoke(a, b, dst);
    }
}