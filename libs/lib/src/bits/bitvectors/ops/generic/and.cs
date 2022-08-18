//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), And, Closures(Closure)]
        public static ScalarBits<T> and<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.and(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> and<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.and(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), And, Closures(Closure)]
        public static BitVector128<T> and<T>(in BitVector128<T> x, in BitVector128<T> y)
            where T : unmanaged
                => gcpu.vand(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), And, Closures(Closure)]
        public static BitVector256<T> and<T>(in BitVector256<T> x, in BitVector256<T> y)
            where T : unmanaged
                => gcpu.vand(x.State, y.State);

        /// <summary>
        /// Creates a copy of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static BitVector128<T> replicate<T>(in BitVector128<T> src)
            where T : unmanaged
                => src.State;
    }
}