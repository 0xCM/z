//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Determines whether a bit is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), TestBit]
        public static bit testbit(BitVector4 x, byte pos)
            => bit.test(x.Data, pos);

        /// <summary>
        /// Determines whether a bit is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), TestBit]
        public static bit testbit(BitVector8 x, byte pos)
            => bit.test(x.State, pos);

        /// <summary>
        /// Determines whether a bit is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), TestBit]
        public static bit testbit(BitVector16 x, byte pos)
            => bit.test(x.State, pos);

        /// <summary>
        /// Determines whether a bit is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), TestBit]
        public static bit testbit(BitVector32 x, byte pos)
            => bit.test(x.State, pos);

        /// <summary>
        /// Determines whether a bit is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), TestBit]
        public static bit testbit(BitVector64 x, byte pos)
            => bit.test(x.State, pos);
    }
}