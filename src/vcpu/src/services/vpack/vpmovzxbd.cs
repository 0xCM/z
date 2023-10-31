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
}