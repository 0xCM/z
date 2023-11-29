//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// 4x8u -> 4x32u
    /// movzx(src[i]) -> dst[i], i = 0,..,3
    /// __m128i _mm_cvtepu8_epi32 (__m128i a)
    /// PMOVZXBD xmm, xmm/m32
    /// PMOVZXBD_XMMdq_XMMd
    /// </summary>
    /// <param name="src">The source</param>
    /// <param name="dst">The target</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> pmovzxbd(Vector128<byte> src)
        => v32u(ConvertToVector128Int32(src));

    /// <summary>
    /// 2x8u -> 4x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,3
    /// __m128i _mm_cvtepu8_epi64 (__m128i a)
    /// PMOVZXBQ xmm, xmm/m16
    /// PMOVZXBQ_XMMdq_XMMw
    /// </summary>
    /// <param name="src">The source</param>
    /// <param name="dst">The target</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> pmovzxbq(Vector128<byte> src)
        => v64u(ConvertToVector128Int64(src));

    /// <summary>
    /// 2x32u -> 2x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,1
    /// __m128i _mm_cvtepu32_epi64(__m128i a)
    /// PMOVZXDQ xmm, xmm/m64
    /// PMOVZXDQ_XMMdq_XMMq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> pmovzxdq(Vector128<uint> src)
        => v64u(ConvertToVector128Int64(src));

    /// <summary>
    /// 8x8u -> 8x16u
    /// movzx(src[i]) -> dst[i], i = 0,.., 7
    /// __m128i _mm_cvtepu8_epi16 (__m128i a)
    /// PMOVZXBW xmm, xmm/m64
    /// PMOVZXBW_XMMdq_XMMq
    /// </summary>
    /// <param name="src">The source</param>
    /// <param name="dst">The target</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> pmovzxbw(Vector128<byte> src)
        => v16u(ConvertToVector128Int16(src));

    /// <summary>
    /// 4x16u -> 4x32u
    /// __m128i _mm_cvtepu16_epi32 (__m128i a)
    /// movzx(src[i]) -> dst[i], i = 0,..,3
    /// PMOVZXWD xmm, xmm/m64
    /// PMOVZXWD_XMMdq_XMMq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> pmovzxwd(Vector128<ushort> src)
        => v32u(ConvertToVector128Int32(src));

    /// <summary>
    /// 2x16u -> 2x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,1
    /// __m128i _mm_cvtepu16_epi64 (__m128i a)
    /// PMOVZXWQ xmm, xmm/m32
    /// PMOVZXWQ_XMMdq_XMMd
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> pmovzxwq(Vector128<ushort> src)
        => v64u(ConvertToVector128Int64(src));

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi64 (__m128i a)
    /// VPMOVZXWQ ymm, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vpmovzxwq(W256 w, Vector128<ushort> src)
        => v64u(ConvertToVector256Int64(src));

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi64 (__m128i a)
    /// VPMOVZXBQ zmm1 {k1}{z}, xmm2/m64
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vpmovzxbq(Vector128<byte> src)
        => ConvertToVector512UInt64(src);

    /// <summary>
    /// __m512i _mm512_cvtepu16_epi64 (__m128i a)
    /// VPMOVZXWQ zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vpmovzxwq(W512 w, Vector128<ushort> src)
        => v64u(ConvertToVector512Int64(src));        

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi32 (__m128i a)
    /// VPMOVZXBD zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vpmovzxbd(Vector128<byte> src)
        => ConvertToVector512UInt32(src);

    /// <summary>
    /// __m256i _mm256_cvtepu8_epi16 (__m128i a)
    /// VPMOVZXBW ymm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ushort> vpmovzxbw(Vector128<byte> src)
        => ConvertToVector256Int16(src).AsUInt16();

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi32 (__m128i a)
    /// VPMOVZXWD ymm, xmm
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<uint> vpmovzxwd(Vector128<ushort> src)
        => v32u(ConvertToVector256Int32(src));

    /// <summary>
    /// __m512i _mm512_cvtepu16_epi32 (__m128i a)
    /// VPMOVZXWD zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vpmovsxwd(Vector256<ushort> src)
        => ConvertToVector512UInt32(src);        

    /// <summary>
    /// __m512i _mm512_cvtepu16_epi32 (__m128i a)
    /// VPMOVZXWD zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector512<uint> vpmovzxwd(Vector256<ushort> src)
        => v32u(ConvertToVector512Int32(src));


    /// <summary>
    /// PMOVZXBW xmm, m64
    /// 8x8u -> 8x16u
    /// Projects 8 8-bit unsigned integers onto 8 unsigned 16-bit integers
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static unsafe Vector128<ushort> pmovzxbw(byte* pSrc)
        => v16u(ConvertToVector128Int16(pSrc)); 

    /// <summary>
    /// PMOVZXBQ xmm, m16
    /// 2x8u -> 2x64i
    /// Projects two unsigned 8-bit integers onto 2 signed 64-bit integers
    /// </summary>
    /// <param name="pSrc">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    /// <param name="i">Signals a sign extension</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ulong> pmovzxbq(byte* pSrc)
        => v64u(ConvertToVector128Int64(pSrc));

    /// <summary>
    /// VPMOVZXBD ymm, m64
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    public static unsafe Vector256<uint> vpmovzxbd(byte* src)
        => v32u(ConvertToVector256Int32(src));

    /// <summary>
    /// VPMOVZXBQ ymm, m32
    /// 4x8u -> 4x64u
    /// Projects four unsigned 8-bit integers onto 4 unsigned 64-bit integers
    /// </summary>
    /// <param name="pSrc">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="dst">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ulong> vpmovzxbq(byte* pSrc)
        => v64u(ConvertToVector256Int64(pSrc));


    /// <summary>
    /// __m512i _mm512_cvtepu8_epi16 (__m128i a)
    /// VPMOVZXBW zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<ushort> vpmovzxbw(Vector256<byte> src)
        => v16u(ConvertToVector512Int16(src));        

    /// <summary>
    /// VPMOVZXWQ ymm, m64
    /// 4x16u -> 4x64u
    /// Projects 4 unsigned 16-bit integers onto 4 unsigned 64-bit integers
    /// </summary>
    /// <param name="pSrc">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ulong> vpmovzxwq(ushort* pSrc)
        => v64u(ConvertToVector256Int64(pSrc));

    /// <summary>
    /// __m256i _mm256_cvtepu32_epi64 (__m128i a)
    /// VPMOVZXDQ ymm, xmm
    /// 4x32u -> 4x64u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="x0">The first target vector</param>
    /// <param name="x1">The second target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vpmovzxdq(Vector128<uint> src)
        => v64u(ConvertToVector256Int64(src));

    /// <summary>
    /// VPMOVZXDQ ymm, m128
    /// </summary>
    /// <param name="pSrc"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ulong> vpmovzxdq(uint* pSrc)
        => v64u(ConvertToVector256Int64(pSrc));

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi64 (__m128i a)
    /// VPMOVZXBQ zmm1 {k1}{z}, xmm2/m64
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vpmovzxdq(Vector128<byte> src)
        => v64u(ConvertToVector512Int64(src));

    /// <summary>
    /// VPMOVZXWD ymm, m128
    /// 8x16u -> 8x32u
    /// Projects 8 unsigned 16-bit integers onto 8 unsigned 32-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<uint> vpmovzxwd(ushort* pSrc)
        => v32u(ConvertToVector256Int32(pSrc));
}
