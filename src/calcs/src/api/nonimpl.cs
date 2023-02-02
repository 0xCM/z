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
        [MethodImpl(Inline), Factory(NonImpl), Closures(Closure)]
        public static NonImpl<T> nonimpl<T>()
            where T : unmanaged
                => default(NonImpl<T>);

        [MethodImpl(Inline), Factory(NonImpl), Closures(Closure)]
        public static VNonImpl128<T> vnonimpl<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VNonImpl128<T>);

        [MethodImpl(Inline), Factory(NonImpl), Closures(Closure)]
        public static VNonImpl256<T> vnonimpl<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VNonImpl256<T>);

        [MethodImpl(Inline), Factory(NonImpl), Closures(Closure)]
        public static NonImpl128<T> nonimpl<T>(W128 w)
            where T : unmanaged
                => default(NonImpl128<T>);

        [MethodImpl(Inline), Factory(NonImpl), Closures(Closure)]
        public static NonImpl256<T> nonimpl<T>(W256 w)
            where T : unmanaged
                => default(NonImpl256<T>);

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static Span<T> nonimpl<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(nonimpl<T>(), a, b, dst);

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static SpanBlock128<T> nonimpl<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => nonimpl<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static SpanBlock256<T> nonimpl<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => nonimpl<T>(w256).Invoke(a, b, dst);
    }
}