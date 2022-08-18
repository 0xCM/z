//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the bitvector z := ~(x ^ y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Xnor]
        public static BitVector4 xnor(BitVector4 x, BitVector4 y)
            => gmath.xnor(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := ~(x ^ y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Xnor]
        public static BitVector8 xnor(BitVector8 x, BitVector8 y)
            => gmath.xnor(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := ~(x ^ y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Xnor]
        public static BitVector16 xnor(BitVector16 x, BitVector16 y)
            => gmath.xnor(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := ~(x ^ y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Xnor]
        public static BitVector32 xnor(BitVector32 x, BitVector32 y)
            => gmath.xnor(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := ~(x ^ y) from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Xnor]
        public static BitVector64 xnor(BitVector64 x, BitVector64 y)
            => gmath.xnor(x.State, y.State);
   }
}