//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector4 hiseg(BitVector4 x, byte n)
            => extract(x, (byte)(x.Width - n), (byte)(x.Width - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector8 hiseg(BitVector8 x, byte n)
            => extract(x, (byte)(x.Width - n), (byte)(x.Width - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector16 hiseg(BitVector16 x, byte n)
            => extract(x, (byte)(x.Width - n), (byte)(x.Width - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector32 hiseg(BitVector32 x, byte n)
            => BitVectors.extract(x.State, (byte)(x.Width - n), (byte)(x.Width - 1));

        /// <summary>
        /// Constructs a bitvector formed from the n most significant bits of the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="n">The count of most significant bits</param>
        [MethodImpl(Inline), HiSeg]
        public static BitVector64 hiseg(BitVector64 x, byte n)
            => extract(x, (byte)(x.Width - n), (byte)(x.Width - 1));
    }
}