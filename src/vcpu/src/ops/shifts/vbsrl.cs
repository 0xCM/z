//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// __m128i _mm_bsrli_si128 (__m128i a, int imm8) PSRLDQ xmm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vbsrl(Vector128<sbyte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m128i _mm_bsrli_si128 (__m128i a, int imm8) PSRLDQ xmm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vbsrl(Vector128<byte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m128i _mm_bsrli_si128 (__m128i a, int imm8) PSRLDQ xmm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vbsrl(Vector128<short> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m128i _mm_bsrli_si128 (__m128i a, int imm8) PSRLDQ xmm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vbsrl(Vector128<ushort> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m128i _mm_bsrli_si128 (__m128i a, int imm8) PSRLDQ xmm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vbsrl(Vector128<int> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m128i _mm_bsrli_si128 (__m128i a, int imm8) PSRLDQ xmm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vbsrl(Vector128<uint> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m128i _mm_bsrli_si128 (__m128i a, int imm8) PSRLDQ xmm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vbsrl(Vector128<long> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m128i _mm_bsrli_si128 (__m128i a, int imm8) PSRLDQ xmm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vbsrl(Vector128<ulong> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vbsrl(Vector256<sbyte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vbsrl(Vector256<byte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vbsrl(Vector256<short> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vbsrl(Vector256<ushort> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vbsrl(Vector256<int> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vbsrl(Vector256<uint> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vbsrl(Vector256<long> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m256i _mm256_bsrli_epi128 (__m256i a, const int imm8) VPSRLDQ ymm, ymm, imm8
    /// Shifts the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vbsrl(Vector256<ulong> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vbsrl(Vector512<sbyte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vbsrl(Vector512<byte> x, [Imm] byte count)
        => ShiftRightLogical128BitLane(x, (byte)count);

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vbsrl(Vector512<short> x, [Imm] byte count)
        => v16i(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vbsrl(Vector512<ushort> x, [Imm] byte count)
        => v16u(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vbsrl(Vector512<int> x, [Imm] byte count)
        => v32i(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vbsrl(Vector512<uint> x, [Imm] byte count)
        => v32u(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vbsrl(Vector512<long> x, [Imm] byte count)
        => v64i(ShiftRightLogical128BitLane(v8u(x), (byte)count));

    /// <summary>
    /// __m512i _mm512_bsrli_epi128 (__m512i a, const int imm8)
    /// VPSRLDQ zmm1, zmm2/m128, imm8
    /// Shifts each 128-bit lane of the source vector rightwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vbsrl(Vector512<ulong> x, [Imm] byte count)
        => v64u(ShiftRightLogical128BitLane(v8u(x), (byte)count));
}
