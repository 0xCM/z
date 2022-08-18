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
        public static VOnes128<T> vones<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VOnes128<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VOnes256<T> vones<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VOnes256<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VUnits128<T> vunits<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VUnits128<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static VUnits256<T> vunits<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VUnits256<T>);
    }
}