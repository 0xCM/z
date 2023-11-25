//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vgcpu
    {
        [MethodImpl(Inline), IdentityFunction, Closures(Integers)]
        public static Vector128<T> videntity<T>(Vector128<T> a)
            where T : unmanaged
                => a;

        [MethodImpl(Inline), IdentityFunction, Closures(Integers)]
        public static Vector256<T> videntity<T>(Vector256<T> a)
            where T : unmanaged
                => a;

        [MethodImpl(Inline), IdentityFunction, Closures(Integers)]
        public static Vector512<T> videntity<T>(Vector512<T> a)
            where T : unmanaged
                => a;
    }
}