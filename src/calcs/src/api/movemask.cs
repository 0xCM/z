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
        [MethodImpl(Inline), Op(MoveMask), Closures(Closure)]
        public static VMoveMask128<T> vmovemask<T>(W128 w, T t = default)
            where T : unmanaged
                => default(VMoveMask128<T>);

        [MethodImpl(Inline), Op(MoveMask), Closures(Closure)]
        public static VMoveMask256<T> vmovemask<T>(W256 w, T t = default)
            where T : unmanaged
                => default(VMoveMask256<T>);

        [MethodImpl(Inline), Op(MoveIMask), Closures(Closure)]
        public static VMoveIMask128<T> vmoveimask<T>(W128 w)
            where T : unmanaged
                => default(VMoveIMask128<T>);

        [MethodImpl(Inline), Op(MoveIMask), Closures(Closure)]
        public static VMoveIMask256<T> vmoveimask<T>(W256 w)
            where T : unmanaged
                => default(VMoveIMask256<T>);
    }
}