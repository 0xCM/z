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
        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type float64
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector128<double> v64f<T>(Vector128<T> x)
            where T : unmanaged
                => x.AsDouble();

        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type float64
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector256<double> v64f<T>(Vector256<T> x)
            where T : unmanaged
                => x.AsDouble();

        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type float64
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector512<double> v64f<T>(Vector512<T> x)
            where T : unmanaged
                => x.As<double>();
    }

    partial struct cpu
    {
        [MethodImpl(Inline)]
        public static Vector128<double> v64f<T>(Vector128<T> x)
            where T : unmanaged
                => gcpu.v64f(x);

        [MethodImpl(Inline)]
        public static Vector256<double> v64f<T>(Vector256<T> x)
            where T : unmanaged
                => gcpu.v64f(x);

        [MethodImpl(Inline)]
        public static Vector512<double> v64f<T>(Vector512<T> x)
            where T : unmanaged
                => gcpu.v64f(x);
    }
}