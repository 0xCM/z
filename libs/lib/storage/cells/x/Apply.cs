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
    using static CellDelegates;

    partial class XCell
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> Apply<T>(this UnaryOp256 f, Vector256<T> x)
            where T : unmanaged
                => CellOps.apply(f,x);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> Apply<T>(this UnaryOp128 f, Vector128<T> x)
            where T : unmanaged
                => CellOps.apply(f,x);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> Apply<T>(this BinaryOp128 f, Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => CellOps.apply(f,x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> Apply<T>(this BinaryOp256 f, Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => CellOps.apply(f,x,y);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> Apply<T>(this UnaryOp512 f, Vector512<T> x)
           where T : unmanaged
                => f(x.ToCell<T>()).ToVector<T>();

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> Apply<T>(this BinaryOp512 f, Vector512<T> x, Vector512<T> y)
            where T : unmanaged
        {
            var zf = f(Unsafe.As<Vector512<T>,Cell512>(ref x), Unsafe.As<Vector512<T>,Cell512>(ref y));
            return Unsafe.As<Cell512,Vector512<T>>(ref zf);
        }
    }
}