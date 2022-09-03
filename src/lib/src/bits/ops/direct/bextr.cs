//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Bmi1;
    using static System.Runtime.Intrinsics.X86.Bmi1.X64;

    partial class bits
    {
        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// unsigned int _bextr_u32 (unsigned int a, unsigned int pos, unsigned int len) BEXTR r32a, reg/m32, r32b
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The position of the first bit</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Op]
        public static sbyte bextr(sbyte src, byte pos, byte width)
            => (sbyte)BitFieldExtract((uint)src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// unsigned int _bextr_u32 (unsigned int a, unsigned int pos, unsigned int len) BEXTR r32a, reg/m32, r32b
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Op]
        public static byte bextr(byte src, byte pos, byte width)
            => (byte)BitFieldExtract((uint)src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// unsigned int _bextr_u32 (unsigned int a, unsigned int pos, unsigned int len) BEXTR r32a, reg/m32, r32b
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Op]
        public static short bextr(short src, byte pos, byte width)
            => (short)BitFieldExtract((uint)src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// unsigned int _bextr_u32 (unsigned int a, unsigned int pos, unsigned int len) BEXTR r32a, reg/m32, r32b
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Op]
        public static ushort bextr(ushort src, byte pos, byte width)
            => (ushort)BitFieldExtract((uint)src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// unsigned int _bextr_u32 (unsigned int a, unsigned int pos, unsigned int len) BEXTR r32a, reg/m32, r32b
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Op]
        public static int bextr(int src, byte pos, byte width)
            => (int)BitFieldExtract((uint)src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// unsigned int _bextr_u32 (unsigned int a, unsigned int pos, unsigned int len) BEXTR r32a, reg/m32, r32b
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Op]
        public static uint bextr(uint src, byte pos, byte width)
            => BitFieldExtract(src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// unsigned __int64 _bextr_u64 (unsigned __int64 a, unsigned int pos, unsigned int len) BEXTR r64a, reg/m64, r64b
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Op]
        public static long bextr(long src, byte pos, byte width)
            => (long)BitFieldExtract((ulong)src, pos, width);

        /// <summary>
        /// Extracts a contiguous range of bits beginning at a specified pos
        /// unsigned __int64 _bextr_u64 (unsigned __int64 a, unsigned int pos, unsigned int len) BEXTR r64a, reg/m64, r64b
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The bit position within the source where extraction should benin</param>
        /// <param name="width">The number of bits that should be extracted</param>
        [MethodImpl(Inline), Op]
        public static ulong bextr(ulong src, byte pos, byte width)
            => BitFieldExtract(src, pos, width);
    }
}