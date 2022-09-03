//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial struct gcpu
    {
        [MethodImpl(Inline), True, Closures(Integers)]
        public static Vector128<T> vtrue<T>(W128 w)
            where T:unmanaged
                => vones<T>(w);

        [MethodImpl(Inline), True, Closures(Integers)]
        public static Vector128<T> vtrue<T>(Vector128<T> x)
            where T:unmanaged
                => vones<T>(w128);

        [MethodImpl(Inline), True, Closures(Integers)]
        public static Vector128<T> vtrue<T>(Vector128<T> x, Vector128<T> y)
            where T:unmanaged
                => vones<T>(w128);

        [MethodImpl(Inline), True, Closures(Integers)]
        public static Vector128<T> vtrue<T>(Vector128<T> x, Vector128<T> y, Vector128<T> z)
            where T:unmanaged
                => vones<T>(w128);

        [MethodImpl(Inline), True, Closures(Integers)]
        public static Vector256<T> vtrue<T>(W256 w)
            where T:unmanaged
                => vones<T>(w);

        [MethodImpl(Inline), True, Closures(Integers)]
        public static Vector256<T> vtrue<T>(Vector256<T> x)
            where T:unmanaged
                => vones<T>(w256);

        [MethodImpl(Inline), True, Closures(Integers)]
        public static Vector256<T> vtrue<T>(Vector256<T> x, Vector256<T> y)
            where T:unmanaged
                => vones<T>(w256);

        [MethodImpl(Inline), True, Closures(Integers)]
        public static Vector256<T> vtrue<T>(Vector256<T> x, Vector256<T> y, Vector256<T> z)
            where T:unmanaged
                => vones<T>(w256);
    }
}