//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static core;
    using static SpanBlocks;

    partial struct cpu
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
        public static unsafe void vmaskstore(Vector128<byte> src, Vector128<byte> mask, ref byte dst)
            => MaskMove(src, mask, refptr(ref dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<sbyte> src, Vector128<byte> mask, ref byte dst)
            => MaskMove(v8u(src), v8u(mask), refptr(ref dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<short> src, Vector128<byte> mask, ref byte dst)
            => MaskMove(v8u(src), mask, refptr(ref dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<ushort> src, Vector128<byte> mask, ref byte dst)
            => MaskMove(v8u(src), mask, refptr(ref dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<int> src, Vector128<byte> mask, ref byte dst)
            => MaskMove(v8u(src), mask, refptr(ref dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<uint> src, Vector128<byte> mask, ref byte dst)
            => MaskMove(v8u(src), mask, refptr(ref dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<long> src, Vector128<byte> mask, ref byte dst)
            => MaskMove(v8u(src), mask, refptr(ref dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<ulong> src, Vector128<byte> mask, ref byte dst)
            => MaskMove(v8u(src), mask, refptr(ref dst));

        /// <summary>
        /// void _mm_maskstore_ps (float * mem_addr, __m128i mask, __m128 a) VMASKMOVPS m128, xmm, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void maskstore(Vector128<float> src, Vector128<float> mask, ref float dst)
            => MaskStore(gptr(dst), src,mask);

        /// <summary>
        /// void _mm_maskstore_pd (double * mem_addr, __m128i mask, __m128d a) VMASKMOVPD m128, xmm, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<double> src, Vector128<double> mask, ref double dst)
            => MaskStore(gptr(dst), src,mask);

        /// <summary>
        /// void _mm256_maskstore_ps (float * mem_addr, __m256i mask, __m256 a) VMASKMOVPS m256, ymm, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector256<float> src, Vector256<float> mask, ref float dst)
            => MaskStore(gptr(dst), src,mask);

        /// <summary>
        /// void _mm256_maskstore_pd (double * mem_addr, __m256i mask, __m256d a) VMASKMOVPD m256, ymm, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector256<double> src, Vector256<double> mask, ref double dst)
            => MaskStore(gptr(dst), src,mask);

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector128<sbyte> src, Vector128<byte> mask, in SpanBlock128<byte> dst)
            => MaskMove(v8u(src), v8u(mask), ptr(dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector128<byte> src, Vector128<byte> mask, in SpanBlock128<byte> dst)
            => MaskMove(src, mask, ptr(dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector128<short> src, Vector128<byte> mask, in SpanBlock128<byte> dst)
            => MaskMove(v8u(src), mask, ptr(dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector128<ushort> src, Vector128<byte> mask, in SpanBlock128<byte> dst)
            => MaskMove(v8u(src), mask, ptr(dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector128<int> src, Vector128<byte> mask, in SpanBlock128<byte> dst)
            => MaskMove(v8u(src), mask, ptr(dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector128<uint> src, Vector128<byte> mask, in SpanBlock128<byte> dst)
            => MaskMove(v8u(src), mask, ptr(dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector128<long> src, Vector128<byte> mask, in SpanBlock128<byte> dst, uint block)
            => MaskMove(v8u(src), mask, gptr(dst.BlockLead(block)));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector128<ulong> src, Vector128<byte> mask, in SpanBlock128<byte> dst)
            => MaskMove(v8u(src), mask, ptr(dst));

        /// <summary>
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector256<sbyte> src, Vector256<byte> mask, in SpanBlock256<byte> dst)
        {
            vmaskstore(vlo(src), vlo(mask), ref dst.First);
            vmaskstore(cpu.vhi(src), cpu.vhi(mask), ref seek(dst.First, 16));
        }

        /// <summary>
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector256<byte> src, Vector256<byte> mask, in SpanBlock256<byte> dst)
        {
            vmaskstore(vlo(src), vlo(mask), ref dst.First);
            vmaskstore(cpu.vhi(src), cpu.vhi(mask), ref seek(dst.First, 16));
        }

        /// <summary>
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector256<short> src, Vector256<byte> mask, in SpanBlock256<byte> dst)
        {
            vmaskstore(vlo(src), vlo(mask), ref dst.First);
            vmaskstore(cpu.vhi(src), cpu.vhi(mask), ref seek(dst.First, 16));
        }

        /// <summary>
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector256<ushort> src, Vector256<byte> mask, in SpanBlock256<byte> dst)
        {
            vmaskstore(vlo(src), vlo(mask), ref dst.First);
            vmaskstore(vhi(src), vhi(mask), ref seek(dst.First, 16));
        }

        /// <summary>
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector256<int> src, Vector256<byte> mask, in SpanBlock256<byte> dst)
        {
            vmaskstore(vlo(src), vlo(mask), ref dst.First);
            vmaskstore(vhi(src), vhi(mask), ref seek(dst.First, 16));
        }

        /// <summary>
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector256<uint> src, Vector256<byte> mask, in SpanBlock256<byte> dst)
        {
            vmaskstore(vlo(src), vlo(mask), ref dst.First);
            vmaskstore(vhi(src), vhi(mask), ref seek(dst.First, 16));
        }

        /// <summary>
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector256<long> src, Vector256<byte> mask, in SpanBlock256<byte> dst)
        {
            vmaskstore(vlo(src), vlo(mask), ref dst.First);
            vmaskstore(vhi(src), vhi(mask), ref seek(dst.First, 16));
        }

        /// <summary>
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore8(Vector256<ulong> src, Vector256<byte> mask, in SpanBlock256<byte> dst)
        {
            vmaskstore(vlo(src), vlo(mask), ref dst.First);
            vmaskstore(vhi(src), vhi(mask), ref seek(dst.First, 16));
        }

        /// <summary>
        /// void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a) VPMASKMOVD m256, ymm, ymm
        /// Conditionally stores 32-bit source vector segments to memory according to a vectorized mask
        /// where the hi bit of each corresponding section determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore32(Vector256<uint> src, Vector256<uint> mask, in SpanBlock256<uint> dst)
            => MaskStore(ptr(dst), src, mask);

        /// <summary>
        /// Conditionally stores 32-bit source vector segments to memory according to a vectorized mask
        /// where the hi bit of each corresponding component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore32(Vector256<byte> src, Vector256<uint> mask, in SpanBlock256<uint> dst)
            => vmaskstore(v32u(src), mask, dst);

        /// <summary>
        /// Conditionally stores 32-bit source vector segments to memory according to a vectorized mask
        /// where the hi bit of each corresponding component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore32(Vector256<ushort> src, Vector256<uint> mask, in SpanBlock256<uint> dst)
            => vmaskstore(v32u(src), mask, dst);

        /// <summary>
        /// Conditionally stores 32-bit source vector segments to memory according to a vectorized mask
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore32(Vector256<ulong> src, Vector256<uint> mask, in SpanBlock256<uint> dst)
            => vmaskstore(v32u(src), mask, dst);

        /// <summary>
        /// void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a) VPMASKMOVQ m256, ymm, ymm
        /// Conditionally stores 64-bit source vector segments to memory according to a vectorized mask
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore64(Vector256<byte> src, Vector256<ulong> mask, in SpanBlock256<ulong> dst)
            => vmaskstore(v64u(src), mask, dst);

        /// <summary>
        /// void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a) VPMASKMOVQ m256, ymm, ymm
        /// Conditionally stores 64-bit source vector segments to memory according to a vectorized mask
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore64(Vector256<ushort> src, Vector256<ulong> mask, in SpanBlock256<ulong> dst)
            => vmaskstore(v64u(src), mask, dst);

        /// <summary>
        /// void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a) VPMASKMOVQ m256, ymm, ymm
        /// Conditionally stores 64-bit source vector segments to memory according to a vectorized mask
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore64(Vector256<uint> src, Vector256<ulong> mask, in SpanBlock256<ulong> dst)
            => vmaskstore(v64u(src), mask, dst);

        /// <summary>
        /// void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a) VPMASKMOVQ m256, ymm, ymm
        /// Conditionally stores source vector components to memory according to a vectorized mask
        /// where the hi bit of each corresponding component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore64(Vector256<ulong> src, Vector256<ulong> mask, in SpanBlock256<ulong> dst)
            => MaskStore(ptr(dst), src, mask);

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<byte> src, Vector128<byte> mask, in SpanBlock128<byte> dst)
            => MaskMove(src, mask, ptr(dst));

        /// <summary>
        /// void _mm_maskmoveu_si128 (__m128i a, __m128i mask, char* mem_address) MASKMOVDQU xmm, xmm
        /// Conditionally stores 8-bit segments from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit segment determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<sbyte> src, Vector128<sbyte> mask, in SpanBlock128<sbyte> dst)
            => MaskMove(src, mask, ptr(dst));

        /// <summary>
        /// void _mm_maskstore_epi32 (int* mem_addr, __m128i mask, __m128i a) VPMASKMOVD m128, xmm, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<int> src, Vector128<int> mask, in SpanBlock128<int> dst)
            => MaskStore(ptr(dst), src, mask);

        /// <summary>
        /// void _mm_maskstore_epi32 (int* mem_addr, __m128i mask, __m128i a) VPMASKMOVD m128, xmm, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<uint> src, Vector128<uint> mask, in SpanBlock128<uint> dst)
            => MaskStore(ptr(dst), src,mask);

        /// <summary>
        /// void _mm_maskstore_epi64 (__int64* mem_addr, __m128i mask, __m128i a) VPMASKMOVQ m128, xmm, xmm
        /// Conditionally stores source vector components to memory according to a vectorized mask
        /// where the hi bit of each corresponding component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector128<ulong> src, Vector128<ulong> mask, in SpanBlock128<ulong> dst, uint block = 0)
            => MaskStore(gptr(dst.BlockLead(block)), src, mask);

        /// <summary>
        /// Conditionally stores 8-bit components from the source vector to memory according to a vectorized mask
        /// where the hi bit of each corresponding 8-bit component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The source content selector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector256<byte> src, Vector256<byte> mask, in SpanBlock256<byte> dst, uint block = 0)
        {
            ref var a = ref dst.BlockLead(block);
            ref var b = ref seek(a,16);
            vmaskstore(vlo(src), vlo(mask), ref a);
            vmaskstore(vhi(src), vhi(mask), ref b);
        }

        /// <summary>
        /// void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a) VPMASKMOVD m256, ymm, ymm
        /// Conditionally stores source vector components to memory according to a vectorized mask
        /// where the hi bit of each corresponding component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector256<int> src, Vector256<int> mask, in SpanBlock256<int> dst, uint block = 0)
            => MaskStore(gptr(dst.BlockLead(block)), src, mask);

        /// <summary>
        /// void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a) VPMASKMOVD m256, ymm, ymm
        /// Conditionally stores 32-bit source vector components to memory according to a vectorized mask
        /// where the hi bit of each corresponding component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector256<uint> src, Vector256<uint> mask, in SpanBlock256<uint> dst, uint block = 0)
            => MaskStore(gptr(dst.BlockLead(block)), src, mask);

        /// <summary>
        /// void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a) VPMASKMOVQ m256, ymm, ymm
        /// Conditionally stores source vector components to memory according to a vectorized mask
        /// where the hi bit of each corresponding component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector256<long> src, Vector256<long> mask, in SpanBlock256<long> dst, uint block = 0)
            => MaskStore(gptr(dst.BlockLead(block)), src, mask);

        /// <summary>
        /// void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a) VPMASKMOVQ m256, ymm, ymm
        /// Conditionally stores source vector components to memory according to a vectorized mask
        /// where the hi bit of each corresponding component determines whether the source data is written
        /// If the hi bit is enabled, content is written, otherwise it is not
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="mask">The mask</param>
        /// <param name="dst">The target memory reference</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmaskstore(Vector256<ulong> src, Vector256<ulong> mask, in SpanBlock256<ulong> dst, uint block = 0)
            => MaskStore(gptr(dst.BlockLead(block)), src, mask);
    }
}