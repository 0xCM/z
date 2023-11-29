//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// int _mm_movemask_epi8 (__m128i a) PMOVMSKB reg, xmm
    /// Constructs an integer from the most significant bit of each source vector component
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), MoveMask]
    public static ushort vmovemask(Vector128<sbyte> src)
        => (ushort)MoveMask(src);

    /// <summary>
    /// int _mm_movemask_epi8 (__m128i a) PMOVMSKB reg, xmm
    /// Constructs an integer from the most significant bit of each source vector component
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), MoveMask]
    public static ushort vmovemask(Vector128<byte> src)
        => (ushort)MoveMask(src);

    /// <summary>
    /// int _mm256_movemask_epi8 (__m256i a) VPMOVMSKB reg, ymm
    /// Constructs an integer from the most significant bit of each 8-bit source vector segment
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), MoveMask]
    public static uint vmovemask(Vector256<sbyte> src)
        => (uint)MoveMask(src);

    /// <summary>
    /// int _mm256_movemask_epi8 (__m256i a)
    /// VPMOVMSKB reg, ymm
    /// Constructs an integer from the most significant bit of each 8-bit source vector segment
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), MoveMask]
    public static uint vmovemask(Vector256<byte> src)
        => (uint)MoveMask(src);

    /// <summary>
    /// int _mm256_movemask_epi8 (__m256i a) VPMOVMSKB reg, ymm
    /// Constructs an integer from the most significant bit of each 8-bit source vector segment
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), MoveMask]
    public static uint vmovemask(Vector256<ulong> src)
        => (uint)MoveMask(v8u(src));

    /// <summary>
    /// Creates a 32-bit mask from each byte at a byte-relative bit index
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="index">An integer between 0 and 7</param>
    [MethodImpl(Inline), MoveMask]
    public static ushort vmovemask(Vector128<byte> src, [Imm] byte index)
        => vmovemask(v8u(vsll(v64u(src), (byte)(7 - index))));

    /// <summary>
    /// Creates a 32-bit mask from each byte at a byte-relative bit index
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="index">An integer between 0 and 7</param>
    [MethodImpl(Inline), MoveMask]
    public static uint vmovemask(Vector256<byte> src, [Imm] byte index)
        => vmovemask(v8u(vsll(v64u(src), (byte)(7 - index))));

    [MethodImpl(Inline), MoveMask]
    public static ushort vmovemask(Vector128<byte> src, byte offset, [Imm] byte index)
        => vmovemask(vsllx(src, offset), index);

    [MethodImpl(Inline), MoveMask]
    public static uint vmovemask(Vector256<byte> src, [Imm] byte offset, [Imm] byte index)
        => vmovemask(vsllx(src, offset), index);
}
