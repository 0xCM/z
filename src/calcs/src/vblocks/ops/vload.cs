//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Sse3;

    using static sys;

    partial struct vblocks
    {
        /// <summary>
        /// _m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<byte> vload(in SpanBlock128<byte> src, int block)
            => LoadDquVector128(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<sbyte> vload(in SpanBlock128<sbyte> src, int block)
            => LoadDquVector128(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<short> vload(in SpanBlock128<short> src, int block)
            => LoadDquVector128(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ushort> vload(in SpanBlock128<ushort> src, int block)
            => LoadDquVector128(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<int> vload(in SpanBlock128<int> src, int block)
            => LoadDquVector128(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vload(in SpanBlock128<uint> src, int block)
            => LoadDquVector128(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<long> vload(in SpanBlock128<long> src, int block)
            => LoadDquVector128(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// Loads a 128-bit cpu vector from an unaligned memory location
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ulong> vload(in SpanBlock128<ulong> src, int block)
            => LoadDquVector128(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<byte> vload(in SpanBlock256<byte> src, int block)
            => LoadDquVector256(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<sbyte> vload(in SpanBlock256<sbyte> src, int block)
            => LoadDquVector256(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<short> vload(in SpanBlock256<short> src, int block)
            => LoadDquVector256(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ushort> vload(in SpanBlock256<ushort> src, int block)
            => LoadDquVector256(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<int> vload(in SpanBlock256<int> src, int block)
            => LoadDquVector256(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vload(in SpanBlock256<uint> src, int block)
            => LoadDquVector256(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<long> vload(in SpanBlock256<long> src, int block)
            => LoadDquVector256(gptr(src.BlockLead(block)));

        /// <summary>
        /// __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// Loads a 256-bit cpu vector from the leading block of a blocked container
        /// </summary>
        /// <param name="src">A readonly blocked storage container</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vload(in SpanBlock256<ulong> src, int block)
            => LoadDquVector256(gptr(src.BlockLead(block)));
    }
}