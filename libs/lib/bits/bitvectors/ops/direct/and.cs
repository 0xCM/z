//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes a new bitvector z = x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), And]
        public static BitVector4 and(BitVector4 x, BitVector4 y)
            => math.and(x.Data, y.Data);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), And]
        public static BitVector8 and(BitVector8 x, BitVector8 y)
            => math.and(x.Data,y.Data);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), And]
        public static BitVector16 and(BitVector16 x, BitVector16 y)
            => math.and(x.Data, y.Data);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), And]
        public static BitVector32 and(BitVector32 x, BitVector32 y)
            => math.and(x.Data, y.Data);

        /// <summary>
        /// Computes the bitvector z := x & y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), And]
        public static BitVector64 and(BitVector64 x, BitVector64 y)
            => math.and(x.Data, y.Data);
    }
}