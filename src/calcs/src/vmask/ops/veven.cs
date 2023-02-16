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
        /// [01010101] | [00110011]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<T> veven<F,D,T>(W128 w, F f = default, D d = default, T t = default)
            where F : unmanaged, ITypeNat
            where D : unmanaged, ITypeNat
            where T : unmanaged
        {
            if(typeof(D) == typeof(N1))
                return veven<T>(w, n2, n1);
            else if(typeof(D) == typeof(N2))
                return veven<T>(w, n2, n2);
            else
                throw no<D>();
        }

        /// <summary>
        /// [01010101]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> veven<T>(W128 w, N2 f, N1 d)
            where T : unmanaged
                => vgcpu.vbroadcast(w, even<T>(f,d));

        /// <summary>
        /// [00110011]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> veven<T>(W128 w, N2 f, N2 d)
            where T : unmanaged
                => vgcpu.vbroadcast(w, even<T>(f,d));

        [MethodImpl(Inline), Op]
        public static Vector128<byte> veven(W128 w)
            => veven<byte>(w, n2, n2);

        /// <summary>
        /// [01010101] | [00110011]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<T> veven<F,D,T>(W256 w, F f = default, D d = default, T t = default)
            where F : unmanaged, ITypeNat
            where D : unmanaged, ITypeNat
            where T : unmanaged
        {
            if(typeof(D) == typeof(N1))
                return veven<T>(w, n2, n1);
            else if(typeof(D) == typeof(N2))
                return veven<T>(w, n2, n2);
            else
                throw no<D>();
        }

        /// <summary>
        /// [01010101]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> veven<T>(W256 w, N2 f, N1 d)
            where T : unmanaged
                => vgcpu.vbroadcast(w, even<T>(f,d));

        /// <summary>
        /// [00110011]
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">The bit density</param>
        /// <param name="t">A component type representative</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> veven<T>(W256 w, N2 f, N2 d)
            where T : unmanaged
                => vgcpu.vbroadcast(w, even<T>(f,d));

        [MethodImpl(Inline), Op]
        public static Vector256<byte> veven(W256 w)
            => veven<byte>(w, n2, n2);
    }
}