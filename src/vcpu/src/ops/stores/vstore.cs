//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class vcpu
{
    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<sbyte> src, ref sbyte dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<byte> src, ref byte dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<short> src, ref short dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<ushort> src, ref ushort dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<int> src, ref int dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<uint> src, ref uint dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<long> src, ref long dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<ulong> src, ref ulong dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<sbyte> src, ref sbyte dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<byte> src, ref byte dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<short> src, ref short dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<ushort> src, ref ushort dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<int> src, ref int dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    ///<intrinsic>void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<uint> src, ref uint dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    ///<intrinsic>void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<long> src, ref long dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    ///<intrinsic>void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<ulong> src, ref ulong dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm512_storeu_epi8 (__m512i * mem_addr, __m512i a)
    /// VMOVDQU8 m512 {k1}{z}, zmm1
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<byte> src, ref byte dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm512_storeu_epi8 (__m512i * mem_addr, __m512i a)
    /// VMOVDQU8 m512 {k1}{z}, zmm1
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<sbyte> src, ref sbyte dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm512_storeu_epi16 (__m512i * mem_addr, __m512i a)
    /// VMOVDQU16 m512 {k1}{z}, zmm1
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<short> src, ref short dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm512_storeu_epi16 (__m512i * mem_addr, __m512i a)
    /// VMOVDQU16 m512 {k1}{z}, zmm1
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<ushort> src, ref ushort dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm512_storeu_epi32 (__m512i * mem_addr, __m512i a)
    /// VMOVDQU32 m512 {k1}{z}, zmm1
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<uint> src, ref uint dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm512_storeu_epi32 (__m512i * mem_addr, __m512i a)
    /// VMOVDQU32 m512 {k1}{z}, zmm1
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<int> src, ref int dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm512_storeu_epi64 (__m512i * mem_addr, __m512i a)
    /// VMOVDQU64 m512 {k1}{z}, zmm1
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<long> src, ref long dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm512_storeu_epi64 (__m512i * mem_addr, __m512i a)
    /// VMOVDQU64 m512 {k1}{z}, zmm1
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<ulong> src, ref ulong dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<sbyte> src, ref sbyte dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    /// <intrinsic>void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<byte> src, ref byte dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    /// <intrinsic>void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<short> src, ref short dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<ushort> src, ref ushort dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<int> src, ref int dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<uint> src, ref uint dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vsave(Vector128<long> src, ref long dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm_storeu_si128 (__m128i* mem_addr, __m128i a) MOVDQU m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<ulong> src, ref ulong dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vsave(Vector256<sbyte> src, ref sbyte dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<byte> src, ref byte dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<short> src, ref short dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<ushort> src, ref ushort dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<int> src, ref int dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<uint> src, ref uint dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<long> src, ref long dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a) MOVDQU m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<ulong> src, ref ulong dst, int offset)
        => Store(refptr(ref dst, offset), src);

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<byte> src, Span<byte> dst)
        => vstore(src, ref first(dst));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<byte> src, Span<byte> dst)
        => vstore(src, ref first(dst));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<byte> src, Span<byte> dst)
        => vstore(src, ref first(dst));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<sbyte> src, Span<byte> dst)
        => vstore(src, ref first(recover<sbyte>(dst)));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<short> src, Span<byte> dst)
        => vstore(src, ref first(recover<short>(dst)));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<ushort> src, Span<byte> dst)
        => vstore(src, ref first(recover<ushort>(dst)));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<uint> src, Span<byte> dst)
        => vstore(src, ref first(recover<uint>(dst)));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<uint> src, Span<uint> dst)
        => vstore(src, ref first(dst));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<long> src, Span<byte> dst)
        => vstore(src, ref first(recover<long>(dst)));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<ulong> src, Span<byte> dst)
        => vstore(src, ref first(recover<ulong>(dst)));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<byte> src, uint offset, Span<byte> dst)
        => vstore(src, ref seek(dst,offset));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<byte> src, uint offset, Span<byte> dst)
        => vstore(src, ref seek(dst,offset));

    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector512<byte> src, uint offset, Span<byte> dst)
        => vstore(src, ref seek(dst,offset));
}
