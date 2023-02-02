//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{ 
    partial class vcpu 
    {
        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type int16
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector128<short> v16i<T>(Vector128<T> x)
            where T : unmanaged
                => x.AsInt16();

        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type int16
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector256<short> v16i<T>(Vector256<T> x)
            where T : unmanaged
                => x.AsInt16();

        /// <summary>
        /// Presents a generic cpu vector as a cpu vector with components of type int16
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector512<short> v16i<T>(Vector512<T> x)
            where T : unmanaged
                => x.As<short>();
    }
}