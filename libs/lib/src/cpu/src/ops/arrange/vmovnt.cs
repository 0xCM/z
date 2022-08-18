//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;

    using static Root;
    using static core;

    partial struct cpu
    {
        /// <summary>
        /// _mm_stream_si128 (__m128i* mem_addr, __m128i a) MOVNTDQ m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector128<sbyte> src, ref sbyte dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// _mm_stream_si128 (__m128i* mem_addr, __m128i a) MOVNTDQ m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector128<byte> src, ref byte dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// _mm_stream_si128 (__m128i* mem_addr, __m128i a) MOVNTDQ m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovntdq(Vector128<short> src, ref short dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// _mm_stream_si128 (__m128i* mem_addr, __m128i a) MOVNTDQ m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector128<ushort> src, ref ushort dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// _mm_stream_si128 (__m128i* mem_addr, __m128i a) MOVNTDQ m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector128<int> src, ref int dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// _mm_stream_si128 (__m128i* mem_addr, __m128i a) MOVNTDQ m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector128<uint> src, ref uint dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// _mm_stream_si128 (__m128i* mem_addr, __m128i a) MOVNTDQ m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector128<long> src, ref long dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// _mm_stream_si128 (__m128i* mem_addr, __m128i a) MOVNTDQ m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector128<ulong> src, ref ulong dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm_stream_ps (float* mem_addr, __m128 a) MOVNTPS m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovntps(Vector128<float> src, ref float dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm_stream_pd (double* mem_addr, __m128d a) MOVNTPD m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovntpd(Vector128<double> src, ref double dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_si256 (__m256i * mem_addr, __m256i a) VMOVNTDQ m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector256<sbyte> src, ref sbyte dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_si256 (__m256i * mem_addr, __m256i a) VMOVNTDQ m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector256<byte> src, ref byte dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_si256 (__m256i * mem_addr, __m256i a) VMOVNTDQ m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector256<short> src, ref short dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_si256 (__m256i * mem_addr, __m256i a) VMOVNTDQ m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector256<ushort> src, ref ushort dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_si256 (__m256i * mem_addr, __m256i a) VMOVNTDQ m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector256<int> src, ref int dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_si256 (__m256i * mem_addr, __m256i a) VMOVNTDQ m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector256<uint> src, ref uint dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_si256 (__m256i * mem_addr, __m256i a) VMOVNTDQ m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector256<long> src, ref long dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_si256 (__m256i * mem_addr, __m256i a) VMOVNTDQ m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovnt(Vector256<ulong> src, ref ulong dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_ps (float * mem_addr, __m256 a) MOVNTPS m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovntps(Vector256<float> src, ref float dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);

        /// <summary>
        /// void _mm256_stream_pd (double * mem_addr, __m256d a) MOVNTPD m256, ymm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The storage target</param>
        [MethodImpl(Inline), Op]
        public static unsafe void vmovntpd(Vector256<double> src, ref double dst)
            => StoreAlignedNonTemporal(refptr(ref dst), src);
    }
}