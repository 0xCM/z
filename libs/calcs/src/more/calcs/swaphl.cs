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

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VSwapHiLo128<T> vswaphl<T>(N128 w, T t = default)
            where T : unmanaged
                => default(VSwapHiLo128<T>);

        [MethodImpl(Inline), Factory, Closures(Closure)]
        public static VSwapHiLo256<T> vswaphl<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VSwapHiLo256<T>);
    }
}