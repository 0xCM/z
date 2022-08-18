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
    using static SFx;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Pop), Closures(Closure)]
        public static Pop<T> pop<T>()
            where T : unmanaged
                => sfunc<Pop<T>>();

        [MethodImpl(Inline), Factory(Pop), Closures(Closure)]
        public static VPop128<T> vpop<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VPop128<T>);

        [MethodImpl(Inline), Factory(Pop), Closures(Closure)]
        public static VPop256<T> vpop<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VPop256<T>);
    }
}