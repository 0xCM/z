//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;
    using static core;

    partial struct vpack
    {
        /// <summary>
        /// VPMOVSXWD ymm, m128
        /// 16x16u ->16x32u
        /// Projects 16 signed 16-bit integers onto 16 signed 32-bit integers
        /// </summary>
        /// <param name="src">The input component source</param>
        /// <param name="n">The source component count</param>
        /// <param name="w">The target component width</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe void vinflate16x16i(in short src, out Vector256<int> lo, out Vector256<int> hi)
        {
            lo = ConvertToVector256Int32(gptr(src));
            hi = ConvertToVector256Int32(gptr(src, 8));
        }
    }
}