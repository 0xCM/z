//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the material nonimplication, equivalent to the bitwise expression a & (~b) for operands a and b
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), NonImpl, Closures(Closure)]
        public static ScalarBits<T> nonimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
                => gbits.nonimpl(x.State, y.State);

        /// <summary>
        /// Computes the material nonimplication, equivalent to the bitwise expression a & (~b) for operands a and b
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> nonimpl<N,T>(ScalarBits<N,T> x, ScalarBits<N,T> y)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.nonimpl(x.State, y.State);

        /// <summary>
        /// Computes the material nonimplication, equivalent to the bitwise expression a & (~b) for operands a and b
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector128<T> nonimpl<T>(in BitVector128<T> x, in BitVector128<T> y)
            where T : unmanaged
                => gcpu.vnonimpl(x.State, y.State);

        /// <summary>
        /// Computes the material nonimplication, equivalent to the bitwise expression a & (~b) for operands a and b
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector256<T> nonimpl<T>(in BitVector256<T> x, in BitVector256<T> y)
            where T : unmanaged
                => gcpu.vnonimpl(x.State, y.State);
    }
}