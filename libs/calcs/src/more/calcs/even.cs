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
        [MethodImpl(Inline), Factory(Even), Closures(Closure)]
        public static Even<T> even<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Even, Closures(Closure)]
        public static Span<bit> even<T>(ReadOnlySpan<T> src, Span<bit> dst)
            where T : unmanaged
                => gcalc.apply(even<T>(), src,dst);
    }
}