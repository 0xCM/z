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
        [MethodImpl(Inline), Factory(GtEq), Closures(Closure)]
        public static GtEq<T> gteq<T>()
            where T : unmanaged
                => default(GtEq<T>);

        [MethodImpl(Inline), GtEq, Closures(Closure)]
        public static Span<bit> gteq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<bit> dst)
            where T : unmanaged
                => gcalc.apply(gteq<T>(), a, b, dst);
    }
}