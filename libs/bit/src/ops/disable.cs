//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct bit
    {
        /// <summary>
        /// Disables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Disable]
        public static sbyte disable(sbyte src, int pos)
            => (sbyte)(src & (byte)~((sbyte)(1 << pos)));

        /// <summary>
        /// Disables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Disable]
        public static byte disable(byte src, int pos)
            => (byte)(src & (byte)~((byte)(1 << pos)));

        /// <summary>
        /// Disables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Disable]
        public static short disable(short src, int pos)
            => (short)(src & (short)~((short)(1 << pos)));

        /// <summary>
        /// Disables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Disable]
        public static ushort disable(ushort src, int pos)
            => (ushort)(src & (ushort)~((ushort)(1 << pos)));

        /// <summary>
        /// Disables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Disable]
        public static int disable(int src, int pos)
            => src & ~((1 << pos));

        /// <summary>
        /// Disables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Disable]
        public static uint disable(uint src, int pos)
            => src & ~((1u << pos));

        /// <summary>
        /// Disables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Disable]
        public static long disable(long src, int pos)
            => src & ~((1L << pos));

        /// <summary>
        /// Disables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to disable</param>
        [MethodImpl(Inline), Disable]
        public static ulong disable(ulong src, int pos)
            => src & ~((1ul << pos));
    }
}