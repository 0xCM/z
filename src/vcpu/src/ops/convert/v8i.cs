//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{ 
    partial class vcpu 
    {
        /// <summary>
        /// Presents a 128-bit <typeparamref name='T'/> vector as a 128-bit <see cref='sybte'/> vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector128<sbyte> v8i<T>(Vector128<T> x)
            where T : unmanaged
                => x.AsSByte();

        /// <summary>
        /// Presents a 256-bit <typeparamref name='T'/> vector as a 256-bit <see cref='sybte'/> vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector256<sbyte> v8i<T>(Vector256<T> x)
            where T : unmanaged
                => x.AsSByte();

        /// <summary>
        /// Presents a 512-bit <typeparamref name='T'/> vector as a 512-bit <see cref='sybte'/> vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The source vector primal component type</typeparam>
        [MethodImpl(Inline), Concretizer, Closures(Closure)]
        public static Vector512<sbyte> v8i<T>(Vector512<T> x)
            where T : unmanaged
                => x.As<sbyte>();
    }
}