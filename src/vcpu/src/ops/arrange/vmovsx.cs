//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// PMOVSXBW xmm, m64
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static unsafe Vector128<short> pmovsxbw(sbyte* pSrc)
        => ConvertToVector128Int16(pSrc);

    /// <summary>
    /// PMOVSXBD xmm, m32
    /// </summary>
    /// <param name="pSrc"></param>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static unsafe Vector128<int> pmovsxbd(sbyte* pSrc)
        => ConvertToVector128Int32(pSrc);

    /// <summary>
    /// PMOVSXBQ xmm, m16
    /// </summary>
    /// <param name="pSrc"></param>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static unsafe Vector128<long> pmovsxbq(sbyte* pSrc)
        => ConvertToVector128Int64(pSrc);

    /// <summary>
    /// PMOVSXWQ xmm, m32
    /// 2x16i -> 2x64u
    /// Projects 2 16-bit signed integers onto 2 64-bit signed integers
    /// </summary>
    /// <param name="pSrc">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<long> pmovsxwq(short* pSrc)
        => ConvertToVector128Int64(pSrc);

    /// <summary>
    /// PMOVSXDQ xmm, m64
    /// 2x32i -> 2x64i
    /// Projects 2 signed 32-bit integers onto 2 signed 64-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<long> pmovsxdq(int* pSrc)
        => ConvertToVector128Int64(pSrc);

    /// <summary>
    /// VPMOVSXDQ ymm, m128
    /// </summary>
    /// <param name="pSrc"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<long> vpmovsxdq(int* pSrc)
        => ConvertToVector256Int64(pSrc);        

    /// <summary>
    /// PMOVZXDQ xmm, m64
    /// 2x32i -> 2x64i
    /// Projects 2 unsigned 32-bit integers onto 2 usigned 64-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ulong> pmovzxdq(uint* pSrc)
        => v64u(ConvertToVector128Int64(pSrc));

    /// <summary>
    /// __m128i _mm_cvtepi16_epi64 (__m128i a)
    /// PMOVSXWQ xmm, xmm/m32
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<long> pmovsxwq(Vector128<short> src)
        => ConvertToVector128Int64(src);

    /// <summary>
    /// __m128i _mm_cvtepi8_epi32 (__m128i a)
    /// PMOVSXBD xmm, xmm/m32
    /// </summary>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<int> pmovsxbd(Vector128<sbyte> src)
        => ConvertToVector128Int32(src);

    /// <summary>
    /// __m128i _mm_cvtepi8_epi16 (__m128i a)
    /// PMOVSXBW xmm, xmm/m64
    /// 8x8i -> 8x16i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> pmovsxbw(Vector128<sbyte> src)
        => ConvertToVector128Int16(src);

    /// <summary>
    /// __m256i _mm256_cvtepi16_epi32 (__m128i a)
    /// VPMOVSXWD ymm, xmm/m128
    /// 8x16i -> 8x32i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target vector width</param>
    /// <param name="t">A target component type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vpmovsxwd(Vector128<short> src)
        => ConvertToVector256Int32(src);

    /// <summary>
    /// __m512i _mm512_cvtepi8_epi32 (__m128i a)
    /// VPMOVSXBD zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vpmovsxbd(Vector128<sbyte> src)
        => ConvertToVector512Int32(src);        

    /// <summary>
    /// __m256i _mm256_cvtepi8_epi16 (__m128i a)
    /// VPMOVSXBW ymm, xmm/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector256<short> vpmovsxbw(Vector128<sbyte> src)
        => ConvertToVector256Int16(src);

    /// <summary>
    /// __m512i _mm512_cvtepi16_epi32 (__m128i a)
    /// VPMOVSXWD zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vpmovsxwd(Vector256<short> src)
        => ConvertToVector512Int32(src);

    /// <summary>
    /// __m256i _mm256_cvtepi32_epi64 (__m128i a)
    /// VPMOVSXDQ ymm, xmm/m128
    /// 4x32w -> 4x64w
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vpmovsxdq(Vector128<int> src)
        => ConvertToVector256Int64(src);                

    /// <summary>
    /// __m256i _mm256_cvtepi16_epi64 (__m128i a)
    /// VPMOVSXDQ ymm, xmm/m128
    /// 4x16u -> 4x64u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vpmovsxdq(Vector128<short> src)
        => ConvertToVector256Int64(src);

    /// <summary>
    /// __m128i _mm_cvtepi16_epi32 (__m128i a)
    /// PMOVSXWD xmm, xmm/m64
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> pmovsxwd(Vector128<short> src)
        => ConvertToVector128Int32(src);
}