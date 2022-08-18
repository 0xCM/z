//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the converse nonimplication, z := x & ~y, for bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector128<T> cnonimpl<T>(BitVector128<T> x, BitVector128<T> y)
            where T : unmanaged
                => gcpu.vcnonimpl(x.State, y.State);

        /// <summary>
        /// Computes the converse nonimplication, z := x & ~y, for bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), CNonImpl, Closures(Closure)]
        public static ScalarBits<T> cnonimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.cnonimpl(x.State, y.State);

        /// <summary>
        /// Computes the converse nonimplication, z := x & ~y, for bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> cnonimpl<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.cnonimpl(x.State, y.State);

   }
}