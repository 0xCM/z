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
        [MethodImpl(Inline), Factory(Rotl), Closures(Closure)]
        public static VRotl128<T> vrotl<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VRotl128<T>);

        [MethodImpl(Inline), Factory(Rotl), Closures(Closure)]
        public static VRotl256<T> vrotl<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VRotl256<T>);

        [MethodImpl(Inline), Factory(Rotl), Closures(Integers)]
        public static Rotl128<T> rotl<T>(W128 w)
            where T : unmanaged
                => default(Rotl128<T>);

        [MethodImpl(Inline), Factory(Rotl), Closures(Integers)]
        public static Rotl256<T> rotl<T>(W256 w)
            where T : unmanaged
                => default(Rotl256<T>);

        [MethodImpl(Inline), Rotl, Closures(Closure)]
        public static SpanBlock128<T> rotl<T>(SpanBlock128<T> a, [Imm] byte count, SpanBlock128<T> dst)
            where T : unmanaged
                => rotl<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Rotl, Closures(Closure)]
        public static SpanBlock256<T> rotl<T>(SpanBlock256<T> a, [Imm] byte count, SpanBlock256<T> dst)
            where T : unmanaged
                => rotl<T>(w256).Invoke(a, count, dst);
    }
}