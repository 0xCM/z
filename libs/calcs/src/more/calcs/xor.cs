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
        [MethodImpl(Inline), Factory(Xor), Closures(Closure)]
        public static Xor<T> xor<T>()
            where T : unmanaged
                => default(Xor<T>);

        [MethodImpl(Inline), Factory(Xor), Closures(UnsignedInts)]
        public static BvXor<T> bvxor<T>()
            where T : unmanaged
                => sfunc<BvXor<T>>();

        [MethodImpl(Inline), Factory(Xor), Closures(Closure)]
        public static VXor128<T> vxor<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VXor128<T>);

        [MethodImpl(Inline), Factory(Xor), Closures(Closure)]
        public static VXor256<T> vxor<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VXor256<T>);

        [MethodImpl(Inline), Factory(Xor), Closures(Closure)]
        public static Xor128<T> xor<T>(W128 w)
            where T : unmanaged
                => default(Xor128<T>);

        [MethodImpl(Inline), Factory(Xor), Closures(Closure)]
        public static Xor256<T> xor<T>(W256 w)
            where T : unmanaged
                => default(Xor256<T>);

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static Span<T> xor<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(xor<T>(), a, b, dst);
    }
}