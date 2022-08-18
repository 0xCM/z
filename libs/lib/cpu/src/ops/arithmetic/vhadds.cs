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
        ///  __m128i _mm_hadds_epi16 (__m128i a, __m128i b) PHADDSW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddHS]
        public static Vector128<short> vhadds(Vector128<short> x, Vector128<short> y)
            => HorizontalAddSaturate(x, y);

        /// <summary>
        /// __m256i _mm256_hadds_epi16 (__m256i a, __m256i b) VPHADDSW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddHS]
        public static Vector256<short> vhadds(Vector256<short> x, Vector256<short> y)
            => HorizontalAddSaturate(x, y);
    }
}