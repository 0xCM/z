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
