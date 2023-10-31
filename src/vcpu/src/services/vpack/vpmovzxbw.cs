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
}