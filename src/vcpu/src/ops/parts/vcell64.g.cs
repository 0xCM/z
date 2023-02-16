//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;

    partial class vgcpu
    {
        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong vcell64<T>(Vector128<T> x, byte index)
            where T : unmanaged
                => v64u(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong vcell64<T>(Vector256<T> x, byte index)
            where T : unmanaged
                => v64u(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static long vcell64i<T>(Vector128<T> x, byte index)
            where T : unmanaged
                => v64i(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static long vcell64i<T>(Vector256<T> x, byte index)
            where T : unmanaged
                => v64i(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static double vcell64f<T>(Vector128<T> x, byte index)
            where T : unmanaged
                => v64f(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static double vcell64f<T>(Vector256<T> x, byte index)
            where T : unmanaged
                => v64f(x).GetElement(index);
    }
}