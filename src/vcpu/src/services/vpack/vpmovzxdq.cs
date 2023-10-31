//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial struct vpack
{
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
}