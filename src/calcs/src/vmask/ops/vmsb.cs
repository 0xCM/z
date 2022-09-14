//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMasks;
    using static sys;

    partial struct vmask
    {
        /// <summary>
        /// The greatest bit of each cell is enabled
        /// </summary>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(n1,n1));

        /// <summary>
        /// [01]
        /// The greatest bit of each 2-bit segment is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N2 f, N1 d, T t = default)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [1000]
        /// The greatest bit of each 4-bit segment is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N4 f, N1 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [10000000]
        /// The greatest bit of each 8-bit segment is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N8 f, N1 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [10000000 00000000]
        /// The greatest bit of each 16-bit segment is enabled
        /// </summary>
        /// <param name="f">The repetition frequency</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N16 f, N1 d)
            where T : unmanaged
                => generic<T>(gcpu.vbroadcast<ulong>(w, msb(n64, f, d)));

        /// <summary>
        /// [11000000]
        /// The 2 greatest bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N8 f, N2 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [11100000]
        /// The greatest 3 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N8 f, N3 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [11110000]
        /// The greatest 4 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N8 f, N4 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [11111000]
        /// The greatest 5 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N8 f, N5 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [11111100]
        /// The greatest 6 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N8 f, N6 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [11111110]
        /// The greatest 7 bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N8 f, N7 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// The f most significant bits of each 8 bits are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">A value in the range [2,7] that defines the bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vmsb<T>(W128 w, N8 f, byte d)
            where T : unmanaged
                => generic<T>(gcpu.vbroadcast<byte>(w, msb8f(d)));

        /// <summary>
        /// [100...00]
        /// The greatest bit of each component is enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(n1,n1));

        /// <summary>
        /// [01]
        /// The greatest bit of each 2-bit segment is enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N2 f, N1 d, T t = default)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb(f,d,t));

        /// <summary>
        /// [1000]
        /// The greatest bit of each 4-bit segment is enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N4 f, N1 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f, d));

        /// <summary>
        /// [10000000]
        /// The greatest bit of each 8-bit segment is enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N8 f, N1 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [10000000 00000000]
        /// The greatest bit of each 16-bit segment is enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The component data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N16 f, N1 d, T t = default)
            where T : unmanaged
                => generic<T>(gcpu.vbroadcast<ulong>(w, msb(n64, f, d)));

        /// <summary>
        /// [11000000]
        /// The 2 greatest bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N8 f, N2 d, T t = default)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb(f,d,t));

        /// <summary>
        /// [11100000]
        /// The 3 greatest bits of each 8-bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N8 f, N3 d, T t = default)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb(f,d,t));

        /// <summary>
        /// [11110000]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N8 f, N4 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [11111000]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N8 f, N5 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [11111100]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N8 f, N6 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// [11111110]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N8 f, N7 d)
            where T : unmanaged
                => gcpu.vbroadcast(w, msb<T>(f,d));

        /// <summary>
        /// Creates a mask where f most significant bits of each 8 bits are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">A value in the range [2,7] that defines the bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vmsb<T>(W256 w, N8 f, byte d)
            where T : unmanaged
                => generic<T>(gcpu.vbroadcast<byte>(w, msb8f(d)));
    }
}