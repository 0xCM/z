//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes a rightward bit rotation
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="y">The rotation magnitude</param>
        [MethodImpl(Inline), Rotr]
        public static BitVector4 rotr(BitVector4 x, byte offset)
            => gbits.rotr(x.Data, offset, (byte)x.Width);

        /// <summary>
        /// Computes a rightward bit rotation
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="y">The rotation magnitude</param>
        [MethodImpl(Inline), Rotr]
        public static BitVector8 rotr(BitVector8 x, byte offset)
            => gbits.rotr(x.State, offset);

        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The rotation magnitude</param>
        [MethodImpl(Inline), Rotr]
        public static BitVector16 rotr(BitVector16 x, byte offset)
            => gbits.rotr(x.State, offset);

        /// <summary>
        /// Computes a rightward bit rotation
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="y">The rotation magnitude</param>
        [MethodImpl(Inline), Rotr]
        public static BitVector32 rotr(BitVector32 x, byte offset)
            => gbits.rotr(x.State, offset);

        /// <summary>
        /// Rotates source bits rightward
        /// </summary>
        /// <param name="x">The source bitvector</param>
        /// <param name="offset">The rotation magnitude</param>
        [MethodImpl(Inline), Rotr]
        public static BitVector64 rotr(BitVector64 x, byte offset)
             => gbits.rotr(x.State, offset);
    }
}