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
        public static uint vcell32<T>(Vector128<T> x, byte index)
            where T : unmanaged
                => v32u(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint vcell32<T>(Vector256<T> x, byte index)
            where T : unmanaged
                => v32u(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int vcell32i<T>(Vector128<T> x, byte index)
            where T : unmanaged
                => v32i(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static float vcell32f<T>(Vector128<T> x, byte index)
            where T : unmanaged
                => v32f(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static int vcell32i<T>(Vector256<T> x, byte index)
            where T : unmanaged
                => v32i(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static float vcell32f<T>(Vector256<T> x, byte index)
            where T : unmanaged
                => v32f(x).GetElement(index);
    }
}