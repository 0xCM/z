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
        /// 4x8u -> 4x32u
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// __m128i _mm_cvtepu8_epi32 (__m128i a)
        /// PMOVZXBD xmm, xmm/m32
        /// PMOVZXBD_XMMdq_XMMd
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> pmovzxbd(Vector128<byte> src, out Vector128<uint> dst)
            => dst = v32u(ConvertToVector128Int32(src));

        /// <summary>
        /// 4x8u -> 4x32u
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// __m128i _mm_cvtepu8_epi32 (__m128i a)
        /// PMOVZXBD xmm, xmm/m32
        /// PMOVZXBD_XMMdq_XMMd
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> pmovzxbd(uint src, out Vector128<uint> dst)
            => dst = v32u(ConvertToVector128Int32(vload(w128, sys.bytes(src))));
    }
}