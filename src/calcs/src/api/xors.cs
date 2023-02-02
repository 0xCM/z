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
        [MethodImpl(Inline), Factory(Xors), Closures(Integers)]
        public static Xors128<T> xors<T>(W128 w)
            where T : unmanaged
                => default(Xors128<T>);

        [MethodImpl(Inline), Factory(Xors), Closures(Integers)]
        public static Xors256<T> xors<T>(W256 w)
            where T : unmanaged
                => default(Xors256<T>);

        [MethodImpl(Inline), Xors, Closures(Closure)]
        public static SpanBlock128<T> xors<T>(SpanBlock128<T> a, [Imm] byte count, SpanBlock128<T> dst)
            where T : unmanaged
                => xors<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Xors, Closures(Closure)]
        public static SpanBlock256<T> xors<T>(SpanBlock256<T> a, [Imm] byte count, SpanBlock256<T> dst)
            where T : unmanaged
                => xors<T>(w256).Invoke(a, count, dst);
    }
}