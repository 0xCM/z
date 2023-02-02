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
        [MethodImpl(Inline), Factory(Bsrl), Closures(Closure)]
        public static Bsrl128<T> bsrl<T>(W128 w)
            where T : unmanaged
                => default(Bsrl128<T>);

        [MethodImpl(Inline), Factory(Bsrl), Closures(Closure)]
        public static Bsrl256<T> bsrl<T>(W256 w)
            where T : unmanaged
                => default(Bsrl256<T>);

        [MethodImpl(Inline), Bsrl, Closures(Closure)]
        public static SpanBlock128<T> bsrl<T>(SpanBlock128<T> a, [Imm] byte count, SpanBlock128<T> dst)
            where T : unmanaged
                => bsrl<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Bsrl, Closures(Closure)]
        public static SpanBlock256<T> brsl<T>(SpanBlock256<T> a, [Imm] byte count, SpanBlock256<T> dst)
            where T : unmanaged
                => bsrl<T>(w256).Invoke(a, count, dst);
    }
}