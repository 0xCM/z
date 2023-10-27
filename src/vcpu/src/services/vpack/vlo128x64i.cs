//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// __m256i _mm256_cvtepi16_epi64 (__m128i a)
    /// VPMOVSXDQ ymm, xmm/m128
    /// 4x16u -> 4x64u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vlo256x64i(Vector128<short> src)
        => ConvertToVector256Int64(src);

    /// <summary>
    /// __m128i _mm_cvtepu32_epi64 (__m128i a)
    /// PMOVZXDQ xmm, xmm/m64
    /// 2x32u -> 2x64i
    /// src[i] -> dst[i], i = 0, 2
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vlo128x64i(Vector128<uint> src)
        => ConvertToVector128Int64(src);

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi64 (__m128i a)
    /// VPMOVZXWQ ymm, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vlo256x64i(Vector128<ushort> src)
        => ConvertToVector256Int64(src);
}
