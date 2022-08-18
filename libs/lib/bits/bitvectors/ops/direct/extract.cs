//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="i0">The first bit position</param>
        /// <param name="i1">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector4 extract(BitVector4 x, byte i0, byte i1)
            => bits.extract(x.State, i0, i1);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="i0">The first bit position</param>
        /// <param name="i1">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector8 extract(BitVector8 x, byte i0, byte i1)
            => bits.extract(x.State, i0, i1);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="i0">The first bit position</param>
        /// <param name="i1">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector16 extract(BitVector16 x, byte i0, byte i1)
            => bits.extract(x.State, i0, i1);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="i0">The first bit position</param>
        /// <param name="i1">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector32 extract(BitVector32 x, byte i0, byte i1)
            => bits.extract(x.State, i0, i1);

        /// <summary>
        /// Extracts a contiguous sequence of bits defined by an inclusive range
        /// </summary>
        /// <param name="i0">The first bit position</param>
        /// <param name="i1">The last bit position</param>
        [MethodImpl(Inline), BitSeg]
        public static BitVector64 extract(BitVector64 x, byte i0, byte i1)
            => bits.extract(x.State, i0, i1);
    }
}