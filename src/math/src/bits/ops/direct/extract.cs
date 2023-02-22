//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics.X86;

    partial class bits
    {
        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static sbyte extract(sbyte src, byte i0, byte i1)
            => (sbyte)Bmi1.BitFieldExtract((uint)src, i0, segwidth(i0,i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static byte extract(byte src, byte i0, byte i1)
            => (byte)Bmi1.BitFieldExtract((uint)src, i0, segwidth(i0,i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static short extract(short src, byte i0, byte i1)
            => (short)Bmi1.BitFieldExtract((uint)src, i0, segwidth(i0,i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static ushort extract(ushort src, byte i0, byte i1)
            => (ushort)Bmi1.BitFieldExtract((uint)src, i0, segwidth(i0,i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static uint extract(uint src, byte i0, byte i1)
            => Bmi1.BitFieldExtract(src, i0, segwidth(i0,i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static int extract(int src, byte i0, byte i1)
            => (int)Bmi1.BitFieldExtract((uint)src, i0, segwidth(i0,i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static ulong extract(ulong src, byte i0, byte i1)
            => Bmi1.X64.BitFieldExtract(src, i0, segwidth(i0,i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static long extract(long src, byte i0, byte i1)
            => (long)Bmi1.X64.BitFieldExtract((ulong)src, i0, segwidth(i0,i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static float extract(float src, byte i0, byte i1)
            => BitConverter.Int32BitsToSingle(extract(BitConverter.SingleToInt32Bits(src), i0, i1));

        /// <summary>
        /// Extracts a contiguous range of source bits determined by an inclusive range
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="i0">The position of the first bit</param>
        /// <param name="i1">The position of the last bit</param>
        [MethodImpl(Inline), BitSeg]
        public static double extract(double src, byte i0, byte i1)
            => BitConverter.Int64BitsToDouble(extract(BitConverter.DoubleToInt64Bits(src), i0, i1));
    }
}