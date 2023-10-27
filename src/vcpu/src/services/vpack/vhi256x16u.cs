//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// __m256i _mm256_cvtepu8_epi16 (__m128i a)
    /// VPMOVZXBW ymm, xmm
    /// 16x8u -> 16x16u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width selector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vhi256x16u(Vector256<byte> src)
        => v16u(ConvertToVector256Int16(vhi(src)));

    /// <summary>
    /// __m256i _mm256_cvtepi16_epi32 (__m128i a)
    /// VPMOVSXWD ymm, xmm/m128
    /// 8x16u -> 8x32u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width selector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vhi256x16u(Vector256<ushort> src)
        => v32u(ConvertToVector256Int32(vhi(src)));
}
