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
        [MethodImpl(Inline), Factory(Square), Closures(Closure)]
        public static Square<T> square<T>()
            where T : unmanaged
                => default;

       [MethodImpl(Inline), Square, Closures(Closure)]
        public static Span<T> square<T>(ReadOnlySpan<T> src, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(Calcs.square<T>(), src, dst);
    }
}