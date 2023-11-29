//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vshufhi(Vector128<ushort> src, [Imm] byte spec)
        => ShuffleHigh(src, spec);

    /// <summary>
    /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vshufhi(Vector128<short> src, [Imm] byte spec)
        => ShuffleHigh(src, spec);

    /// <summary>
    /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vshufhi(Vector128<short> src, [Imm] Arrange4L spec)
        => vshufhi(src,(byte)spec);

    ///<summary>
    /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
    ///</summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vshufhi(Vector128<short> src, [Imm] Perm4L spec)
        => ShuffleHigh(src, (byte)spec);

    /// <summary>
    /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
    /// Shuffles the upper half of a vector as specified by a permutation while leaving the lower half unchanged
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vshufhi(Vector128<ushort> src, [Imm] Perm4L spec)
        => ShuffleHigh(src, (byte)spec);

    /// <summary>
    /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8) VPSHUFHW ymm, ymm/m256,imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vshufhi(Vector256<short> src, [Imm] Perm4L spec)
        => ShuffleHigh(src, (byte)spec);

    /// <summary>
    /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8) VPSHUFHW ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vshufhi(Vector256<ushort> src, [Imm] Perm4L spec)
        => ShuffleHigh(src, (byte)spec);
        
    /// <summary>
    /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)VPSHUFHW ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vshufhi(Vector256<ushort> src, [Imm] byte spec)
        => ShuffleHigh(src,spec);

    /// <summary>
    /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)VPSHUFHW ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vshufhi(Vector256<short> src, [Imm] byte spec)
        => ShuffleHigh(src,spec);

    /// <summary>
    /// __m128i _mm_shufflehi_epi16 (__m128i a, int control) PSHUFHW xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vshufhi(Vector128<ushort> src, [Imm] Arrange4L spec)
        => vshufhi(src,(byte)spec);

    /// <summary>
    /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)VPSHUFHW ymm, ymm/m256, imm8
    /// Shuffles the hi 64 bits of each 128-bit lane as determined by the shuffle spec and leaves
    /// the lo 64 bits of each 128-bit lane unchanged
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vshufhi(Vector256<ushort> src, [Imm] Arrange4L spec)
        => vshufhi(src,(byte)spec);

    /// <summary>
    /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)VPSHUFHW ymm, ymm/m256, imm8
    /// Shuffles the hi 64 bits of each 128-bit lane as determined by the shuffle spec and leaves
    /// the lo 64 bits of each 128-bit lane unchanged
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vshufhi(Vector256<short> src, [Imm] Arrange4L spec)
        => vshufhi(src,(byte)spec);

    /// <summary>
    /// __m512i _mm512_shufflehi_epi16 (__m512i a, const int imm8)
    /// VPSHUFHW zmm1 {k1}{z}, zmm2/m512, imm8
    /// Shuffle 16-bit integers in the high 64 bits of 128-bit lanes of a using the control in imm8. Store the results in the high 64 bits of 128-bit lanes of dst, with the low 64 bits of 128-bit lanes being copied from from a to dst.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    public static Vector512<short> vshufhi(Vector512<short> a, byte spec)    
        => ShuffleHigh(a, spec);
        
    /// <summary>
    /// __m512i _mm512_shufflehi_epi16 (__m512i a, const int imm8)
    /// VPSHUFHW zmm1 {k1}{z}, zmm2/m512, imm8
    /// Shuffle 16-bit integers in the high 64 bits of 128-bit lanes of a using the control in imm8. Store the results in the high 64 bits of 128-bit lanes of dst, with the low 64 bits of 128-bit lanes being copied from from a to dst.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    public static Vector512<ushort> vshufhi(Vector512<ushort> a, byte spec)    
        => ShuffleHigh(a, spec);        
}
