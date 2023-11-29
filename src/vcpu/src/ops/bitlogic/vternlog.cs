//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial class vcpu 
{
    /// <summary>
    /// __m128i _mm_ternarylogic_si128 (__m128i a, __m128i b, __m128i c, byte imm)
    ///   VPTERNLOGD xmm1 {k1}{z}, xmm2, xmm3/m128, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vternlog(Vector128<byte> x, Vector128<byte> y, Vector128<byte> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m128i _mm_ternarylogic_si128 (__m128i a, __m128i b, __m128i c, byte imm)
    ///   VPTERNLOGD xmm1 {k1}{z}, xmm2, xmm3/m128, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vternlog(Vector128<sbyte> x, Vector128<sbyte> y, Vector128<sbyte> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m128i _mm_ternarylogic_si128 (__m128i a, __m128i b, __m128i c, byte imm)
    ///   VPTERNLOGD xmm1 {k1}{z}, xmm2, xmm3/m128, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vternlog(Vector128<short> x, Vector128<short> y, Vector128<short> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m128i _mm_ternarylogic_si128 (__m128i a, __m128i b, __m128i c, byte imm)
    ///   VPTERNLOGD xmm1 {k1}{z}, xmm2, xmm3/m128, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vternlog(Vector128<ushort> x, Vector128<ushort> y, Vector128<ushort> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m128i _mm_ternarylogic_epi32 (__m128i a, __m128i b, __m128i c, int imm)
    ///   VPTERNLOGD xmm1 {k1}{z}, xmm2, xmm3/m128/m32bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vternlog(Vector128<int> x, Vector128<int> y, Vector128<int> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m128i _mm_ternarylogic_epi32 (__m128i a, __m128i b, __m128i c, int imm)
    ///   VPTERNLOGD xmm1 {k1}{z}, xmm2, xmm3/m128/m32bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vternlog(Vector128<uint> x, Vector128<uint> y, Vector128<uint> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m128i _mm_ternarylogic_epi64 (__m128i a, __m128i b, __m128i c, int imm)
    ///   VPTERNLOGQ xmm1 {k1}{z}, xmm2, xmm3/m128/m64bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vternlog(Vector128<long> x, Vector128<long> y, Vector128<long> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m128i _mm_ternarylogic_epi64 (__m128i a, __m128i b, __m128i c, int imm)
    ///   VPTERNLOGQ xmm1 {k1}{z}, xmm2, xmm3/m128/m64bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vternlog(Vector128<ulong> x, Vector128<ulong> y, Vector128<ulong> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m256i _mm256_ternarylogic_si256 (__m256i a, __m256i b, __m256i c, byte imm)
    ///   VPTERNLOGD ymm1 {k1}{z}, ymm2, ymm3/m256, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vternlog(Vector256<byte> x, Vector256<byte> y, Vector256<byte> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m256i _mm256_ternarylogic_si256 (__m256i a, __m256i b, __m256i c, byte imm)
    ///   VPTERNLOGD ymm1 {k1}{z}, ymm2, ymm3/m256, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vternlog(Vector256<sbyte> x, Vector256<sbyte> y, Vector256<sbyte> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m256i _mm256_ternarylogic_si256 (__m256i a, __m256i b, __m256i c, byte imm)
    ///   VPTERNLOGD ymm1 {k1}{z}, ymm2, ymm3/m256, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vternlog(Vector256<short> x, Vector256<short> y, Vector256<short> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m256i _mm256_ternarylogic_si256 (__m256i a, __m256i b, __m256i c, byte imm)
    ///   VPTERNLOGD ymm1 {k1}{z}, ymm2, ymm3/m256, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vternlog(Vector256<ushort> x, Vector256<ushort> y, Vector256<ushort> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m256i _mm256_ternarylogic_epi32 (__m256i a, __m256i b, __m256i c, int imm)
    ///   VPTERNLOGD ymm1 {k1}{z}, ymm2, ymm3/m256/m32bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vternlog(Vector256<int> x, Vector256<int> y, Vector256<int> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m256i _mm256_ternarylogic_epi32 (__m256i a, __m256i b, __m256i c, int imm)
    ///   VPTERNLOGD ymm1 {k1}{z}, ymm2, ymm3/m256/m32bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vternlog(Vector256<uint> x, Vector256<uint> y, Vector256<uint> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m256i _mm256_ternarylogic_epi64 (__m256i a, __m256i b, __m256i c, int imm)
    ///   VPTERNLOGQ ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vternlog(Vector256<long> x, Vector256<long> y, Vector256<long> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m256i _mm256_ternarylogic_epi64 (__m256i a, __m256i b, __m256i c, int imm)
    ///   VPTERNLOGQ ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vternlog(Vector256<ulong> x, Vector256<ulong> y, Vector256<ulong> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m512i _mm512_ternarylogic_si512 (__m512i a, __m512i b, __m512i c, int imm)
    ///   VPTERNLOGD zmm1 {k1}{z}, zmm2, zmm3/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vternlog(Vector512<byte> x, Vector512<byte> y, Vector512<byte> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m512i _mm512_ternarylogic_si512 (__m512i a, __m512i b, __m512i c, int imm)
    ///   VPTERNLOGD zmm1 {k1}{z}, zmm2, zmm3/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vternlog(Vector512<sbyte> x, Vector512<sbyte> y, Vector512<sbyte> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m512i _mm512_ternarylogic_si512 (__m512i a, __m512i b, __m512i c, int imm)
    ///   VPTERNLOGD zmm1 {k1}{z}, zmm2, zmm3/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vternlog(Vector512<short> x, Vector512<short> y, Vector512<short> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m512i _mm512_ternarylogic_si512 (__m512i a, __m512i b, __m512i c, int imm)
    ///   VPTERNLOGD zmm1 {k1}{z}, zmm2, zmm3/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vternlog(Vector512<ushort> x, Vector512<ushort> y, Vector512<ushort> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m512i _mm512_ternarylogic_epi32 (__m512i a, __m512i b, __m512i c, int imm)
    ///   VPTERNLOGD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vternlog(Vector512<int> x, Vector512<int> y, Vector512<int> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m512i _mm512_ternarylogic_epi32 (__m512i a, __m512i b, __m512i c, int imm)
    ///   VPTERNLOGD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vternlog(Vector512<uint> x, Vector512<uint> y, Vector512<uint> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m512i _mm512_ternarylogic_epi64 (__m512i a, __m512i b, __m512i c, int imm)
    ///   VPTERNLOGQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vternlog(Vector512<long> x, Vector512<long> y, Vector512<long> z, byte spec)
        => TernaryLogic(x, y, z, spec);

    /// <summary>
    /// __m512i _mm512_ternarylogic_epi64 (__m512i a, __m512i b, __m512i c, int imm)
    ///   VPTERNLOGQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vternlog(Vector512<ulong> x, Vector512<ulong> y, Vector512<ulong> z, byte spec)
        => TernaryLogic(x, y, z, spec);        
}