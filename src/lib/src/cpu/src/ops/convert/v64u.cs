//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type uint64
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector128<ulong> v64u<T>(Vector128<T> x)
            where T : unmanaged
                => x.AsUInt64();

        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type uint64
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector256<ulong> v64u<T>(Vector256<T> x)
            where T : unmanaged
                => x.AsUInt64();

        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type uint64
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector512<ulong> v64u<T>(Vector512<T> x)
            where T : unmanaged
                => x.As<ulong>();
    }

    partial struct cpu
    {
        [MethodImpl(Inline)]
        public static Vector128<ulong> v64u<T>(Vector128<T> x)
            where T : unmanaged
                => gcpu.v64u(x);

        [MethodImpl(Inline)]
        public static Vector256<ulong> v64u<T>(Vector256<T> x)
            where T : unmanaged
                => gcpu.v64u(x);

        [MethodImpl(Inline)]
        public static Vector512<ulong> v64u<T>(Vector512<T> x)
            where T : unmanaged
                => gcpu.v64u(x);
    }
}