//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static LimitValues;
    using static BitMasks;

    partial class bits
    {
        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified offset
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The position of the first bit</param>
        /// <param name="width">The width of the enabled segment</param>
        [MethodImpl(Inline), Enable]
        public static byte enable(byte src, byte offset, byte width)
        {
            var mask = (uint)Max16u ^ ((uint)lo64(width - 1) << offset);
            return (byte)(~(mask | src));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits beginning at a specified offset
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The position of the first bit</param>
        /// <param name="width">The width of the enabled segment</param>
        [MethodImpl(Inline), Enable]
        public static sbyte enable(sbyte src, byte offset, byte width)
        {
            var mask = (int)Max16u ^ ((int)lo64(width - 1) << offset);
            return (sbyte)(~(mask | (int)src));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits beginning at a specified offset
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The position of the first bit</param>
        /// <param name="width">The width of the enabled segment</param>
        [MethodImpl(Inline), Enable]
        public static ushort enable(ushort src, byte offset, byte width)
        {
            var mask = (uint)Max16u ^ ((uint)lo64(width - 1) << offset);
            return (ushort)(~(mask | src));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits beginning at a specified offset
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The position of the first bit enabling bits</param>
        /// <param name="width">The number of bits to enable</param>
        [MethodImpl(Inline), Enable]
        public static short enable(short src, byte offset, byte width)
        {
            var mask = (int)Max16u ^ ((int)lo64(width - 1) << offset);
            return (short)(~(mask | (int)src));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits beginning at a specified offset
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The position of the first bit</param>
        /// <param name="width">The width of the enabled segment</param>
        [MethodImpl(Inline), Enable]
        public static uint enable(uint src, byte offset, byte width)
        {
            var mask = Max32u ^ ((uint)lo64(width - 1) << offset);
            return ~(mask | src);
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits beginning at a specified offset
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The position of the first bit</param>
        /// <param name="width">The width of the enabled segment</param>
        [MethodImpl(Inline), Enable]
        public static int enable(int src, byte offset, byte width)
            => (int)enable((uint)src, offset, width);

        /// <summary>
        /// Enables a contiguous sequence of source bits beginning at a specified offset
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The position of the first bit</param>
        /// <param name="width">The width of the enabled segment</param>
        [MethodImpl(Inline), Enable]
        public static ulong enable(ulong src, byte offset, byte width)
        {
            var mask = Max64u ^ (lo64(width - 1) << offset);
            return ~(mask | src);
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits beginning at a specified offset
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="offset">The position of the first bit</param>
        /// <param name="width">The width of the enabled segment</param>
        [MethodImpl(Inline), Enable]
        public static long enable(long src, byte offset, byte width)
            => (long)enable((ulong)src, offset, width);
    }
}