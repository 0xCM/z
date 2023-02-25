//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        ///  __m128i _mm_packs_epi16 (__m128i a, __m128i b) PACKSSWB xmm, xmm/m128
        /// Converts packed signed 16-bit integers from the source operands to packed 8-bit integers using signed saturation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vpackss(Vector128<short> x, Vector128<short> y)
            => PackSignedSaturate(x,y);

        /// <summary>
        ///  __m128i _mm_packs_epi16 (__m128i a, __m128i b) PACKSSWB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vpackss(Vector128<ushort> x, Vector128<ushort> y)
            => PackSignedSaturate(v16i(x),v16i(y));

        /// <summary>
        /// __m128i _mm_packs_epi32 (__m128i a, __m128i b) PACKSSDW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vpackss(Vector128<int> x, Vector128<int> y)
            => PackSignedSaturate(x,y);

        /// <summary>
        /// __m128i _mm_packs_epi32 (__m128i a, __m128i b) PACKSSDW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vpackss(Vector128<uint> x, Vector128<uint> y)
            => PackSignedSaturate(v32i(x), v32i(y));

        /// <summary>
        /// __m256i _mm256_packs_epi16 (__m256i a, __m256i b) VPACKSSWB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vpackss(Vector256<short> x, Vector256<short> y)
            => PackSignedSaturate(x,y);

        /// <summary>
        /// __m256i _mm256_packs_epi16 (__m256i a, __m256i b) VPACKSSWB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vpackss(Vector256<ushort> x, Vector256<ushort> y)
            => PackSignedSaturate(v16i(x),v16i(y));

        /// <summary>
        /// __m256i _mm256_packs_epi32 (__m256i a, __m256i b) VPACKSSDW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vpackss(Vector256<int> x, Vector256<int> y)
            => PackSignedSaturate(x,y);

        /// <summary>
        /// __m256i _mm256_packs_epi32 (__m256i a, __m256i b) VPACKSSDW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vpackss(Vector256<uint> x, Vector256<uint> y)
            => PackSignedSaturate(v32i(x), v32i(y));
    }
}