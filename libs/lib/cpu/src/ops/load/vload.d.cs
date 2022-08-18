//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse3;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static core;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<sbyte> vload(W128 w, in sbyte src)
            => LoadDquVector128(gptr(src));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<byte> vload(W128 w, in byte src)
            => LoadDquVector128(gptr(src));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<short> vload(W128 w, in short src)
            => LoadDquVector128(gptr(src));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ushort> vload(W128 w, in ushort src)
            => LoadDquVector128(gptr(src));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<int> vload(W128 w, in int src)
            => LoadDquVector128(gptr(src));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vload(W128 w, in uint src)
            => LoadDquVector128(gptr(src));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<long> vload(W128 w, in long src)
            => LoadDquVector128(gptr(src));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ulong> vload(W128 w, in ulong src)
            => LoadDquVector128(gptr(src));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<sbyte> vload(W128 w, ReadOnlySpan<sbyte> src)
            => LoadDquVector128(gptr(first(src)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<byte> vload(W128 w, ReadOnlySpan<byte> src)
            => LoadDquVector128(gptr(first(src)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<short> vload(W128 w, ReadOnlySpan<short> src)
            => LoadDquVector128(gptr(first(src)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ushort> vload(W128 w, ReadOnlySpan<ushort> src)
            => LoadDquVector128(gptr(first(src)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<long> vload(W128 w, ReadOnlySpan<long> src)
            => LoadDquVector128(gptr(first(src)));

        /// <summary>
        /// __m128i _mm_lddqu_si128 (__m128i const* mem_addr) LDDQU xmm, m128
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ulong> vload(W128 w, ReadOnlySpan<ulong> src)
            => LoadDquVector128(gptr(first(src)));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<sbyte> vload(W256 w, in sbyte src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
        /// VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<byte> vload(W256 w, in byte src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
        /// VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<short> vload(W256 w, in short src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
        /// VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ushort> vload(W256 w, in ushort src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
        /// VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<int> vload(W256 w, in int src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vload(W256 w, in uint src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<long> vload(W256 w, in long src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vload(W256 w, in ulong src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<sbyte> vload(W256 w, ReadOnlySpan<sbyte> src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<byte> vload(W256 w, ReadOnlySpan<byte> src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<short> vload(W256 w, ReadOnlySpan<short> src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ushort> vload(W256 w, ReadOnlySpan<ushort> src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<int> vload(W256 w, ReadOnlySpan<int> src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<long> vload(W256 w, ReadOnlySpan<long> src)
            => LoadDquVector256(gptr(src));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vload(W256 w, ReadOnlySpan<ulong> src)
            => LoadDquVector256(gptr(src));

        [MethodImpl(Inline), Op]
        public static unsafe Vector512<byte> vload(W512 w, in byte src)
            => (vload(n256, in src), vload(n256, add(src, 32)));

        [MethodImpl(Inline), Op]
        public static unsafe Vector512<ushort> vload(W512 w, in ushort src)
            => (vload(n256, in src), vload(n256, add(src, 16)));

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector128<sbyte> vload(W128 w, sbyte* pSrc)
            => LoadDquVector128(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector128<byte> vload(W128 w, byte* pSrc)
            => LoadDquVector128(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector128<short> vload(W128 w, short* pSrc)
            => LoadDquVector128(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector128<ushort> vload(W128 w, ushort* pSrc)
            => LoadDquVector128(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector128<int> vload(W128 w, int* pSrc)
            => LoadDquVector128(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector128<uint> vload(W128 w, uint* pSrc)
            => LoadDquVector128(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector128<long> vload(W128 w, long* pSrc)
            => LoadDquVector128(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector128<ulong> vload(W128 w, ulong* pSrc)
            => LoadDquVector128(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector256<sbyte> vload(W256 w, sbyte* pSrc)
            => LoadDquVector256(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector256<byte> vload(W256 w, byte* pSrc)
            => LoadDquVector256(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector256<short> vload(W256 w, short* pSrc)
            => LoadDquVector256(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector256<ushort> vload(W256 w, ushort* pSrc)
            => LoadDquVector256(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector256<int> vload(W256 w, int* pSrc)
            => LoadDquVector256(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector256<uint> vload(W256 w, uint* pSrc)
            => LoadDquVector256(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector256<long> vload(W256 w, long* pSrc)
            => LoadDquVector256(pSrc);

        /// <summary>
        ///  __m256i _mm256_lddqu_si256 (__m256i const * mem_addr) VLDDQU ymm, m256
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="pSrc">The data source</param>
        [MethodImpl(Inline), Op]
        public unsafe static Vector256<ulong> vload(W256 w, ulong* pSrc)
            => LoadDquVector256(pSrc);
    }
}