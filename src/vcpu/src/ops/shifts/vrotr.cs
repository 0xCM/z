//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Rotates each component the source vector rightwards by a constant count
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static Vector128<byte> vrotr(Vector128<byte> src, [Imm] byte count)
        => vor(vsrl(src, count), vsll(src, (byte)(8 - count)));

    /// <summary>
    /// Rotates each component the source vector rightwards by a constant count
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static Vector128<ushort> vrotr(Vector128<ushort> src, [Imm] byte count)
        => vor(vsrl(src, count), vsll(src, (byte)(16 - count)));

    /// <summary>
    /// Rotates each component the source vector rightwards by a constant count
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static Vector128<uint> vrotr(Vector128<uint> src, [Imm] byte count)
        => vor(vsrl(src, count), vsll(src, (byte)(32 - count)));

    /// <summary>
    /// Rotates each component the source vector rightwards by a constant count
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static Vector128<ulong> vrotr(Vector128<ulong> src, [Imm] byte count)
        => vor(vsrl(src, count), vsll(src, (byte)(64 - count)));

    /// <summary>
    /// Rotates each component the source vector rightwards by a specified count
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static Vector256<byte> vrotr(Vector256<byte> src, [Imm] byte count)
        => vor(vsrl(src, count), vsll(src, (byte)(8 - count)));

    /// <summary>
    /// Rotates each component the source vector rightwards by a specified count
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static Vector256<ushort> vrotr(Vector256<ushort> src, [Imm] byte count)
        => vor(vsrl(src, count), vsll(src, (byte)(16 - count)));

    /// <summary>
    /// Rotates each component the source vector rightwards by a constant count
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static Vector256<uint> vrotr(Vector256<uint> src, [Imm] byte count)
        => vor(vsrl(src, count), vsll(src, (byte)(32 - count)));

    /// <summary>
    /// Rotates each component the source vector rightwards by a constant count
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static Vector256<ulong> vrotr(Vector256<ulong> src, [Imm] byte count)
        => vor(vsrl(src, count), vsll(src, (byte)(64 - count)));

    /// <summary>
    /// Rotates each component the source vector rightwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotrv]
    public static Vector128<uint> vrotr(Vector128<uint> src, Vector128<uint> counts)
        => vor(vsrlv(src, counts), vsllv(src, vsub(Vector128u32, counts)));

    /// <summary>
    /// Rotates each component the source vector rightwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotrv]
    public static Vector128<ulong> vrotr(Vector128<ulong> src, Vector128<ulong> counts)
        => vor(vsrlv(src, counts), vsllv(src, vsub(Vector128u64, counts)));

    /// <summary>
    /// Rotates each component the source vector rightwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotrv]
    public static Vector256<uint> vrotr(Vector256<uint> src, Vector256<uint> counts)
        => vor(vsrlv(src, counts), vsllv(src, vsub(Vector256u32, counts)));

    /// <summary>
    /// Rotates each component the source vector rightwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotrv]
    public static Vector256<ulong> vrotr(Vector256<ulong> src, Vector256<ulong> counts)
        => vor(vsrlv(src, counts), vsllv(src, vsub(Vector256u64, counts)));

    /// <summary>
    /// __m512i _mm512_rol_epi32 (__m512i a, int imm8)
    /// VPROLD zmm1 {k1}{z}, zmm2/m512/m32bcst, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vrotr(Vector512<uint> src, byte count)
        => RotateRight(src,count);

    /// <summary>
    /// __m512i _mm512_ror_epi32 (__m512i a, int imm8)
    /// VPRORD zmm1 {k1}{z}, zmm2/m512/m32bcst, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vrotr(Vector512<int> src, byte count)
        => RotateRight(src,count);

    /// <summary>
    /// __m512i _mm512_ror_epi64 (__m512i a, int imm8)
    /// VPRORQ zmm1 {k1}{z}, zmm2/m512/m64bcst, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vrotr(Vector512<long> src, byte count)
        => RotateRight(src,count);

    /// <summary>
    /// __m512i _mm512_ror_epi64 (__m512i a, int imm8)
    /// VPRORQ zmm1 {k1}{z}, zmm2/m512/m64bcst, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vrotr(Vector512<ulong> src, byte count)        
        => RotateRight(src,count);

    /// <summary>
    /// __m512i _mm512_rorv_epi32 (__m512i a, __m512i b)
    /// VPRORDV zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="counts"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vrotr(Vector512<int> src, Vector512<int> counts)
        => RotateRightVariable(src, v32u(counts));

    /// <summary>
    /// __m512i _mm512_rorv_epi32 (__m512i a, __m512i b)
    /// VPRORDV zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="counts"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vrotr(Vector512<uint> src, Vector512<uint> counts)
        => RotateRightVariable(src, counts);

    /// <summary>
    /// __m512i _mm512_rorv_epi64 (__m512i a, __m512i b)
    /// VPRORQV zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="counts"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vrotr(Vector512<long> src, Vector512<long> counts)
        => RotateRightVariable(src, v64u(counts));

    /// <summary>
    /// __m512i _mm512_rorv_epi64 (__m512i a, __m512i b)
    /// VPRORQV zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="counts"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vrotr(Vector512<ulong> src, Vector512<ulong> counts)
        => RotateRightVariable(src, counts);
}
