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
        public static ushort vcell16<T>(Vector128<T> x, byte index)
            where T : unmanaged
                => v16u(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort vcell16<T>(Vector256<T> x, byte index)
            where T : unmanaged
                => v16u(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static short vcell16i<T>(Vector128<T> x, byte index)
            where T : unmanaged
                => v16i(x).GetElement(index);

        /// <summary>
        /// Extract an index-identified component of a reinterpreted vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static short vcell16i<T>(Vector256<T> x, byte index)
            where T : unmanaged
                => v16i(x).GetElement(index);
    }
}