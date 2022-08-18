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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VSrlv128<T> vsrlv<T>(W128 w)
            where T : unmanaged
                => default(VSrlv128<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VSrlv256<T> vsrlv<T>(W256 w)
            where T : unmanaged
                => default(VSrlv256<T>);
    }
}