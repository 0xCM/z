//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> dec<T>(ScalarBits<T> x)
            where T : unmanaged
                => gmath.dec(x.State);

        /// <summary>
        /// Arithmetically decrements the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> dec<N,T>(ScalarBits<N,T> x)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.dec(x.State);
    }
}