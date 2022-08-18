//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Ssse3;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_hsubs_epi16 (__m128i a, __m128i b) PHSUBSW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), SubHS]
        public static Vector128<short> vhsubs(Vector128<short> x, Vector128<short> y)
            => HorizontalSubtractSaturate(x, y);

        /// <summary>
        ///  __m256i _mm256_hsubs_epi16 (__m256i a, __m256i b) VPHSUBSW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), SubHS]
        public static Vector256<short> vhsubs(Vector256<short> x, Vector256<short> y)
            => HorizontalSubtractSaturate(x, y);
    }
}