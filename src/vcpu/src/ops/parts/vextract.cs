//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// int _mm_extract_epi8 (__m128i a, const int imm8)
    /// PEXTRB reg/m8, xmm, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="index">The index of the cell to extract</param>
    [MethodImpl(Inline), Op]
    public static sbyte vextract(Vector128<sbyte> src, [Imm] byte index)
        => (sbyte)Extract(v8u(src), index);

    /// <summary>
    /// int _mm_extract_epi8 (__m128i a, const int imm8)
    /// PEXTRB reg/m8, xmm, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="index">The index of the cell to extract</param>
    [MethodImpl(Inline), Op]
    public static byte vextract(Vector128<byte> src, [Imm] byte index)
        => Extract(src, index);

    /// <summary>
    /// int _mm_extract_epi16 (__m128i a, int imm8)
    /// pextrw r32, xmm, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="index">The index of the cell to extract</param>
    [MethodImpl(Inline), Op]
    public static short vextract(Vector128<short> src, [Imm] byte index)
        => (short)Extract(v16u(src), index);

    /// <summary>
    /// int _mm_extract_epi16 (__m128i a, int imm8)
    /// pextrw r32, xmm, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="index">The index of the cell to extract</param>
    [MethodImpl(Inline), Op]
    public static ushort vextract(Vector128<ushort> src, [Imm] byte index)
        => Extract(src,(byte)index);

    /// <summary>
    /// int _mm_extract_epi32 (__m128i a, const int imm8)
    /// PEXTRD reg/m32, xmm, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="index">The index of the cell to extract</param>
    [MethodImpl(Inline), Op]
    public static uint vextract(Vector128<uint> src, [Imm] byte index)
        => Extract(src, index);

    /// <summary>
    /// int _mm_extract_epi32 (__m128i a, const int imm8)
    /// PEXTRD reg/m32, xmm, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="index">The index of the cell to extract</param>
    [MethodImpl(Inline), Op]
    public static int vextract(Vector128<int> src, [Imm] byte index)
        => Extract(src,index);

    [MethodImpl(Inline), Op]
    public static byte vextract(Vector256<byte> src, [Imm] byte index)
        => src.GetElement(index);

    [MethodImpl(Inline), Op]
    public static sbyte vextract(Vector256<sbyte> src, [Imm] byte index)
        => src.GetElement(index);

    [MethodImpl(Inline), Op]
    public static ushort vextract(Vector256<ushort> src, [Imm] byte index)
        => src.GetElement(index);

    [MethodImpl(Inline), Op]
    public static short vextract(Vector256<short> src, [Imm] byte index)
        => src.GetElement(index);

    [MethodImpl(Inline), Op]
    public static int vextract(Vector256<int> src, [Imm] byte index)
        => src.GetElement(index);

    [MethodImpl(Inline), Op]
    public static uint vextract(Vector256<uint> src, [Imm] byte index)
        => src.GetElement(index);

    [MethodImpl(Inline), Op]
    public static long vextract(Vector256<long> src, [Imm] byte index)
        => src.GetElement(index);

    [MethodImpl(Inline), Op]
    public static ulong vextract(Vector256<ulong> src, [Imm] byte index)
        => src.GetElement(index);

}
