//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Enables the source operand's rightmost / least significant zero bit
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static byte lsbon(byte src)
            => (byte)(src | (byte)(src + 1));

        /// <summary>
        /// Enables the source operand's rightmost / least significant zero bit
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static sbyte lsbon(sbyte src)
            => (sbyte)(src | (sbyte)(src + 1));

        /// <summary>
        /// Enables the source operand's rightmost / least significant zero bit
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static ushort lsbon(ushort src)
            => (ushort)(src | (ushort)(src + 1));

        /// <summary>
        /// Enables the source operand's rightmost / least significant zero bit
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static short lsbon(short src)
            => (short)(src | (short)(src + 1));

        /// <summary>
        /// Enables the source operand's rightmost / least significant zero bit
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static uint lsbon(uint src)
            => src | (src + 1);

        /// <summary>
        /// Enables the source operand's rightmost / least significant zero bit
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static int lsbon(int src)
            => src | (src + 1);

        /// <summary>
        /// Enables the source operand's rightmost / least significant zero bit
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static ulong lsbon(ulong src)
            => src | (src + 1);

        /// <summary>
        /// Enables the source operand's rightmost / least significant zero bit
        /// </summary>
        /// <param name="src">The source operand</param>
        [MethodImpl(Inline), Op]
        public static long lsbon(long src)
            => src | (src + 1);
    }
}