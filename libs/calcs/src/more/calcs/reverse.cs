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
        [MethodImpl(Inline), Factory(Reverse), Closures(Closure)]
        public static VReverse128<T> vreverse<T>(N128 w)
            where T : unmanaged
                => default(VReverse128<T>);

        [MethodImpl(Inline), Factory(Reverse), Closures(Closure)]
        public static VReverse256<T> vreverse<T>(W256 w)
            where T : unmanaged
                => default(VReverse256<T>);
    }
}