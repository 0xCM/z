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
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// _mm_srav_epi32, avx2, shift-right variable arithmetic:
        /// Applies a rightward arithmetic shift each source vector component as
        /// specified by the amount the corresponding control vector component
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vsrav(Vector128<int> src, Vector128<uint> counts)
            => ShiftRightArithmeticVariable(src, counts);

        /// <summary>
        /// _mm256_srav_epi32, avx2, shift-right variable arithmetic:
        /// Applies a rightward arithmetic shift each source vector component as
        /// specified by the amount the corresponding control vector component
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vsrav(Vector256<int> src, Vector256<uint> counts)
            => ShiftRightArithmeticVariable(src, counts);
    }
}