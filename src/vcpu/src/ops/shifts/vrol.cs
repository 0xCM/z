//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector128<byte> vrol(Vector128<byte> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(8 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector128<ushort> vrol(Vector128<ushort> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(16 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector128<uint> vrol(Vector128<uint> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(32-count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector128<ulong> vrol(Vector128<ulong> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(64 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector256<byte> vrol(Vector256<byte> src, [Imm] byte count)
        => vor(vsll(src, count),vsrl(src, (byte)(8 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector256<ushort> vrol(Vector256<ushort> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(16 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector256<uint> vrol(Vector256<uint> src, [Imm] byte count)
        => vor(vsll(src, count),vsrl(src, (byte)(32 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector256<ulong> vrol(Vector256<ulong> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(64 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotlv]
    public static Vector128<uint> vrol(Vector128<uint> src, Vector128<uint> counts)
        => vor(vsllv(src, counts), vsrlv(src, vsub(Vector128u32, counts)));

    /// <summary>
    /// Rotates each component the source vector leftwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotlv]
    public static Vector128<ulong> vrol(Vector128<ulong> src, Vector128<ulong> counts)
        => vor(vsllv(src,counts), vsrlv(src, vsub(Vector128u64,counts)));

    /// <summary>
    /// Rotates each component the source vector leftwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotlv]
    public static Vector256<uint> vrol(Vector256<uint> src, Vector256<uint> counts)
        => vor(vsllv(src,counts), vsrlv(src, vsub(Vector256u32,counts)));

    /// <summary>
    /// Rotates each component the source vector leftwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotlv]
    public static Vector256<ulong> vrol(Vector256<ulong> src, Vector256<ulong> counts)
        => vor(vsllv(src,counts), vsrlv(src,  vsub(Vector256u64,counts)));

    /// <summary>
    /// __m512i _mm512_rol_epi32 (__m512i a, int imm8)
    /// VPROLD zmm1 {k1}{z}, zmm2/m512/m32bcst, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Rotlv]
    public static Vector512<uint> vrol(Vector512<uint> src, byte count)
        => RotateLeft(src,count);

    /// <summary>
    /// __m512i _mm512_rol_epi32 (__m512i a, int imm8)
    /// VPROLD zmm1 {k1}{z}, zmm2/m512/m32bcst, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Rotlv]
    public static Vector512<int> vrol(Vector512<int> src, byte count)
        => RotateLeft(src,count);

    /// <summary>
    /// __m512i _mm512_rol_epi64 (__m512i a, int imm8)
    /// VPROLQ zmm1 {k1}{z}, zmm2/m512/m64bcst, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Rotlv]
    public static Vector512<long> vrol(Vector512<long> src, byte count)
        => RotateLeft(src,count);

    /// <summary>
    /// __m512i _mm512_rol_epi64 (__m512i a, int imm8)
    /// VPROLQ zmm1 {k1}{z}, zmm2/m512/m64bcst, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Rotlv]
    public static Vector512<ulong> vrol(Vector512<ulong> src, byte count)        
        => RotateLeft(src,count);

    /// <summary>
    /// __m512i _mm512_rolv_epi32 (__m512i a, __m512i b)
    /// VPROLDV zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="counts"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vrol(Vector512<int> src, Vector512<int> counts)
        => RotateLeftVariable(src, v32u(counts));

    /// <summary>
    /// __m512i _mm512_rolv_epi32 (__m512i a, __m512i b)
    /// VPROLDV zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="counts"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vrol(Vector512<uint> src, Vector512<uint> counts)
        => RotateLeftVariable(src, counts);

    /// <summary>
    /// __m512i _mm512_rolv_epi64 (__m512i a, __m512i b)
    /// VPROLQV zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="counts"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vrol(Vector512<long> src, Vector512<long> counts)
        => RotateLeftVariable(src, v64u(counts));

    /// <summary>
    /// __m512i _mm512_rolv_epi64 (__m512i a, __m512i b)
    /// VPROLQV zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="counts"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vrol(Vector512<ulong> src, Vector512<ulong> counts)
        => RotateLeftVariable(src, counts);
}
