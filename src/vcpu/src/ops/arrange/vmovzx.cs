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
    public static Vector128<uint> vmovzxbd(W128 w, Vector128<byte> src)
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
    public static Vector128<ulong> vmovzxbq(W128 w, Vector128<byte> src)
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
    public static Vector128<ulong> vmovzxdq(W128 w, Vector128<uint> src)
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
    public static Vector128<ushort> vmovzxbw(W128 w, Vector128<byte> src)
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
    public static Vector128<uint> vmovzxwd(W128 w, Vector128<ushort> src)
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
    public static Vector128<ulong> vmovzxwq(W128 w, Vector128<ushort> src)
        => v64u(ConvertToVector128Int64(src));

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi64 (__m128i a)
    /// VPMOVZXWQ ymm, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmovzxwq(W256 w, Vector128<ushort> src)
        => v64u(ConvertToVector256Int64(src));

    /// <summary>
    /// __m256i _mm256_cvtepu16_epi32 (__m128i a)
    /// VPMOVZXWD ymm, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vmovzxwd(W256 w, Vector128<ushort> src)
        => v32u(ConvertToVector256Int32(src));

    /// <summary>
    /// __m256i _mm256_cvtepu32_epi64 (__m128i a)
    /// VPMOVZXDQ ymm, xmm
    /// 4x32u -> 4x64u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="x0">The first target vector</param>
    /// <param name="x1">The second target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmovzxdq(W256 w, Vector128<uint> src)
        => v64u(ConvertToVector256Int64(src));

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi64 (__m128i a)
    /// VPMOVZXBQ zmm1 {k1}{z}, xmm2/m64
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vmovzxbq(W512 w, Vector128<byte> src)
        => ConvertToVector512UInt64(src);

    /// <summary>
    /// __m512i _mm512_cvtepu16_epi64 (__m128i a)
    /// VPMOVZXWQ zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vmovzxwq(W512 w, Vector128<ushort> src)
        => v64u(ConvertToVector512Int64(src));        

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi32 (__m128i a)
    /// VPMOVZXBD zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vmovzxbd(W512 w, Vector128<byte> src)
        => ConvertToVector512UInt32(src);

    /// <summary>
    /// __m256i _mm256_cvtepu8_epi16 (__m128i a)
    /// VPMOVZXBW ymm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<ushort> vmovzxbw(W256 w, Vector128<byte> src)
        => ConvertToVector256Int16(src).AsUInt16();

    /// <summary>
    /// __m512i _mm512_cvtepu16_epi32 (__m128i a)
    /// VPMOVZXWD zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector512<uint> vmovzxwd(W512 w, Vector256<ushort> src)
        => v32u(ConvertToVector512Int32(src));

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi16 (__m128i a)
    /// VPMOVZXBW zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector512<ushort> vmovzxbw(W512 w, Vector256<byte> src)
        => v16u(ConvertToVector512Int16(src));        

    /// <summary>
    /// __m512i _mm512_cvtepu8_epi64 (__m128i a)
    /// VPMOVZXBQ zmm1 {k1}{z}, xmm2/m64
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vmovzxq(W512 w, Vector128<byte> src)
        => v64u(ConvertToVector512Int64(src));
}
