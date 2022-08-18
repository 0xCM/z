//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the arithmetic sum z := x + y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 add(BitVector4 x, BitVector4 y)
            => new BitVector4(math.mod(math.add(x.State, y.State), (byte)4),true);

        /// <summary>
        /// Computes the arithmetic sum of two bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 add(BitVector8 x, BitVector8 y)
            => math.add(x.State, y.State);

        /// <summary>
        /// Computes the arithmetic sum z := x + y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 add(BitVector16 x, BitVector16 y)
            => math.add(x.State, y.State);

        /// <summary>
        /// Computes the arithmetic sum z := x + y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 add(BitVector32 x, BitVector32 y)
            => math.add(x.State, y.State);

        /// <summary>
        /// Computes the arithmetic sum z := x + y for bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 add(BitVector64 x, BitVector64 y)
            => math.add(x.State, y.State);
    }
}