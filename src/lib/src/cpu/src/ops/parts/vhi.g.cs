
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcpu
    {
        /// <summary>
        /// Moves the hi 64 bits of the source vector the the lo 64 bits of a target vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vhi<T>(Vector128<T> src)
            where T : unmanaged
                => generic<T>(vcpu.vscalar(w128, vcpu.vcell(v64u(src),1)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vhi<T>(Vector256<T> src)
            where T : unmanaged
                => Vector256.GetUpper(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vhi<T>(Vector512<T> src)
            where T : unmanaged
                => src.Hi;

        /// <summary>
        /// Extracts the hi 128-bit lane of the source vector to scalar targets
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static void vhi<T>(Vector256<T> src, out ulong x0, out ulong x1)
            where T : unmanaged
                => vcpu.vhi(v64u(src), out x0, out x1);

        /// <summary>
        /// Extracts the hi 128-bit lane of the source vector to a pair
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Closures(AllNumeric)]
        public static ref Pair<ulong> vhi<T>(Vector256<T> src, ref Pair<ulong> dst)
            where T : unmanaged
                => ref vcpu.vhi(v64u(src), ref dst);

        /// <summary>
        /// Extracts the lower 256-bits from the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Closures(AllNumeric)]
        public static Vector512<T> vhi<T>(Vector1024<T> src)
            where T : unmanaged
                => src.Hi;
    }
}