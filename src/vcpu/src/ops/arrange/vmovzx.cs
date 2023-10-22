//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


partial class vcpu
{
    /// <summary>
    /// 8x8u -> 8x32u
    /// movzx(src[i]) -> dst[i], i = 0,..,7
    /// __m256i _mm256_cvtepu8_epi32(__m128i a)
    /// VPMOVZXBD ymm, xmm
    /// VPMOVZXBD_YMMqq_XMMq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vmovzxbd(Vector128<byte> src)
        => v32u(ConvertToVector256Int32(src));

    /// <summary>
    /// VPMOVSXWD ymm, xmm/m128
    /// 8x16u -> 8x32u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vmovzxwd(Vector256<ushort> src)
        => v32u(ConvertToVector256Int32(vlo(src)));

    /// <summary>
    /// 4x8u -> 4x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,3
    /// __m256i _mm256_cvtepu8_epi64(__m128i a)
    /// VPMOVZXBQ ymm, xmm
    /// VPMOVZXBQ_YMMqq_XMMd
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmovzxbq(Vector128<byte> src)
        => v64u(ConvertToVector256Int64(src));

    /// <summary>
    /// 4x8u -> 4x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,3
    /// __m256i _mm256_cvtepu8_epi64(__m128i a)
    /// VPMOVZXBQ ymm, xmm
    /// VPMOVZXBQ_YMMqq_XMMd
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmovzxbq(uint src)
        => v64u(ConvertToVector256Int64(vload(w128, sys.bytes(src))));

    /// <summary>
    /// 4x32 -> 4x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,3
    /// __m256i _mm256_cvtepu32_epi64(__m128i a)
    /// VPMOVZXDQ ymm, xmm
    /// VPMOVZXDQ_YMMqq_XMMdq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmovzxdq(Vector128<uint> src)
        => v64u(ConvertToVector256Int64(src));        

    /// <summary>
    /// 16x8u -> 16x16u
    /// movzx(src[i]) -> dst[i], i = 0,..,15
    /// __m256i _mm256_cvtepu8_epi16(__m128i a)
    /// VPMOVZXBW ymm, xmm
    /// VPMOVZXBW_YMMqq_XMMdq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vmovzxbw(Vector128<byte> src)
        => v16u(ConvertToVector256Int16(src));        

    [MethodImpl(Inline), Op]
    public static Vector256<uint> vhimovzxbd(Vector128<byte> src)
        => v32u(ConvertToVector256Int32(vshi(src)));

    /// <summary>
    /// 8x16u -> 8x32u
    /// movzx(src[i]) -> dst[i], i = 0,..,7
    /// __m256i _mm256_cvtepu16_epi32(__m128i a)
    /// VPMOVZXWD ymm, xmm
    /// VPMOVZXWD_YMMqq_XMMdq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vmovzxwd(Vector128<ushort> src)
        => v32u(ConvertToVector256Int32(src));            

    /// <summary>
    /// 4x16u -> 4x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,3
    /// __m256i _mm256_cvtepu16_epi64(__m128i a)
    /// VPMOVZXWQ ymm, xmm
    /// VPMOVZXWQ_YMMqq_XMMq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmovzxwq(Vector128<ushort> src)
        => v64u(ConvertToVector256Int64(src));

    /// <summary>
    /// 4x16u -> 4x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,3
    /// __m256i _mm256_cvtepu16_epi64(__m128i a)
    /// VPMOVZXWQ ymm, xmm
    /// VPMOVZXWQ_YMMqq_XMMq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmovzxwq(ulong src)
        => v64u(ConvertToVector256Int64(vload<ushort>(w128, sys.bytes(src))));        
}
