//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The left bitvector</param>
        [MethodImpl(Inline), Negate]
        public static BitVector4 negate(BitVector4 x)
            => gmath.negate(x.State);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source bitvector</param>
        [MethodImpl(Inline), Negate]
        public static BitVector8 negate(BitVector8 x)
            => gmath.negate(x.State);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source bitvector</param>
        [MethodImpl(Inline), Negate]
        public static BitVector16 negate(BitVector16 x)
            => gmath.negate(x.State);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source bitvector</param>
        [MethodImpl(Inline), Negate]
        public static BitVector32 negate(BitVector32 x)
            => gmath.negate(x.State);

        /// <summary>
        /// Computes the two's complement bitvector z := ~x + 1 for a bitvector x
        /// </summary>
        /// <param name="x">The source bitvector</param>
        [MethodImpl(Inline), Negate]
        public static BitVector64 negate(BitVector64 x)
            => gmath.negate(x.State);
    }
}