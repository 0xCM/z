//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_shuffle_epi32 (__m128i a, int immediate) PSHUFD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vshuffle(Vector128<int> src, [Imm] byte spec)
        => Shuffle(src, spec);

    /// <summary>
    /// __m128i _mm_shuffle_epi32 (__m128i a, int immediate) PSHUFD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vshuffle(Vector128<uint> src, [Imm] byte spec)
        => Shuffle(src, (byte)spec);

    ///<summary>
    /// __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8) VPSHUFD ymm, ymm/m256, imm8
    /// shuffles 32-bit integers in the source vector within 128-bit lanes
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vhuffle(Vector256<uint> src, [Imm] byte spec)
        => Shuffle(src, (byte)spec);

    /// <summary>
    /// __m128i _mm_shuffle_epi32 (__m128i a, int immediate)
    /// PSHUFD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vshuffle(Vector128<uint> src, [Imm] Perm4L spec)
        => Shuffle(src, (byte)spec);

    /// <summary>
    /// __m128i _mm_shuffle_epi32 (__m128i a, int immediate) PSHUFD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vshuffle(Vector128<int> src, [Imm] Perm4L spec)
        => Shuffle(src, (byte)spec);

    ///<summary>
    /// __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
    /// VPSHUFD ymm, ymm/m256, imm8
    /// shuffles signed 32-bit integers in the source vector within 128-bit lanes
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vshuffle(Vector256<int> src, [Imm] Perm4L spec)
        => Shuffle(src, (byte)spec);

    ///<summary>
    /// __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
    /// VPSHUFD ymm, ymm/m256, imm8
    /// Shuffles 32-bit source segments within 128-bit lanes
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vshuffle(Vector256<uint> src, [Imm] Perm4L spec)
        => Shuffle(src, (byte)spec);

    /// <summary>
    /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b)
    /// PSHUFB xmm, xmm/m128
    /// For each component of the shuffle spec:
    /// testbit(spec[i],7) == 1 => dst[i] = 0
    /// testbit(spec[i],7) == 0 => dst[i] = src[i]
    /// spec[i] = j := 0 | 1 | ... | 15 => dst[j] = src[i]
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vshuffle(Vector128<byte> src, Vector128<byte> spec)
        => Shuffle(src, spec);

    ///<summary>
    /// __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8) VPSHUFD ymm, ymm/m256, imm8
    /// shuffles 32-bit integers in the source vector within 128-bit lanes
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vshuffle(Vector256<uint> src, [Imm] byte spec)
        => Shuffle(src, (byte)spec);

    /// <summary>
    /// __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)VPSHUFD ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The shuffle spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vshuffle(Vector256<int> src, [Imm] byte spec)
        => Shuffle(src, spec);

    /// <summary>
    /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b)
    /// PSHUFB xmm, xmm/m128
    ///</summary>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vshuffle(Vector128<sbyte> src, Vector128<sbyte> spec)
        => Shuffle(src, spec);

    ///<summary>
    /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
    /// VPSHUFB ymm, ymm, ymm/m256
    ///</summary>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vshuffle(Vector256<byte> src, Vector256<byte> spec)
        => Shuffle(src, spec);

    ///<summary>
    /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
    /// VPSHUFB ymm, ymm, ymm/m256
    ///</summary>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vshuffle(Vector256<sbyte> src, Vector256<sbyte> spec)
        => Shuffle(src, spec);

    /// <summary>
    /// __m512i _mm512_shuffle_epi8 (__m512i a, __m512i b)
    /// VPSHUFB zmm1 {k1}{z}, zmm2, zmm3/m512
    /// Shuffle packed 8-bit integers in a according to shuffle control mask in the corresponding 8-bit element of b, and store the results in dst
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vshuffle(Vector512<byte> src, Vector512<byte> spec)
        => Shuffle(src, spec);

    /// <summary>
    /// __m512i _mm512_shuffle_epi8 (__m512i a, __m512i b)
    ///  VPSHUFB zmm1 {k1}{z}, zmm2, zmm3/m512
    ///  Shuffle packed 8-bit integers in a according to shuffle control mask in the corresponding 8-bit element of b, and store the results in dst
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vshuffle(Vector512<sbyte> src, Vector512<sbyte> spec)
        => Shuffle(src, spec);

    /// <summary>
    /// __m512i _mm512_shuffle_epi32 (__m512i a, const int imm8)
    /// VPSHUFD zmm1 {k1}{z}, zmm2/m512/m32bcst, imm8
    /// Shuffle 32-bit integers in a within 128-bit lanes using the control in imm8, and store the results in dst.
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vshuffle(Vector512<uint> src, [Imm] Perm4x4 spec)
        => Shuffle(src, (byte)spec);

    /// <summary>
    /// __m512i _mm512_shuffle_epi32 (__m512i a, const int imm8)
    /// VPSHUFD zmm1 {k1}{z}, zmm2/m512/m32bcst, imm8
    /// Shuffle 32-bit integers in a within 128-bit lanes using the control in imm8, and store the results in dst.
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vshuffle4x128(Vector512<int> src, [Imm] Perm4x4 spec)
        => Shuffle(src, (byte)spec);

    /// <summary>
    /// __m512i _mm512_shuffle_i32x4 (__m512i a, __m512i b, const int imm8)
    /// VSHUFI32x4 zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst, imm8
    /// Shuffle 128-bits (composed of 4 32-bit integers) selected by "imm8" from "a" and "b", and store the results in "dst".
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vshuffle4x128(Vector512<uint> a, Vector512<uint> b, [Imm] byte spec)
        => Shuffle4x128(a, b, spec);

    /// <summary>
    /// __m512i _mm512_shuffle_i64x2 (__m512i a, __m512i b, const int imm8)
    /// VSHUFI64x2 zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst, imm8
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vshuffle4x128(Vector512<ulong> a, Vector512<ulong> b, [Imm] byte spec)
        => Shuffle4x128(a, b, spec);
}
