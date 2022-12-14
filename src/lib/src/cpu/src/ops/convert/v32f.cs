//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type float32
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector128<float> v32f<T>(Vector128<T> x)
            where T : unmanaged
                => x.AsSingle();

        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type float32
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector256<float> v32f<T>(Vector256<T> x)
            where T : unmanaged
                => x.AsSingle();
    }

    partial struct cpu
    {
        [MethodImpl(Inline)]
        public static Vector128<float> v32f<T>(Vector128<T> x)
            where T : unmanaged
                => x.AsSingle();

        [MethodImpl(Inline)]
        public static Vector256<float> v32f<T>(Vector256<T> x)
            where T : unmanaged
                => gcpu.v32f(x);
    }
}