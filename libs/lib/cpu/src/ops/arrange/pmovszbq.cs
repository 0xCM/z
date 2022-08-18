//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;

    partial struct cpu
    {
        /// <summary>
        /// 2x8u -> 4x64u
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// __m128i _mm_cvtepu8_epi64 (__m128i a)
        /// PMOVZXBQ xmm, xmm/m16
        /// PMOVZXBQ_XMMdq_XMMw
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> pmovzxbq(Vector128<byte> src, out Vector128<ulong> dst)
            => dst = v64u(ConvertToVector128Int64(src));

        /// <summary>
        /// 2x8u -> 4x64u
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// __m128i _mm_cvtepu8_epi64 (__m128i a)
        /// PMOVZXBQ xmm, xmm/m16
        /// PMOVZXBQ_XMMdq_XMMw
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> pmovzxbq(ushort src, out Vector128<ulong> dst)
            => dst = v64u(ConvertToVector128Int64(vload(w128, sys.bytes(src))));
    }
}