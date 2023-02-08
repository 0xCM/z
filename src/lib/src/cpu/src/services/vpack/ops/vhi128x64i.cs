//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// __m128i _mm_cvtepu32_epi64 (__m128i a)
        /// PMOVZXDQ xmm, xmm/m64
        /// 2x32u -> 2x64i
        /// src[i] -> dst[i], i = 0, 2
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vhi128x64i(Vector128<uint> src)
            => ConvertToVector128Int64(vshi(src));
    }
}