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
    using static System.Runtime.Intrinsics.X86.Ssse3;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b) PSHUFB xmm, xmm/m128
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vshuf16x8(Vector128<sbyte> src, Vector128<sbyte> spec)
            => Shuffle(src, spec);

        /// <summary>
        /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b) PSHUFB xmm, xmm/m128
        /// For each component of the shuffle spec:
        /// testbit(spec[i],7) == 1 => dst[i] = 0
        /// testbit(spec[i],7) == 0 => dst[i] = src[i]
        /// spec[i] = j := 0 | 1 | ... | 15 => dst[j] = src[i]
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vshuf16x8(Vector128<byte> src, Vector128<byte> spec)
            => Shuffle(src, spec);

        /// <summary>
        /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b) PSHUFB xmm, xmm/m128
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vshuf16x8(Vector128<short> src, Vector128<byte> spec)
            => v16i(Shuffle(v8u(src), spec));

        /// <summary>
        /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b) PSHUFB xmm, xmm/m128
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vshuf16x8(Vector128<ushort> src, Vector128<byte> spec)
            => v16u(Shuffle(v8u(src), spec));

        /// <summary>
        /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b) PSHUFB xmm, xmm/m128
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vshuf16x8(Vector128<int> src, Vector128<byte> spec)
            => v32i(Shuffle(v8u(src), spec));

        /// <summary>
        /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b) PSHUFB xmm, xmm/m128
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vshuf16x8(Vector128<uint> src, Vector128<byte> spec)
            => v32u(Shuffle(v8u(src), spec));

        /// <summary>
        /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b) PSHUFB xmm, xmm/m128
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vshuf16x8(Vector128<long> src, Vector128<byte> spec)
            => v64i(Shuffle(v8u(src), spec));

        /// <summary>
        /// __m128i _mm_shuffle_epi8 (__m128i a, __m128i b) PSHUFB xmm, xmm/m128
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vshuf16x8(Vector128<ulong> src, Vector128<byte> spec)
            => v64u(Shuffle(v8u(src), spec));

        /// <summary>
        /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b) VPSHUFB ymm, ymm, ymm/m256
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vshuf16x8(Vector256<sbyte> src, Vector256<sbyte> spec)
            => Shuffle(src, spec);

        ///<summary>
        /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b) VPSHUFB ymm, ymm, ymm/m256
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        ///</summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vshuf16x8(Vector256<byte> src, Vector256<byte> spec)
            => Shuffle(src, spec);

        ///<summary>
        /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b) VPSHUFB ymm, ymm, ymm/m256
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        ///</summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vshuf16x8(Vector256<short> src, Vector256<byte> spec)
            => v16i(Shuffle(v8u(src), spec));

        ///<summary>
        /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b) VPSHUFB ymm, ymm, ymm/m256
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        ///</summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vshuf16x8(Vector256<ushort> src, Vector256<byte> spec)
            => v16u(Shuffle(v8u(src), spec));

        ///<summary>
        /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b) VPSHUFB ymm, ymm, ymm/m256
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        ///</summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vshuf16x8(Vector256<int> src, Vector256<byte> spec)
            => v32i(Shuffle(v8u(src), spec));

        ///<summary>
        /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b) VPSHUFB ymm, ymm, ymm/m256
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        ///</summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vshuf16x8(Vector256<uint> src, Vector256<byte> spec)
            => v32u(Shuffle(v8u(src), spec));

        ///<summary>
        /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b) VPSHUFB ymm, ymm, ymm/m256
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        ///</summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vshuf16x8(Vector256<long> src, Vector256<byte> spec)
            => v64i(Shuffle(v8u(src), spec));

        ///<summary>
        /// __m256i _mm256_shuffle_epi8 (__m256i a, __m256i b) VPSHUFB ymm, ymm, ymm/m256
        /// Shuffles source vector components within 128-bit lanes as specified by the corresponding component in the shuffle spec
        ///</summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vshuf16x8(Vector256<ulong> src, Vector256<byte> spec)
            => v64u(Shuffle(v8u(src), spec));
    }
}