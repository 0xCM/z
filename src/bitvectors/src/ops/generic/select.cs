//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the bitwise ternary select for bitvector operands
        /// </summary>
        /// <param name="x">The pivot/mask vector</param>
        /// <param name="y">The primary choice</param>
        /// <param name="z">The alternative choice</param>
        [MethodImpl(Inline), Select, Closures(Closure)]
        public static ScalarBits<T> select<T>(ScalarBits<T> x, ScalarBits<T> y, ScalarBits<T> z)
            where T : unmanaged
                => gbits.select(x.State, y.State, z.State);

        /// <summary>
        /// Computes the bitvector z := x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> select<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y, ScalarBits<N,T> z)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.select(x.State, y.State, z.State);

        /// <summary>
        /// Computes the bitvector z := x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Select, Closures(Closure)]
        public static BitVector128<T> select<T>(in BitVector128<T> x, in BitVector128<T> y, in BitVector128<T> z)
            where T : unmanaged
                => gcpu.vselect(x.State, y.State, z.State);

        /// <summary>
        /// Computes the bitvector z := x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Select, Closures(Closure)]
        public static BitVector256<T> select<T>(in BitVector256<T> x, in BitVector256<T> y, in BitVector256<T> z)
            where T : unmanaged
                => gcpu.vselect(x.State, y.State, z.State);

    }
}