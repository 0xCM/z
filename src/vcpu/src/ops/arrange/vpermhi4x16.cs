//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.X86.Sse2;
using static System.Runtime.Intrinsics.X86.Avx2;

partial class vcpu
{
    ///<summary>
    /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
    ///</summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vpermhi4x16(Vector128<short> src, [Imm] Perm4L spec)
        => ShuffleHigh(src, (byte)spec);

    /// <summary>
    /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
    /// Shuffles the upper half of a vector as specified by a permutation while leaving the lower half unchanged
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vpermhi4x16(Vector128<ushort> src, [Imm] Perm4L spec)
        => ShuffleHigh(src, (byte)spec);

    /// <summary>
    /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8) VPSHUFHW ymm, ymm/m256,imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vpermhi4x16(Vector256<short> src, [Imm] Perm4L spec)
        => ShuffleHigh(src, (byte)spec);

    /// <summary>
    /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8) VPSHUFHW ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vpermhi4x16(Vector256<ushort> src, [Imm] Perm4L spec)
        => ShuffleHigh(src, (byte)spec);
}
