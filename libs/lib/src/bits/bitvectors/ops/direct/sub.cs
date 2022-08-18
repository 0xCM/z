//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the arithmetic difference z := x - y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Sub]
        public static BitVector4 sub(BitVector4 x, BitVector4 y)
            => (byte)Mod16.mod(math.sub((uint)x.State, (uint)y.State));

        [MethodImpl(Inline), Sub]
        public static BitVector4 sub2(BitVector4 x, BitVector4 y)
        {
            const int modulus = 16;
            var diff = (int)x - (int)y;
            var reduced = (byte)(diff < 0 ? (uint)(diff + modulus) : (uint)diff);
            return new BitVector4(reduced, true);
        }

        /// <summary>
        /// Computes the arithmetic difference z := x - y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Sub]
        public static BitVector8 sub(BitVector8 x, BitVector8 y)
            => gmath.sub(x.State, y.State);

        /// <summary>
        /// Computes the arithmetic difference z := x - y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Sub]
        public static BitVector16 sub(BitVector16 x, BitVector16 y)
            => gmath.sub(x.State, y.State);

        /// <summary>
        /// Computes the arithmetic difference z := x - y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Sub]
        public static BitVector32 sub(BitVector32 x, BitVector32 y)
            => gmath.sub(x.State, y.State);

        /// <summary>
        /// Computes the arithmetic difference z := x - y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Sub]
        public static BitVector64 sub(BitVector64 x, BitVector64 y)
            => gmath.sub(x.State, y.State);
    }
}