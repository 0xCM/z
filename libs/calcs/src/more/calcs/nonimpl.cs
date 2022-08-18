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
        public static ref readonly SpanBlock128<T> nonimpl<T>(in SpanBlock128<T> a, in SpanBlock128<T> b, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref nonimpl<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static ref readonly SpanBlock256<T> nonimpl<T>(in SpanBlock256<T> a, in SpanBlock256<T> b, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref nonimpl<T>(w256).Invoke(a, b, dst);
    }
}