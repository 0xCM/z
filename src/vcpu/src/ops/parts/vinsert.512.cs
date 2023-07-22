//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref Vector512<T> vinsert<T>(N0 n, Vector256<T> src, ref Vector512<T> dst)
        //     where T : unmanaged
        // {
        //     dst = Vector512<T>.from(src, dst.Lo);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref Vector512<T> vinsert<T>(N1 n, Vector256<T> src, ref Vector512<T> dst)
        //     where T : unmanaged
        // {
        //     dst = Vector512<T>.from(dst.Hi, src);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref Vector512<T> vinsert<T>(N0 n, Vector128<T> src, ref Vector512<T> dst)
        //     where T : unmanaged
        // {
        //     dst = Vector512<T>.from(src, dst[n1], dst[n2], dst[n3]);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref Vector512<T> vinsert<T>(N1 n, Vector128<T> src, ref Vector512<T> dst)
        //     where T : unmanaged
        // {
        //     dst = Vector512<T>.from(dst[n0], src, dst[n2], dst[n3]);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref Vector512<T> vinsert<T>(N2 n, Vector128<T> src, ref Vector512<T> dst)
        //     where T : unmanaged
        // {
        //     dst = Vector512<T>.from(dst[n0], dst[n1], src, dst[n3]);
        //     return ref dst;
        // }

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ref Vector512<T> vinsert<T>(N3 n, Vector128<T> src, ref Vector512<T> dst)
        //     where T : unmanaged
        // {
        //     dst = Vector512<T>.from(dst[n0], dst[n1], dst[n2], src);
        //     return ref dst;
        // }
    }
}