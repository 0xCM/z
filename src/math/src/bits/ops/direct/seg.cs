//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static sbyte seg(sbyte src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static byte seg(byte src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static short seg(short src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the first bit</param>
        [MethodImpl(Inline), Op]
        public static ushort seg(ushort src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static uint seg(uint src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static int seg(int src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static ulong seg(ulong src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static long seg(long src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static float seg(float src, byte i0, byte i1)
            => extract(src, i0, i1);

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), Op]
        public static double seg(double src, byte i0, byte i1)
            => extract(src, i0, i1);
    }
}