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
        [MethodImpl(Inline), Factory(Nonz), Closures(Closure)]
        public static Nonz<T> nonz<T>()
            where T : unmanaged
                => default(Nonz<T>);

        [MethodImpl(Inline), Factory(Nonz), Closures(Closure)]
        public static VNonZ128<T> vnonz<T>(W128 w, T t = default)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Nonz), Closures(Closure)]
        public static VNonZ256<T> vnonz<T>(W256 w, T t = default)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Nonz), Closures(Closure)]
        public static NonZ128<T> nonz<T>(W128 w)
            where T : unmanaged
                => default(NonZ128<T>);

        [MethodImpl(Inline), Factory(Nonz), Closures(Closure)]
        public static NonZ256<T> nonz<T>(W256 w)
            where T : unmanaged
                => default(NonZ256<T>);

        [MethodImpl(Inline), Nonz, Closures(Closure)]
        public static Span<bit> nonz<T>(in SpanBlock128<T> a, Span<bit> dst)
            where T : unmanaged
                => nonz<T>(w128).Invoke(a, dst);

        [MethodImpl(Inline), Nonz, Closures(Closure)]
        public static Span<bit> nonz<T>(in SpanBlock256<T> a, Span<bit> dst)
            where T : unmanaged
                => nonz<T>(w256).Invoke(a, dst);
    }
}