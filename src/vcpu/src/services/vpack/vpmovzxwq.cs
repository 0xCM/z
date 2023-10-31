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
}
