//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vgcpu
{
    [MethodImpl(Inline), RProject, Closures(Integers)]
    public static Vector128<T> vright<T>(Vector128<T> a, Vector128<T> b)
        where T : unmanaged
            => a;

    [MethodImpl(Inline), RProject, Closures(Integers)]
    public static Vector256<T> vright<T>(Vector256<T> a, Vector256<T> b)
        where T : unmanaged
            => a;
}
