//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector4 zhi(BitVector4 src, byte pos)
            => gbits.zhi(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector8 zhi(BitVector8 src, byte pos)
            => gbits.zhi(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector16 zhi(BitVector16 src, byte pos)
            => gbits.zhi(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector32 zhi(BitVector32 src, byte pos)
            => gbits.zhi(src.State, pos);

        /// <summary>
        /// Disables the high bits starting at a specified position
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), MsbOff]
        public static BitVector64 zhi(BitVector64 src, byte pos)
            => gbits.zhi(src.State, pos);
    }
}