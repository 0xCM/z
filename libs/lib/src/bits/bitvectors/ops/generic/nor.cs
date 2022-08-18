//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the bitvector z: = ~(x | y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        /// <typeparam name="T">The primal bitvector type</typeparam>
        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static ScalarBits<T> nor<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.nor(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z: = ~(x | y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        /// <typeparam name="T">The primal bitvector type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> nor<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.nor(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z: = ~(x | y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        /// <typeparam name="T">The primal bitvector type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector128<T> nor<T>(in BitVector128<T> x, in BitVector128<T> y)
            where T : unmanaged
                => gcpu.vnor(x.State,y.State);
    }
}