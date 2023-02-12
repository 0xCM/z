//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Ssse3;

    partial class vcpu 
    {
        /// <summary>
        /// __m128i _mm_abs_epi8 (__m128i a) PABSB xmm, xmm/m128
        /// Computes the absolute value of each source component
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Abs]
        public static Vector128<sbyte> vabs(Vector128<sbyte> src)
            => v8i(Abs(src));

        /// <summary>
        /// __m128i _mm_abs_epi16 (__m128i a) PABSW xmm, xmm/m128
        /// Computes the absolute value of each source component
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Abs]
        public static Vector128<short> vabs(Vector128<short> src)
            => v16i(Abs(src));

        /// <summary>
        /// __m128i _mm_abs_epi32 (__m128i a) PABSD xmm, xmm/m128
        /// Computes the absolute value of each source component
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Abs]
        public static Vector128<int> vabs(Vector128<int> src)
            => v32i(Abs(src));

        // /// <summary>
        // /// Computes the absolute value of each source component
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // [MethodImpl(Inline), Abs]
        // public static Vector128<long> vabs(Vector128<long> src)
        // {
        //     var mask = vnegate(vsrl(src, 63));
        //     return vsub(vxor(mask, src), mask);
        // }

        /// <summary>
        ///  __m256i _mm256_abs_epi8 (__m256i a) VPABSB ymm, ymm/m256
        /// Computes the absolute value of each source component
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Abs]
        public static Vector256<sbyte> vabs(Vector256<sbyte> src)
            => v8i(Abs(src));

        /// <summary>
        /// __m256i _mm256_abs_epi16 (__m256i a) VPABSW ymm, ymm/m256
        /// Computes the absolute value of each source component
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Abs]
        public static Vector256<short> vabs(Vector256<short> src)
            => v16i(Abs(src));

        /// <summary>
        /// Computes the absolute value of each source component
        ///  __m256i _mm256_abs_epi32 (__m256i a) VPABSD ymm, ymm/m256
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Abs]
        public static Vector256<int> vabs(Vector256<int> src)
            => v32i(Abs(src));

        // /// <summary>
        // /// Computes the absolute value of each source component
        // /// </summary>
        // /// <param name="src">The source vector</param>
        // [MethodImpl(Inline), Abs]
        // public static Vector256<long> vabs(Vector256<long> src)
        // {
        //     var mask = vnegate(vsrl(src, 63));
        //     return vsub(vxor(mask, src), mask);
        // }
    }
}