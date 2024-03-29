//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static LimitValues;

partial class vcpu 
{
    /// <summary>
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector128<byte> vsrl(Vector128<byte> src, [Imm] byte count)
    {
        var y = v8u(ShiftRightLogical(v64u(src), count));
        var m = vlsb<byte>(n128, n8, (byte)(8 - count));
        return vand(y,m);
    }

    /// <summary>
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector128<sbyte> vsrl(Vector128<sbyte> src, [Imm] byte count)
    {
        var x = v16u(ShiftRightLogical(vmovsxbw(w256, src),count));
        var y = vand(x, v16u(vbroadcast(w256, byte.MaxValue)));
        return v8i(vpack.vpack128x8u(y));
    }

    /// <summary>
    /// __m128i _mm_srli_epi16 (__m128i a, int immediate) PSRLW xmm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector128<short> vsrl(Vector128<short> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    ///  __m128i _mm_srli_epi16 (__m128i a, int immediate) PSRLW xmm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector128<ushort> vsrl(Vector128<ushort> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m128i _mm_srli_epi32 (__m128i a, int immediate) PSRLD xmm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector128<int> vsrl(Vector128<int> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m128i _mm_srli_epi32 (__m128i a, int immediate) PSRLD xmm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector128<uint> vsrl(Vector128<uint> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m128i _mm_srli_epi64 (__m128i a, int immediate) PSRLQ xmm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector128<long> vsrl(Vector128<long> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m128i _mm_srli_epi64 (__m128i a, int immediate) PSRLQ xmm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector128<ulong> vsrl(Vector128<ulong> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m512i _mm512_srli_epi16 (__m512i a, int imm8)
    /// VPSRLW zmm1 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Srl]
    public static Vector512<ushort> vsrl(Vector512<ushort> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m512i _mm512_srli_epi16 (__m512i a, int imm8)
    /// VPSRLW zmm1 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Srl]
    public static Vector512<short> vsrl(Vector512<short> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m512i _mm512_srli_epi32 (__m512i a, int imm8)
    /// VPSRLD zmm1 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Srl]
    public static Vector512<int> vsrl(Vector512<int> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m512i _mm512_srli_epi32 (__m512i a, int imm8)
    /// VPSRLD zmm1 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Srl]
    public static Vector512<uint> vsrl(Vector512<uint> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m512i _mm512_srli_epi64 (__m512i a, int imm8)
    /// VPSRLQ zmm1 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Srl]
    public static Vector512<long> vsrl(Vector512<long> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m512i _mm512_srli_epi64 (__m512i a, int imm8)
    /// VPSRLQ zmm1 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Srl]
    public static Vector512<ulong> vsrl(Vector512<ulong> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector256<sbyte> vsrl(Vector256<sbyte> src, [Imm] byte count)
    {
        var x = v16u(ShiftRightLogical(vmovsxbw(w256, vlo(src)),count));
        var y = v16u(ShiftRightLogical(vmovsxbw(w256, vhi(src)),count));
        var m = v16u(vbroadcast(w256, byte.MaxValue));
        return v8i(vpack.vpack256x8u(vand(x,m), vand(y,m)));
    }

    /// <summary>
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector256<byte> vsrl(Vector256<byte> src, [Imm] byte count)
    {
        var y = v8u(ShiftRightLogical(v64u(src), count));
        var m = vlsb<byte>(w256, n8, (byte)(8 - count));
        return vand(y,m);
    }

    /// <summary>
    /// __m256i _mm256_srli_epi16 (__m256i a, int imm8) VPSRLW ymm, ymm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector256<short> vsrl(Vector256<short> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m256i _mm256_srli_epi16 (__m256i a, int imm8) VPSRLW ymm, ymm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector256<ushort> vsrl(Vector256<ushort> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m256i _mm256_srli_epi32 (__m256i a, int imm8) VPSRLD ymm, ymm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector256<int> vsrl(Vector256<int> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m256i _mm256_srli_epi32 (__m256i a, int imm8) VPSRLD ymm, ymm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector256<uint> vsrl(Vector256<uint> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m256i _mm256_srli_epi64 (__m256i a, int imm8) VPSRLQ ymm, ymm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector256<long> vsrl(Vector256<long> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    /// <summary>
    /// __m256i _mm256_srli_epi64 (__m256i a, int imm8) VPSRLQ ymm, ymm, imm8
    /// Shifts each each component rightward by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The bitcount</param>
    [MethodImpl(Inline), Srl]
    public static Vector256<ulong> vsrl(Vector256<ulong> src, [Imm] byte count)
        => ShiftRightLogical(src, count);

    [MethodImpl(Inline), Op]
    public static Vector512<byte> vsrl(Vector512<byte> src, [Imm] byte count)
    {
        var a = v8u(ShiftRightLogical(v64u(src), count));
        var b = vlsb<byte>(w512, n8, (byte)(8 - count));
        return vand(a,b);
    }

    [MethodImpl(Inline),Op]
    static byte lsb8f(byte density)
        => (byte)(Max8u >> (8 - density));

    /// <summary>
    /// The f least significant bits of each 8 bit segment are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">A value in the range [2,7] that defines the bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    static Vector128<T> vlsb<T>(W128 w, N8 f, byte d)
        where T : unmanaged
            => generic<T>(vgcpu.vbroadcast<byte>(w, lsb8f(d)));

    /// <summary>
    /// The f least significant bits of each 8 bit segment are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">A value in the range [2,7] that defines the bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    static Vector256<T> vlsb<T>(W256 w, N8 f, byte d)
        where T : unmanaged
            => generic<T>(vgcpu.vbroadcast<byte>(w, lsb8f(d)));

    /// <summary>
    /// The f least significant bits of each 8 bit segment are enabled
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="f">The repetition frequency</param>
    /// <param name="d">A value in the range [2,7] that defines the bit density</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline)]
    static Vector512<T> vlsb<T>(W512 w, N8 f, byte d)
        where T : unmanaged
            => generic<T>(vgcpu.vbroadcast(w, lsb8f(d)));            
}
