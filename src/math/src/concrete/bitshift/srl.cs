//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Applies a logical right shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift rightwards</param>
        [MethodImpl(Inline), Srl]
        public static sbyte srl(sbyte src, byte offset)
            => (sbyte)srl32i(src,offset);

        /// <summary>
        /// Applies a logical right shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift rightwards</param>
        [MethodImpl(Inline), Srl]
        public static byte srl(byte src, byte offset)
            => (byte)srl32u(src,offset);

        /// <summary>
        /// Applies a logical right shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift rightwards</param>
        [MethodImpl(Inline), Srl]
        public static short srl(short src, byte offset)
            => (short) srl32i(src,offset);

        /// <summary>
        /// Applies a logical right shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift rightwards</param>
        [MethodImpl(Inline), Srl]
        public static ushort srl(ushort src, byte offset)
            => (ushort) srl32u(src,offset);

        /// <summary>
        /// Applies a logical right shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift rightwards</param>
        [MethodImpl(Inline), Srl]
        public static int srl(int src, byte offset)
            => srl32i(src,offset);

        /// <summary>
        /// Applies a logical right shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift rightwards</param>
        [MethodImpl(Inline), Srl]
        public static uint srl(uint src, byte offset)
            => srl32u(src,offset);

        /// <summary>
        /// Applies a logical right shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift rightwards</param>
        [MethodImpl(Inline), Srl]
        public static long srl(long src, byte offset)
            => srl64i(src,offset);

        /// <summary>
        /// Applies a logical right shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift rightwards</param>
        [MethodImpl(Inline), Srl]
        public static ulong srl(ulong src, byte offset)
            => srl64u(src,offset);

        [MethodImpl(Inline), Srl]
        static int srl32i(int src, byte offset)
            => (int)((uint)src >> offset);

        [MethodImpl(Inline), Srl]
        static uint srl32u(uint src, byte offset)
            => src >> offset;

        [MethodImpl(Inline), Srl]
        static long srl64i(long src, byte offset)
            => (long)((ulong)src >> offset);

        [MethodImpl(Inline), Srl]
        static ulong srl64u(ulong src, byte offset)
            => src >> offset;
    }
}