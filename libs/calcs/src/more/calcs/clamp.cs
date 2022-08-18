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
        [MethodImpl(Inline), Factory(Clamp), Closures(AllNumeric)]
        public static Clamp<T> clamp<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Clamp, Closures(Closure)]
        public static Span<T> clamp<T>(ReadOnlySpan<T> l, ReadOnlySpan<T> r, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(clamp<T>(), l, r, dst);
    }
}