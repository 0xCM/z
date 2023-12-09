//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_cvtepi16_epi32 (__m128i a)
    /// PMOVSXWD xmm, xmm/m64
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vmovsxwd(W128 w, Vector128<short> src)
        => ConvertToVector128Int32(src);

    /// <summary>
    /// __m128i _mm_cvtepi16_epi64 (__m128i a)
    /// PMOVSXWQ xmm, xmm/m32
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<long> vmovsxwq(W128 w, Vector128<short> src)
        => ConvertToVector128Int64(src);

    /// <summary>
    /// __m128i _mm_cvtepi8_epi32 (__m128i a)
    /// PMOVSXBD xmm, xmm/m32
    /// </summary>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<int> vmovsxbd(W128 w, Vector128<sbyte> src)
        => ConvertToVector128Int32(src);

    /// <summary>
    /// __m128i _mm_cvtepi8_epi16 (__m128i a)
    /// PMOVSXBW xmm, xmm/m64
    /// 8x8i -> 8x16i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vmovsxbw(W128 w, Vector128<sbyte> src)
        => ConvertToVector128Int16(src);

    /// <summary>
    /// __m256i _mm256_cvtepi8_epi16 (__m128i a)
    /// VPMOVSXBW ymm, xmm/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector256<short> vmovsxbw(W256 w, Vector128<sbyte> src)
        => ConvertToVector256Int16(src);

    /// <summary>
    /// __m256i _mm256_cvtepi16_epi64 (__m128i a)
    /// VPMOVSXDQ ymm, xmm/m128
    /// 4x16u -> 4x64u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vmovsxdq(W256 w, Vector128<short> src)
        => ConvertToVector256Int64(src);

    /// <summary>
    /// __m256i _mm256_cvtepi16_epi32 (__m128i a)
    /// VPMOVSXWD ymm, xmm/m128
    /// 8x16i -> 8x32i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target vector width</param>
    /// <param name="t">A target component type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vmovsxwd(W256 w, Vector128<short> src)
        => ConvertToVector256Int32(src);

    /// <summary>
    /// __m512i _mm512_cvtepi8_epi32 (__m128i a)
    /// VPMOVSXBD zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vmovsxbd(W512 w, Vector128<sbyte> src)
        => ConvertToVector512Int32(src);        

    /// <summary>
    /// __m512i _mm512_cvtepi16_epi32 (__m128i a)
    /// VPMOVSXWD zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vpmovsxwd(W512 w, Vector256<short> src)
        => ConvertToVector512Int32(src);

    /// <summary>
    /// __m256i _mm256_cvtepi32_epi64 (__m128i a)
    /// VPMOVSXDQ ymm, xmm/m128
    /// 4x32w -> 4x64w
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vmovsxdq(W256 w, Vector128<int> src)
        => ConvertToVector256Int64(src);                


}