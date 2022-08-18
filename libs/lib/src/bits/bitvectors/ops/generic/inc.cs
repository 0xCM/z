//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Arithmetically increments the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Inc, Closures(Closure)]
        public static ScalarBits<T> inc<T>(ScalarBits<T> x)
            where T : unmanaged
                => gmath.inc(x.State);

        /// <summary>
        /// Arithmetically increments the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> inc<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.inc(x.State);
    }
}