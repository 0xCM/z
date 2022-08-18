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
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// Extracts the first T-indexed component after converting the S-vector to a T-vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="index">The index of the component to extract</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T vfirst<S,T>(Vector128<S> src)
            where S : unmanaged
            where T : unmanaged
                => cpu.vcell<S,T>(src,0);

        /// <summary>
        /// Returns a reference to the leading cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T vfirst<T>(in Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,T>(src);

        /// <summary>
        /// Returns a reference to the leading cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T vfirst<T>(in Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,T>(src);

        /// <summary>
        /// Returns a reference to the leading cell
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T vfirst<T>(in Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,T>(src);
    }
}