//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Replicate, Closures(Closure)]
        public static ScalarBits<T> replicate<T>(ScalarBits<T> x)
            where T : unmanaged
                => x.State;

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> replicate<N,T>(ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => src.State;
    }
}