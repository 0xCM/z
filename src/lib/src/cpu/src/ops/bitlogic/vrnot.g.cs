//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        [MethodImpl(Inline), RNot, Closures(Integers)]
        public static Vector128<T> vrnot<T>(Vector128<T> a, Vector128<T> b)
            where T : unmanaged
                => vnot(b);

        [MethodImpl(Inline), RNot, Closures(Integers)]
        public static Vector256<T> vrnot<T>(Vector256<T> a, Vector256<T> b)
            where T : unmanaged
                => vnot(b);
    }
}