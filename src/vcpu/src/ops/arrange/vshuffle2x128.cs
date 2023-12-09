//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256i _mm256_shuffle_i32x4 (__m256i a, __m256i b, const int imm8)
    /// VSHUFI32x4 ymm1 {k1}{z}, ymm2, ymm3/m256/m32bcst, imm8
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vshuffle2x128(Vector256<uint> a, Vector256<uint> b, [Imm] byte spec)
        => Shuffle2x128(a, b, spec);

    /// <summary>
    /// __m256i _mm256_shuffle_i64x2 (__m256i a, __m256i b, const int imm8)
    /// VSHUFI64x2 ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst, imm8
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vshuffle2x128(Vector256<ulong> a, Vector256<ulong> b, [Imm] byte spec)
        => Shuffle2x128(a, b, spec);
}