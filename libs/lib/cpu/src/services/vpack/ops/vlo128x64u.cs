//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// __m128i _mm_cvtepu32_epi64 (__m128i a)
        /// PMOVZXDQ xmm, xmm/m64
        /// 2x32u -> 2x64u
        /// src[i] -> dst[i], i = 0, 2
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vlo128x64u(Vector128<uint> src)
            => v64u(ConvertToVector128Int64(src));
    }
}