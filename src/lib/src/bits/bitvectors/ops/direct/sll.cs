//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes z := x << s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="y">The shift s</param>
        [MethodImpl(Inline), Sll]
        public static BitVector4 sll(BitVector4 x, byte offset)
            => math.sll(x.Data,offset);

        /// <summary>
        /// Computes z := x << s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="y">The shift s</param>
        [MethodImpl(Inline), Sll]
        public static BitVector8 sll(BitVector8 x, byte offset)
            => math.sll(x.Data,offset);

        /// <summary>
        /// Computes z := x << s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="y">The shift s</param>
        [MethodImpl(Inline), Sll]
        public static BitVector16 sll(BitVector16 x, byte offset)
            => math.sll(x.Data,offset);

        /// <summary>
        /// Computes z := x << s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="y">The shift s</param>
        [MethodImpl(Inline), Sll]
        public static BitVector32 sll(BitVector32 x, byte offset)
            => math.sll(x.Data,offset);

        /// <summary>
        /// Computes z := x << s for a bitvector x and shift offset s
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="y">The shift s</param>
        [MethodImpl(Inline), Sll]
        public static BitVector64 sll(BitVector64 x, byte offset)
            => math.sll(x.Data,offset);
   }
}