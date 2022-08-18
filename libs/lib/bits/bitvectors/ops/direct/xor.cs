//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes  z := x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Xor]
        public static BitVector4 xor(BitVector4 x, BitVector4 y)
            => gmath.xor(x.State,y.State);

        /// <summary>
        /// Computes  z := x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Xor]
        public static BitVector8 xor(BitVector8 x, BitVector8 y)
            => gmath.xor(x.State,y.State);

        /// <summary>
        /// Computes  z := x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Xor]
        public static BitVector16 xor(BitVector16 x, BitVector16 y)
            => gmath.xor(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z: = x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Xor]
        public static BitVector32 xor(BitVector32 x, BitVector32 y)
            => gmath.xor(x.State, y.State);

        /// <summary>
        /// Computes  z := x ^ y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Xor]
        public static BitVector64 xor(BitVector64 x, BitVector64 y)
            => gmath.xor(x.State, y.State);
    }
}