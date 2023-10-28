//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    ///  __m128i _mm_sign_epi8 (__m128i a, __m128i b) PSIGNB xmm, xmm/m128
    /// Negates target vector elements if the corresponding element in the match vector is negative;
    /// If the corresponding component in the match vector is zero, the target vector component is set to zero
    /// </summary>
    /// <param name="dst">The target vector</param>
    /// <param name="match">The match vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vsign(Vector128<sbyte> dst, Vector128<sbyte> match)
        => Sign(dst, match);

    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vsign(Vector128<sbyte> src)
        => Sign(vgcpu.vones<sbyte>(w128), src);

    /// <summary>
    ///  __m128i _mm_sign_epi16 (__m128i a, __m128i b) PSIGNW xmm, xmm/m128
    /// Negates target vector elements if the corresponding element in the match vector is negative;
    /// If the corresponding component in the match vector is zero, the target vector component is set to zero
    /// </summary>
    /// <param name="dst">The target vector</param>
    /// <param name="match">The match vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vsign(Vector128<short> dst, Vector128<short> match)
        => Sign(dst, match);

    /// <summary>
    ///  __m128i _mm_sign_epi32 (__m128i a, __m128i b) PSIGND xmm, xmm/m128
    /// Negates target vector elements if the corresponding element in the match vector is negative;
    /// If the corresponding component in the match vector is zero, the target vector component is set to zero
    /// </summary>
    /// <param name="dst">The target vector</param>
    /// <param name="match">The match vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vsign(Vector128<int> dst, Vector128<int> match)
        => Sign(dst, match);

    /// <summary>
    /// __m256i _mm256_sign_epi8 (__m256i a, __m256i b) VPSIGNB ymm, ymm, ymm/m256
    /// Negates target vector elements if the corresponding element in the match vector is negative;
    /// If the corresponding component in the match vector is zero, the target vector component is set to zero
    /// </summary>
    /// <param name="dst">The target vector</param>
    /// <param name="match">The match vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vsign(Vector256<sbyte> dst, Vector256<sbyte> match)
        => Sign(dst, match);

    /// <summary>
    /// __m256i _mm256_sign_epi16 (__m256i a, __m256i b) VPSIGNW ymm, ymm, ymm/m256
    /// Negates target vector elements if the corresponding element in the match vector is negative;
    /// If the corresponding component in the match vector is zero, the target vector component is set to zero
    /// </summary>
    /// <param name="dst">The target vector</param>
    /// <param name="match">The match vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vsign(Vector256<short> dst, Vector256<short> match)
        => Sign(dst, match);

    /// <summary>
    /// __m256i _mm256_sign_epi32 (__m256i a, __m256i b) VPSIGND ymm, ymm, ymm/m256
    /// Negates target vector elements if the corresponding element in the match vector is negative;
    /// If the corresponding component in the match vector is zero, the target vector component is set to zero
    /// </summary>
    /// <param name="dst">The target vector</param>
    /// <param name="match">The match vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vsign(Vector256<int> dst, Vector256<int> match)
        => Sign(dst, match);
}
