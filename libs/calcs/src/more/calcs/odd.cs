//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CalcHosts;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Odd), Closures(AllNumeric)]
        public static Odd<T> odd<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Odd, Closures(Integers)]
        public static Span<bit> odd<T>(ReadOnlySpan<T> src, Span<bit> dst)
            where T : unmanaged
                => gcalc.apply(Calcs.odd<T>(), src,dst);
    }
}