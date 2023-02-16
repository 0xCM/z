//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics.X86;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu
    {
        /// <summary>
        /// __m128i _mm_cmpeq_epi8 (__m128i a, __m128i b) PCMPEQB xmm, xmm/m128
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector128<sbyte> veq(Vector128<sbyte> x, Vector128<sbyte> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m128i _mm_cmpeq_epi8 (__m128i a, __m128i b) PCMPEQB xmm, xmm/m128
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector128<byte> veq(Vector128<byte> x, Vector128<byte> y)
            => CompareEqual(x,y);

        /// <summary>
        ///  __m128i _mm_cmpeq_epi16 (__m128i a, __m128i b) PCMPEQW xmm, xmm/m128
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector128<short> veq(Vector128<short> x, Vector128<short> y)
            => CompareEqual(x,y);

        /// <summary>
        ///  __m128i _mm_cmpeq_epi16 (__m128i a, __m128i b) PCMPEQW xmm, xmm/m128
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector128<ushort> veq(Vector128<ushort> x, Vector128<ushort> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m128i _mm_cmpeq_epi32 (__m128i a, __m128i b) PCMPEQD xmm, xmm/m128
        /// </summary>
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector128<int> veq(Vector128<int> x, Vector128<int> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m128i _mm_cmpeq_epi32 (__m128i a, __m128i b) PCMPEQD xmm, xmm/m128
        /// </summary>
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector128<uint> veq(Vector128<uint> x, Vector128<uint> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m128i _mm_cmpeq_epi64 (__m128i a, __m128i b) PCMPEQQ xmm, xmm/m128
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector128<long> veq(Vector128<long> x, Vector128<long> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m128i _mm_cmpeq_epi64 (__m128i a, __m128i b) PCMPEQQ xmm, xmm/m128
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector128<ulong> veq(Vector128<ulong> x, Vector128<ulong> y)
            => CompareEqual(x,y);

        /// <summary>
        ///  __m128 _mm_cmpeq_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(0)
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> veq(Vector128<float> x, Vector128<float> y)
            => CompareEqual(x, y);

        /// <summary>
        /// __m128d _mm_cmpeq_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(0)
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> veq(Vector128<double> x, Vector128<double> y)
            => CompareEqual(x, y);

        /// <summary>
        /// __m256i _mm256_cmpeq_epi8 (__m256i a, __m256i b) VPCMPEQB ymm, ymm, ymm/m256
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector256<sbyte> veq(Vector256<sbyte> x, Vector256<sbyte> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m256i _mm256_cmpeq_epi8 (__m256i a, __m256i b) VPCMPEQB ymm, ymm, ymm/m256
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector256<byte> veq(Vector256<byte> x, Vector256<byte> y)
            => CompareEqual(x,y);

        /// <summary>
        ///  __m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b) VPCMPEQW ymm, ymm, ymm/m256
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector256<short> veq(Vector256<short> x, Vector256<short> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b) VPCMPEQW ymm, ymm, ymm/m256
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector256<ushort> veq(Vector256<ushort> x, Vector256<ushort> y)
            => CompareEqual(x,y);

        /// <summary>
        /// _mm256_cmpeq_epi32 (__m256i a, __m256i b) VPCMPEQD ymm, ymm, ymm/m256
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector256<int> veq(Vector256<int> x, Vector256<int> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m256i _mm256_cmpeq_epi32 (__m256i a, __m256i b) VPCMPEQD ymm, ymm, ymm/m256
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector256<uint> veq(Vector256<uint> x, Vector256<uint> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b) VPCMPEQQ ymm, ymm, ymm/m256
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector256<long> veq(Vector256<long> x, Vector256<long> y)
            => CompareEqual(x,y);

        /// <summary>
        ///  __m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b) VPCMPEQQ ymm, ymm, ymm/m256
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Eq]
        public static Vector256<ulong> veq(Vector256<ulong> x, Vector256<ulong> y)
            => CompareEqual(x,y);

        /// <summary>
        /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> veq(Vector256<float> x, Vector256<float> y)
            => Compare(x, y, FloatComparisonMode.UnorderedEqualNonSignaling);

        /// <summary>
        /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm, ymm/m256, imm8
        /// Compares the source operands for equality. For equal components, the corresponding
        /// component in the result vector has all bits enabled; otherwise all bits are disabled
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> veq(Vector256<double> x, Vector256<double> y)
            => Compare(x, y, FloatComparisonMode.UnorderedEqualNonSignaling);
    }
}