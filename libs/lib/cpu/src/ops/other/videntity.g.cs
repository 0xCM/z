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
        [MethodImpl(Inline), IdentityFunction, Closures(Integers)]
        public static Vector128<T> videntity<T>(Vector128<T> a)
            where T : unmanaged
                => a;

        [MethodImpl(Inline), IdentityFunction, Closures(Integers)]
        public static Vector256<T> videntity<T>(Vector256<T> a)
            where T : unmanaged
                => a;
    }
}