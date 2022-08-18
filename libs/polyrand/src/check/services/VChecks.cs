//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ErrorMsg;
    using static ClaimResult;

    [ApiHost]
    public readonly struct VChecks
    {
        public const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ClaimResult veq<T>(Vector128<T> a, Vector128<T> b)
            where T : unmanaged
                => a.Equals(b) ? success(ClaimKind.Eq) : failure(ClaimKind.Eq, neq(a,b).Format());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ClaimResult veq<T>(Vector256<T> a, Vector256<T> b)
            where T : unmanaged
                => a.Equals(b) ? success(ClaimKind.Eq) : failure(ClaimKind.Eq, neq(a,b).Format());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ClaimResult veq<T>(Vector512<T> a, Vector512<T> b)
            where T : unmanaged
                => a.Equals(b) ? success(ClaimKind.Eq) : failure(ClaimKind.Eq, neq(a,b).Format());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ClaimResult vneq<T>(Vector128<T> a, Vector128<T> b)
            where T : unmanaged
                => !a.Equals(b) ? success(ClaimKind.NEq) : failure(ClaimKind.NEq, eq(a,b).Format());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ClaimResult vneq<T>(Vector256<T> a, Vector256<T> b)
            where T : unmanaged
                => !a.Equals(b) ? success(ClaimKind.NEq) : failure(ClaimKind.NEq, eq(a,b).Format());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ClaimResult vneq<T>(Vector512<T> a, Vector512<T> b)
            where T : unmanaged
                => !a.Equals(b) ? success(ClaimKind.NEq) : failure(ClaimKind.NEq, eq(a,b).Format());
    }
}