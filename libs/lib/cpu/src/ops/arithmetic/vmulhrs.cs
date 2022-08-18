//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Ssse3;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_mulhrs_epi16 (__m128i a, __m128i b) PMULHRSW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vmulhrs(Vector128<short> x, Vector128<short> y)
            => MultiplyHighRoundScale(x,y);

        /// <summary>
        ///  __m256i _mm256_mulhrs_epi16 (__m256i a, __m256i b) VPMULHRSW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vmulhrs(Vector256<short> x, Vector256<short> y)
            => MultiplyHighRoundScale(x,y);
    }
}