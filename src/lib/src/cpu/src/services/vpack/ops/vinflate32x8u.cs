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
    using static core;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// VPMOVZXBW ymm, m128
        /// 32x8u -> 32x16u
        /// Projects 32 unsigned 8-bit integers onto 32 unsigned 16-bit integers
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="lo">The lo target</param>
        /// <param name="hi">The hi target</param>
        [MethodImpl(Inline), Op(inflate)]
        public static unsafe void vinflate32x8u(in byte src, out Vector256<ushort> lo, out Vector256<ushort> hi)
        {
            lo = v16u(ConvertToVector256Int16(gptr(src)));
            hi = v16u(ConvertToVector256Int16(gptr(src,16)));
        }
    }
}