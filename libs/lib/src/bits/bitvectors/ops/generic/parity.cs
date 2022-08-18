//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static gmath;

    partial class BitVectors
    {
        /// <summary>
        /// Computes the parity of a generic bitvector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit parity<T>(ScalarBits<T> src)
            where T : unmanaged
                => odd(gbits.pop(src.State));

        /// <summary>
        /// Computes the parity of a natural bitvector, which is 1 if an odd number of its components are enabled and 0 otherwise
        /// </summary>
        /// <remarks>
        /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
        /// value 1 when an odd number of its input values are 1 and 0 otherwise.
        /// </remarks>
        [MethodImpl(Inline)]
        public static bit parity<N,T>(ScalarBits<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => math.odd(gbits.pop(src.State));

        /// <summary>
        /// Computes the parity of the source vector
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit parity<T>(in BitVector128<T> src)
            where T : unmanaged
                => math.odd(pop(src));

        /// <summary>
        /// Computes the parity of the source vector
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit parity<T>(in BitVector256<T> src)
            where T : unmanaged
                => math.odd(pop(src));
    }
}