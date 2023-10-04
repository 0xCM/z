//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    /// <summary>
    /// __m256i _mm256_cvtepi16_epi32 (__m128i a)
    /// VPMOVSXWD ymm, xmm/m128
    /// 8x16i -> 8x32i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target vector width</param>
    /// <param name="t">A target component type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vinflate256x32i(Vector128<short> src)
        => ConvertToVector256Int32(src);

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi32 (__m128i a)
    /// VPMOVZXWD ymm, xmm
    /// 8x16u -> 8x32i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vinflate256x32i(Vector128<ushort> src)
        => ConvertToVector256Int32(src);
}
