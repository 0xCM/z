//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class vcpu
{
    /// <summary>
    /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
    /// Conditionally stores 8-bit source vector segments to memory according to a specified mask
    /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
    /// If the hi bit is enabled, content is written, otherwise it is not
    /// </summary>
    /// <param name="src"></param>
    /// <param name="mask"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskmove(Vector128<byte> src, Vector128<byte> mask, ref byte dst)
        => MaskMove(src, mask, refptr(ref dst));

    /// <summary>
    /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <param name="mask"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskmove(Vector128<sbyte> src, Vector128<byte> mask, ref byte dst)
        => MaskMove(v8u(src), v8u(mask), refptr(ref dst));

    /// <summary>
    /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <param name="mask"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskmove(Vector128<short> src, Vector128<byte> mask, ref byte dst)
        => MaskMove(v8u(src), mask, refptr(ref dst));

    /// <summary>
    /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <param name="mask"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskmove(Vector128<ushort> src, Vector128<byte> mask, ref byte dst)
        => MaskMove(v8u(src), mask, refptr(ref dst));

    /// <summary>
    /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <param name="mask"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskmove(Vector128<int> src, Vector128<byte> mask, ref byte dst)
        => MaskMove(v8u(src), mask, refptr(ref dst));

    /// <summary>
    /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <param name="mask"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskmove(Vector128<uint> src, Vector128<byte> mask, ref byte dst)
        => MaskMove(v8u(src), mask, refptr(ref dst));

    /// <summary>
    /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <param name="mask"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskmove(Vector128<long> src, Vector128<byte> mask, ref byte dst)
        => MaskMove(v8u(src), mask, refptr(ref dst));

    /// <summary>
    /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
    /// </summary>
    /// <param name="src"></param>
    /// <param name="mask"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskmove(Vector128<ulong> src, Vector128<byte> mask, ref byte dst)
        => MaskMove(v8u(src), mask, refptr(ref dst));
}
