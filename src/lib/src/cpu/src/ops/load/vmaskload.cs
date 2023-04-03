//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask) VPMASKMOVD xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<int> vmaskload(in int src, Vector128<int> mask)
            => MaskLoad(gptr(src),mask);

        /// <summary>
        /// __m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask) VPMASKMOVD xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vmaskload(in uint src, Vector128<uint> mask)
            => MaskLoad(gptr(src),mask);

        /// <summary>
        /// __m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask) VPMASKMOVQ xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ulong> vmaskload(in ulong src, Vector128<ulong> mask)
            => MaskLoad(gptr(src),mask);

        /// <summary>
        /// __m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask) VPMASKMOVQ xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<long> vmaskload(in long src, Vector128<long> mask)
            => MaskLoad(gptr(src),mask);

        /// <summary>
        /// __m128 _mm_maskload_ps (float const * mem_addr, __m128i mask) VMASKMOVPS xmm,xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<float> vmaskload(in float src, Vector128<float> mask)
            => MaskLoad(gptr(src), mask);

        /// <summary>
        /// __m128 _mm_maskload_ps (float const * mem_addr, __m128i mask) VMASKMOVPS xmm,xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<double> vmaskload(in double src, Vector128<double> mask)
            => MaskLoad(gptr(src), mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask) VPMASKMOVD ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<int> vmaskload(in int src, Vector256<int> mask)
            => MaskLoad(gptr(src),mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask) VPMASKMOVD ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vmaskload(in uint src, Vector256<uint> mask)
            => MaskLoad(gptr(src),mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask) VPMASKMOVQ ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<long> vmaskload(in long src, Vector256<long> mask)
            => MaskLoad(gptr(src),mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask) VPMASKMOVQ ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vmaskload(in ulong src, Vector256<ulong> mask)
            => MaskLoad(gptr(src),mask);

        /// <summary>
        /// __m256d _mm256_maskload_pd (double const * mem_addr, __m256i mask) VMASKMOVPD ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<float> vmaskload(in float src, Vector256<float> mask)
            => MaskLoad(gptr(src), mask);

        /// <summary>
        /// __m256d _mm256_maskload_pd (double const * mem_addr, __m256i mask) VMASKMOVPD ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<double> vmaskload(in double src, Vector256<double> mask)
            => MaskLoad(gptr(src), mask);

        /// <summary>
        /// __m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask) VPMASKMOVD xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<int> vmaskload(int* pSrc, Vector128<int> mask)
            => MaskLoad(pSrc,mask);

        /// <summary>
        /// __m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask) VPMASKMOVD xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<uint> vmaskload(uint* pSrc, Vector128<uint> mask)
            => MaskLoad(pSrc,mask);

        /// <summary>
        /// __m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask) VPMASKMOVQ xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<ulong> vmaskload(ulong* pSrc, Vector128<ulong> mask)
            => MaskLoad(pSrc,mask);

        /// <summary>
        /// __m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask) VPMASKMOVQ xmm, xmm, m128
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector128<long> vmaskload(long* pSrc, Vector128<long> mask)
            => MaskLoad(pSrc,mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask) VPMASKMOVD ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<int> vmaskload(int* pSrc, Vector256<int> mask)
            => MaskLoad(pSrc,mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask) VPMASKMOVD ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<uint> vmaskload(uint* pSrc, Vector256<uint> mask)
            => MaskLoad(pSrc,mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask) VPMASKMOVQ ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<long> vmaskload(long* pSrc, Vector256<long> mask)
            => MaskLoad(pSrc,mask);

        /// <summary>
        /// __m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask) VPMASKMOVQ ymm, ymm, m256
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="mask">Hi bit on selects the memory, otherwise set to zero</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector256<ulong> vmaskload(ulong* pSrc, Vector256<ulong> mask)
            => MaskLoad(pSrc,mask);
    }
}