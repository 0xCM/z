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
    /// PMOVZXBD xmm, xmm/m32
    /// __m128i _mm_cvtepu8_epi32 (__m128i a)
    /// 4x8u -> 4x32u
    /// Zero extend 4 packed 8-bit integers in the low 4 bytes of xmm2/m32 to 4 packed 32-bit integers in xmm1.
    /// </summary>
    /// <param name="src">The input component source</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<uint> pmovzxbd(W128 w, Vector128<byte> src)
        => v32u(ConvertToVector128Int32(src));
}
