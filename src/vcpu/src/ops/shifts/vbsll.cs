//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vbsll(Vector128<sbyte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vbsll(Vector128<byte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vbsll(Vector128<short> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vbsll(Vector128<ushort> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vbsll(Vector128<int> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vbsll(Vector128<uint> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vbsll(Vector128<long> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vbsll(Vector128<ulong> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vbsll(Vector256<sbyte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vbsll(Vector256<byte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vbsll(Vector256<short> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vbsll(Vector256<ushort> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vbsll(Vector256<int> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vbsll(Vector256<uint> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vbsll(Vector256<long> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vbsll(Vector256<ulong> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);        

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vbsll(Vector512<byte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);        

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vbsll(Vector512<sbyte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);        

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vbsll(Vector512<ushort> x, [Imm] byte count)
        => v16u(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vbsll(Vector512<short> x, [Imm] byte count)
        => v16i(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vbsll(Vector512<int> x, [Imm] byte count)
        => v32i(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vbsll(Vector512<uint> x, [Imm] byte count)
        => v32u(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vbsll(Vector512<long> x, [Imm] byte count)
        => v64i(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vbsll(Vector512<ulong> x, [Imm] byte count)
        => v64u(ShiftLeftLogical128BitLane(v8u(x), count));
}
