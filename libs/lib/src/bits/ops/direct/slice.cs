//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class bits
    {
        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The position of the first bit</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice]
        public static sbyte slice(sbyte src, byte pos, byte width)
            => bextr(src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice]
        public static byte slice(byte src, byte pos, byte width)
            => bextr(src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice]
        public static short slice(short src, byte pos, byte width)
            => bextr(src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice]
        public static ushort slice(ushort src, byte pos, byte width)
            => bextr(src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice]
        public static int slice(int src, byte pos, byte width)
            => bextr(src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice]
        public static uint slice(uint src, byte pos, byte width)
            => bextr(src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice]
        public static long slice(long src, byte pos, byte width)
            => bextr(src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Slice]
        public static ulong slice(ulong src, byte pos, byte width)
             => bextr(src, pos, width);
   }
}