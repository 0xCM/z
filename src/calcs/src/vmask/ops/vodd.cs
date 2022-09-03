//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMasks;

    partial struct vmask
    {
        /// <summary>
        /// [10101010]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vodd<T>(W128 w, N2 f, N1 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, odd<T>(f,d));

        /// <summary>
        /// [10101010]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vodd<T>(W256 w, N2 f, N1 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, odd<T>(f,d));

        /// <summary>
        /// [11001100]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vodd<T>(W128 w, N2 f, N2 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, odd<T>(f,d));

        /// <summary>
        /// [11001100]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vodd<T>(W256 w, N2 f, N2 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, odd<T>(f,d));

        [MethodImpl(Inline), Op]
        public static Vector128<byte> vodd(W128 w)
            => vodd<byte>(w, n2, n2);

        [MethodImpl(Inline), Op]
        public static Vector256<byte> vodd(W256 w)
            => vodd<byte>(w, n2, n2);
    }
}