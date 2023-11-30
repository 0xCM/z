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
    public static Vector128<sbyte> vsll128(Vector128<sbyte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vsll128(Vector128<byte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vsll128(Vector128<short> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vsll128(Vector128<ushort> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vsll128(Vector128<int> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vsll128(Vector128<uint> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vsll128(Vector128<long> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);

    /// <summary>
    ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
    /// Shifts the source vector leftwards with byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vsll128(Vector128<ulong> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);
}