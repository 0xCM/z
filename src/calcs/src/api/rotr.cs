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
        [MethodImpl(Inline), Factory(Rotr), Closures(Integers)]
        public static VRotr128<T> vrotr<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VRotr128<T>);

        [MethodImpl(Inline), Factory(Rotr), Closures(Integers)]
        public static VRotr256<T> vrotr<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VRotr256<T>);

        [MethodImpl(Inline), Factory(Rotr), Closures(Integers)]
        public static Rotr128<T> rotr<T>(W128 w)
            where T : unmanaged
                => default(Rotr128<T>);

        [MethodImpl(Inline), Factory(Rotr), Closures(Integers)]
        public static Rotr256<T> rotr<T>(W256 w)
            where T : unmanaged
                => default(Rotr256<T>);

        [MethodImpl(Inline), Rotr, Closures(Integers)]
        public static SpanBlock128<T> rotr<T>(SpanBlock128<T> a, [Imm] byte count, SpanBlock128<T> dst)
            where T : unmanaged
                => rotr<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Rotr, Closures(Integers)]
        public static SpanBlock256<T> rotr<T>(SpanBlock256<T> a, [Imm] byte count, SpanBlock256<T> dst)
            where T : unmanaged
                => rotr<T>(w256).Invoke(a, count, dst);
    }
}