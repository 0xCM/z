//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static core;

    partial struct cpu
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
        /// void _mm_storeu_pd (double* mem_addr, __m128d a) MOVUPD m128, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector128<float> src, ref float dst)
            => Store(refptr(ref dst), src);

        /// <summary>
        /// Stores vector content to a specified reference
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector128<double> src, ref double dst)
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
        /// Stores vector content to a specified reference
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        ///<intrinsic>void _mm256_storeu_ps (float * mem_addr, __m256 a) MOVUPS m256, ymm</intrinsic>
        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector256<float> src, ref float dst)
            => Store(refptr(ref dst),src);

        /// <summary>
        /// Stores vector content to a specified reference
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        ///<intrinsic>void _mm256_storeu_pd (double * mem_addr, __m256d a) MOVUPD m256, ymm</intrinsic>
        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector256<double> src, ref double dst)
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
        ///  void _mm_storeu_ps (float* mem_addr, __m128 a) MOVUPS m128, xmm
        /// Stores vector content to a specified reference, offset by a specified amount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector128<float> src, ref float dst, int offset)
            => Store(refptr(ref dst, offset), src);

        /// <summary>
        /// void _mm_storeu_pd (double* mem_addr, __m128d a) MOVUPD m128, xmm
        /// Stores vector content to a specified reference, offset by a specified amount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector128<double> src, ref double dst, int offset)
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

        /// <summary>
        /// void _mm256_storeu_ps (float * mem_addr, __m256 a) MOVUPS m256, ymm
        /// Stores vector content to a specified reference, offset by a specified amount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        ///<intrinsic>void _mm256_storeu_ps (float * mem_addr, __m256 a) MOVUPS m256, ymm</intrinsic>
        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector256<float> src, ref float dst, int offset)
            => Store(refptr(ref dst, offset), src);

        /// <summary>
        /// void _mm256_storeu_pd (double * mem_addr, __m256d a) MOVUPD m256, ymm
        /// Stores vector content to a specified reference, offset by a specified amount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target memory</param>
        ///<intrinsic>void _mm256_storeu_pd (double * mem_addr, __m256d a) MOVUPD m256, ymm</intrinsic>
        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector256<double> src, ref double dst, int offset)
            => Store(refptr(ref dst, offset), src);

        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector512<byte> src, ref byte dst)
        {
            vstore(src.Lo, ref dst);
            vstore(src.Hi, ref Unsafe.Add(ref dst, 32));
        }

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
        public static unsafe void vstore(Vector128<byte> src, uint offset, Span<byte> dst)
            => vstore(src, ref seek(dst,offset));

        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector256<byte> src, uint offset, Span<byte> dst)
            => vstore(src, ref seek(dst,offset));

        [MethodImpl(Inline), Store]
        public static unsafe void vstore(Vector512<byte> src, uint offset, Span<byte> dst)
            => vstore(src, ref seek(dst,offset));
    }
}