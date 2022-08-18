//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, 0 otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(sbyte src, byte pos)
            => bit.test(src, pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, 0 otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(byte src, byte pos)
            => bit.test(src, pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, 0 otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(short src, byte pos)
            => bit.test(src, pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, 0 otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(ushort src, byte pos)
            => bit.test(src,pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, 0 otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(int src, byte pos)
            => bit.test(src,pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, 0 otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(uint src, byte pos)
            => bit.test(src,pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, 0 otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(long src, byte pos)
            => bit.test(src, pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, 0 otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(ulong src, byte pos)
            => bit.test(src, pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, false otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(float src, byte pos)
           => bit.test(BitConverter.SingleToInt32Bits(src),pos);

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, false otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(double src, byte pos)
            => bit.test(BitConverter.DoubleToInt64Bits(src),pos);
    }
}