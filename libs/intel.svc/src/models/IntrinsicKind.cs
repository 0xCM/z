//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum IntrinsicKind : ushort
    {
        None,

        [Symbol("__m128i _mm_min_epi8(__m128i a, __m128i b)")]
        mm_min_epi8,

        [Symbol("__m128i _mm_ternarylogic_epi32(__m128i a, __m128i b, __m128i c, int imm8)")]
        mm_ternarylogic_epi32,

        [Symbol("__m128i _mm_avg_epu8(__m128i a, __m128i b)")]
        mm_avg_epu8,

        mm_delta_epu8,

        mm_blend_epi32,

        mm_packus_epi16,

        mm256_min_epu8,

        _mm256_cvtepi16_epi8,
    }
}