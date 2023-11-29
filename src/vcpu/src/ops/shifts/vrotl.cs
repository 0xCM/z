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
    public static Vector128<byte> vrotl(Vector128<byte> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(8 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector128<ushort> vrotl(Vector128<ushort> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(16 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector128<uint> vrotl(Vector128<uint> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(32-count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector128<ulong> vrotl(Vector128<ulong> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(64 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector256<byte> vrotl(Vector256<byte> src, [Imm] byte count)
        => vor(vsll(src, count),vsrl(src, (byte)(8 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector256<ushort> vrotl(Vector256<ushort> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(16 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector256<uint> vrotl(Vector256<uint> src, [Imm] byte count)
        => vor(vsll(src, count),vsrl(src, (byte)(32 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by a specified bitcount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static Vector256<ulong> vrotl(Vector256<ulong> src, [Imm] byte count)
        => vor(vsll(src, count), vsrl(src, (byte)(64 - count)));

    /// <summary>
    /// Rotates each component the source vector leftwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotlv]
    public static Vector128<uint> vrotl(Vector128<uint> src, Vector128<uint> counts)
        => vor(vsllv(src, counts), vsrlv(src, vsub(Vector128u32, counts)));

    /// <summary>
    /// Rotates each component the source vector leftwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotlv]
    public static Vector128<ulong> vrotl(Vector128<ulong> src, Vector128<ulong> counts)
        => vor(vsllv(src,counts), vsrlv(src, vsub(Vector128u64,counts)));

    /// <summary>
    /// Rotates each component the source vector leftwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotlv]
    public static Vector256<uint> vrotl(Vector256<uint> src, Vector256<uint> counts)
        => vor(vsllv(src,counts), vsrlv(src, vsub(Vector256u32,counts)));

    /// <summary>
    /// Rotates each component the source vector leftwards by the corresponding component in the shift spec
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="counts">The variable shift spec</param>
    [MethodImpl(Inline), Rotlv]
    public static Vector256<ulong> vrotl(Vector256<ulong> src, Vector256<ulong> counts)
        => vor(vsllv(src,counts), vsrlv(src,  vsub(Vector256u64,counts)));
}
