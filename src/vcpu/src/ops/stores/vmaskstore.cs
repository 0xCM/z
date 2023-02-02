//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
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
    }
}