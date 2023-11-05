//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;
using static sys;

partial struct vpack
{
    /// <summary>
    /// PMOVZXDQ xmm, m64
    /// 2x32i -> 2x64i
    /// Projects 2 unsigned 32-bit integers onto 2 usigned 64-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ulong> pmovzxdq(W128 w, uint* pSrc)
        => v64u(ConvertToVector128Int64(pSrc));

    /// <summary>
    /// PMOVZXBW xmm, m64
    /// 8x8u -> 8x16u
    /// Projects 8 8-bit unsigned integers onto 8 16-bit unsigned integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="dst">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ushort> pmovzxbw(W128 w, Vector128<byte> src)
        => v16u(ConvertToVector128Int16(src));

    /// <summary>
    /// PMOVZXBW xmm, m64
    /// 8x8u -> 8x16u
    /// Projects 8 8-bit unsigned integers onto 8 unsigned 16-bit integers
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static unsafe Vector128<ushort> pmovzxbw(W128 w, byte* pSrc)
        => v16u(ConvertToVector128Int16(pSrc)); 

    /// <summary>
    /// PMOVZXBD xmm, xmm/m32
    /// __m128i _mm_cvtepu8_epi32 (__m128i a)
    /// 4x8u -> 4x32u
    /// Zero extend 4 packed 8-bit integers in the low 4 bytes of xmm2/m32 to 4 packed 32-bit integers in xmm1.
    /// </summary>
    /// <param name="src">The input component source</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<uint> pmovzxbd(W128 w, Vector128<byte> src)
        => v32u(ConvertToVector128Int32(src));
            
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
    public static unsafe Vector128<ulong> pmovzxbq(W128 w,  byte* pSrc)
        => v64u(ConvertToVector128Int64(pSrc));

    /// <summary>
    /// __m256i _mm256_cvtepu8_epi32 (__m128i a)
    /// VPMOVZXBD ymm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vpmovzxbd(W128 w, Vector128<byte> src)
        => v32u(ConvertToVector256Int32(src));

    /// <summary>
    /// VPMOVZXBD ymm, m64
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    public static unsafe Vector256<uint> vpmovzxbd(W256 w, byte* src)
        => v32u(ConvertToVector256Int32(src));

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi32 (__m128i a)
    /// VPMOVZXBD zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector512<uint> vpmovzxbd(W512 w, Vector128<byte> src)
        => v32u(ConvertToVector512Int32(src));

    /// <summary>
    /// 4x8u -> 4x64i
    /// __m256i _mm256_cvtepu8_epi64 (__m128i a)
    /// VPMOVZXBQ ymm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vpmovzxbq(W256 w, Vector128<byte> src)
        => v64u(ConvertToVector256Int64(src));        

    /// <summary>
    /// VPMOVZXBQ ymm, m32
    /// 4x8u -> 4x64u
    /// Projects four unsigned 8-bit integers onto 4 unsigned 64-bit integers
    /// </summary>
    /// <param name="pSrc">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="dst">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ulong> vpmovzxbq(W256 w, byte* pSrc)
        => v64u(ConvertToVector256Int64(pSrc));

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi64 (__m128i a)
    /// VPMOVZXBQ zmm1 {k1}{z}, xmm2/m64
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vpmovzxbq(W512 w, Vector128<byte> src)
        => v64u(ConvertToVector512Int64(src));        

    /// <summary>
    /// __m256i _mm256_cvtepu8_epi16 (__m128i a)
    /// VPMOVZXBW ymm, xmm
    /// 16x8u -> 16x16u
    /// Projects 16 unsigned 8-bit integers onto 16 unsigned 16-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ushort> vpmovzxbw(W256 w, Vector128<byte> src)
        => ConvertToVector256Int16(src).AsUInt16();

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi16 (__m128i a)
    /// VPMOVZXBW zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<ushort> vpmovzxbw(W512 w, Vector256<byte> src)
        => v16u(ConvertToVector512Int16(src));        

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi64 (__m128i a)
    /// VPMOVZXWQ ymm, xmm
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ulong> vpmovzxwq(W256 w, Vector128<ushort> src)
        => v64u(ConvertToVector256Int64(src));

    /// <summary>
    /// VPMOVZXWQ ymm, m64
    /// 4x16u -> 4x64u
    /// Projects 4 unsigned 16-bit integers onto 4 unsigned 64-bit integers
    /// </summary>
    /// <param name="pSrc">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ulong> vpmovzxwq(W256 w, ushort* pSrc)
        => v64u(ConvertToVector256Int64(pSrc));

    /// <summary>
    /// __m512i _mm512_cvtepu16_epi64 (__m128i a)
    /// VPMOVZXWQ zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector512<ulong> vpmovzxwq(W512 w, Vector128<ushort> src)
        => ConvertToVector512UInt64(src);        

    /// <summary>
    /// __m256i _mm256_cvtepu32_epi64 (__m128i a)
    /// VPMOVZXDQ ymm, xmm
    /// 4x32u -> 4x64u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="x0">The first target vector</param>
    /// <param name="x1">The second target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vpmovzxdq(W256 w, Vector128<uint> src)
        => v64u(ConvertToVector256Int64(src));

    /// <summary>
    /// VPMOVZXDQ ymm, m128
    /// </summary>
    /// <param name="pSrc"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ulong> vpmovzxdq(W256 w, uint* pSrc)
        => v64u(ConvertToVector256Int64(pSrc));

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi64 (__m128i a)
    /// VPMOVZXBQ zmm1 {k1}{z}, xmm2/m64
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vpmovzxdq(W256 w, Vector128<byte> src)
        => v64u(ConvertToVector512Int64(src));

   /// <summary>
    /// __m256i _mm256_cvtepu16_epi32 (__m128i a)
    /// VPMOVZXWD ymm, xmm
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<uint> vpmovzxwd(W256 w, Vector128<ushort> src)
        => v32u(ConvertToVector256Int32(src));

    /// <summary>
    /// VPMOVZXWD ymm, m128
    /// 8x16u -> 8x32u
    /// Projects 8 unsigned 16-bit integers onto 8 unsigned 32-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<uint> vpmovzxwd(W256 w, ushort* pSrc)
        => v32u(ConvertToVector256Int32(pSrc));

    /// <summary>
    /// __m512i _mm512_cvtepu16_epi32 (__m128i a)
    /// VPMOVZXWD zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector512<uint> vpmovzxwd(W512 w, Vector256<ushort> src)
        => v32u(ConvertToVector512Int32(src));

}