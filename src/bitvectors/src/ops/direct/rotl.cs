//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="offset">The rotation magnitude</param>
        [MethodImpl(Inline), Rotl]
        public static BitVector4 rotl(BitVector4 src, byte offset)
            => gbits.rotl(src.Data, offset, (byte)src.Width);

        /// <summary>
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="offset">The rotation magnitude</param>
        [MethodImpl(Inline), Rotl]
        public static BitVector8 rotl(BitVector8 src, byte offset)
            => gbits.rotl(src.Data,offset);

        /// <summary>
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="offset">The rotation magnitude</param>
        [MethodImpl(Inline), Rotl]
        public static BitVector16 rotl(BitVector16 src, byte offset)
            => gbits.rotl(src.Data,offset);

        /// <summary>
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="offset">The rotation magnitude</param>
        [MethodImpl(Inline), Rotl]
        public static BitVector32 rotl(BitVector32 src, byte offset)
            => gbits.rotl(src.Data,offset);

        /// <summary>
        /// Rotates source bits leftward
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="offset">The rotation magnitude</param>
        [MethodImpl(Inline), Rotl]
        public static BitVector64 rotl(BitVector64 src, byte offset)
             => gbits.rotl(src.Data,offset);
    }
}