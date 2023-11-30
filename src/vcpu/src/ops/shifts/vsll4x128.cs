//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vsll4x128(Vector512<byte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);        

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vsll4x128(Vector512<sbyte> x, [Imm] byte count)
        => ShiftLeftLogical128BitLane(x, count);        

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vsll4x128(Vector512<ushort> x, [Imm] byte count)
        => v16u(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vsll4x128(Vector512<short> x, [Imm] byte count)
        => v16i(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vsll4x128(Vector512<int> x, [Imm] byte count)
        => v32i(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vsll4x128(Vector512<uint> x, [Imm] byte count)
        => v32u(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vsll4x128(Vector512<long> x, [Imm] byte count)
        => v64i(ShiftLeftLogical128BitLane(v8u(x), count));

    /// <summary>
    /// __m512i _mm512_bslli_epi128 (__m512i a, const int imm8)
    /// VPSLLDQ zmm1, zmm2/m512, imm8
    /// </summary>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vsll4x128(Vector512<ulong> x, [Imm] byte count)
        => v64u(ShiftLeftLogical128BitLane(v8u(x), count));
}
