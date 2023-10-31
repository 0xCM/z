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
    /// 4x8u -> 4x64i
    /// __m256i _mm256_cvtepu8_epi64 (__m128i a)
    /// VPMOVZXBQ ymm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vpmovzxbq(W256 w, Vector128<byte> src)
        => vcpu.v64u(ConvertToVector256Int64(src));        

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
}