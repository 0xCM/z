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
        [MethodImpl(Inline), Factory(Bsll), Closures(Closure)]
        public static Bsll128<T> bsll<T>(W128 w)
            where T : unmanaged
                => default(Bsll128<T>);

        [MethodImpl(Inline), Factory(Bsll), Closures(Closure)]
        public static Bsll256<T> bsll<T>(W256 w)
            where T : unmanaged
                => default(Bsll256<T>);

        [MethodImpl(Inline), Bsll, Closures(Closure)]
        public static SpanBlock128<T> bsll<T>(SpanBlock128<T> a, [Imm] byte count, SpanBlock128<T> dst)
            where T : unmanaged
                => bsll<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Bsll, Closures(Closure)]
        public static SpanBlock256<T> bsll<T>(SpanBlock256<T> a, [Imm] byte count, SpanBlock256<T> dst)
            where T : unmanaged
                => bsll<T>(w256).Invoke(a, count, dst);
    }
}