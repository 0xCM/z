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
        /// Returns a reference to the leading component of the source
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T vref<T>(ref Vector128<T> src)
            where T : unmanaged
                => ref @as<Vector128<T>,T>(src);

        /// <summary>
        /// Returns a reference to the leading component of the source
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T vref<T>(ref Vector256<T> src)
            where T : unmanaged
                => ref @as<Vector256<T>,T>(src);

        /// <summary>
        /// Returns a reference to the leading component of the source
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ref T vref<T>(ref Vector512<T> src)
            where T : unmanaged
                => ref @as<Vector512<T>,T>(src);
    }
}