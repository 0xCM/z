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
        [MethodImpl(Inline), Factory(Nand), Closures(Closure)]
        public static Nand<T> nand<T>()
            where T : unmanaged
                => default(Nand<T>);

        [MethodImpl(Inline), Factory(Nand), Closures(UnsignedInts)]
        public static BvNand<T> bvnand<T>()
            where T : unmanaged
                => sfunc<BvNand<T>>();

        [MethodImpl(Inline), Factory(Nand), Closures(Closure)]
        public static VNand128<T> vnand<T>(W128 w)
            where T : unmanaged
                => default(VNand128<T>);

        [MethodImpl(Inline), Factory(Nand), Closures(Closure)]
        public static VNand256<T> vnand<T>(W256 w)
            where T : unmanaged
                => default(VNand256<T>);

        [MethodImpl(Inline), Factory(Nand), Closures(Closure)]
        public static Nand128<T> nand<T>(W128 w)
            where T : unmanaged
                => default(Nand128<T>);

        [MethodImpl(Inline), Factory(Nand), Closures(Closure)]
        public static Nand256<T> nand<T>(W256 w)
            where T : unmanaged
                => default(Nand256<T>);

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static Span<T> nand<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(nand<T>(), a, b,dst);

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static SpanBlock128<T> nand<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => nand<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static SpanBlock256<T> nand<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => nand<T>(w256).Invoke(a, b, dst);
    }
}