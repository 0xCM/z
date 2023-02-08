//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;

    partial class vcpu
    {
        /// <summary>
        /// 8x8u -> 8x16u
        /// movzx(src[i]) -> dst[i], i = 0,.., 7
        /// __m128i _mm_cvtepu8_epi16 (__m128i a)
        /// PMOVZXBW xmm, xmm/m64
        /// PMOVZXBW_XMMdq_XMMq
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> pmovzxbw(Vector128<byte> src, out Vector128<ushort> dst)
            => dst = v16u(ConvertToVector128Int16(src));

        /// <summary>
        /// 8x8u -> 8x16u
        /// movzx(src[i]) -> dst[i], i = 0,.., 7
        /// __m128i _mm_cvtepu8_epi16 (__m128i a)
        /// PMOVZXBW xmm, xmm/m64
        /// PMOVZXBW_XMMdq_XMMq
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> pmovzxbw(ulong src, out Vector128<ushort> dst)
            => dst = v16u(ConvertToVector128Int16(vload(w128, sys.bytes(src))));
    }
}