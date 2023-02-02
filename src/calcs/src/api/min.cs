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
        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static Min<T> min<T>()
            where T : unmanaged
                => default(Min<T>);

        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static VMin128<T> vmin<T>(W128 w)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static VMin256<T> vmin<T>(W256 w)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static Min128<T> min<T>(W128 w)
            where T : unmanaged
                => default(Min128<T>);

        [MethodImpl(Inline), Factory(Min), Closures(Closure)]
        public static Min256<T> min<T>(W256 w)
            where T : unmanaged
                => default(Min256<T>);

        [MethodImpl(Inline), Min, Closures(Closure)]
        public static SpanBlock128<T> min<T>(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst)
            where T : unmanaged
                => min<T>(w128).Invoke(a, b, dst);

        [MethodImpl(Inline), Min, Closures(Closure)]
        public static SpanBlock256<T> min<T>(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst)
            where T : unmanaged
                => min<T>(w256).Invoke(a, b, dst);
    }
}