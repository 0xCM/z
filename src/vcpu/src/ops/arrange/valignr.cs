//-----------------------------------------------------------------------------
// Copyy   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Ssse3;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu
    {
        /// <summary>
        /// __m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count) PALIGNR xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> valignr(Vector128<sbyte> x, Vector128<sbyte> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count) PALIGNR xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> valignr(Vector128<byte> x, Vector128<byte> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count) PALIGNR xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> valignr(Vector128<short> x, Vector128<short> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count) PALIGNR xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> valignr(Vector128<ushort> x, Vector128<ushort> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count) PALIGNR xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> valignr(Vector128<int> x, Vector128<int> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count) PALIGNR xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> valignr(Vector128<uint> x, Vector128<uint> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count) PALIGNR xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> valignr(Vector128<long> x, Vector128<long> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count) PALIGNR xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> valignr(Vector128<ulong> x, Vector128<ulong> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count) VPALIGNR ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> valignr(Vector256<sbyte> x, Vector256<sbyte> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count) VPALIGNR ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> valignr(Vector256<byte> x, Vector256<byte> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count) VPALIGNR ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> valignr(Vector256<short> x, Vector256<short> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count) VPALIGNR ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> valignr(Vector256<ushort> x, Vector256<ushort> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count) VPALIGNR ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> valignr(Vector256<int> x, Vector256<int> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count) VPALIGNR ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> valignr(Vector256<uint> x, Vector256<uint> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count) VPALIGNR ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> valignr(Vector256<long> x, Vector256<long> y, [Imm] byte offset)
            => AlignRight(x, y, offset);

        /// <summary>
        /// __m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count) VPALIGNR ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> valignr(Vector256<ulong> x, Vector256<ulong> y, [Imm] byte offset)
            => AlignRight(x, y, offset);
    }
}