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
        [MethodImpl(Inline), Factory(ModMul), Closures(Closure)]
        public static ModMul<T> modmul<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), ModMul, Closures(Closure)]
        public static Span<T> modmul<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, ReadOnlySpan<T> c, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(modmul<T>(), a,b,c, dst);
    }
}