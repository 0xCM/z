//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the material implication z := x | ~y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static ScalarBits<T> impl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gmath.impl(x.State, y.State);

        /// <summary>
        /// Computes the material implication z := x | ~y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> impl<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gmath.impl(x.State, y.State);

        /// <summary>
        /// Computes the material implication z := x | ~y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector128<T> impl<T>(in BitVector128<T> x, in BitVector128<T> y)
            where T : unmanaged
                => gcpu.vimpl(x.State, y.State);
   }
}