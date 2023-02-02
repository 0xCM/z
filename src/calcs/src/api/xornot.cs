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
        [MethodImpl(Inline), Factory(XorNot), Closures(Closure)]
        public static VXorNot128<T> vxornot<T>(W128 w)
            where T : unmanaged
                => default(VXorNot128<T>);

        [MethodImpl(Inline), Factory(XorNot), Closures(Closure)]
        public static VXorNot256<T> vxornot<T>(W256 w)
            where T : unmanaged
                => default(VXorNot256<T>);

        [MethodImpl(Inline), Factory(XorNot), Closures(Integers)]
        public static XorNot128<T> xornot<T>(W128 w)
            where T : unmanaged
                => default(XorNot128<T>);

        [MethodImpl(Inline), Factory(XorNot), Closures(Integers)]
        public static XorNot256<T> xornot<T>(W256 w)
            where T : unmanaged
                => default(XorNot256<T>);

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static SpanBlock128<T> xornot<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => xornot<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), XorNot, Closures(Closure)]
        public static SpanBlock256<T> xornot<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => xornot<T>(w256).Invoke(a, b, dst);
    }
}