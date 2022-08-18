//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse2;

    partial struct cpu
    {
        /// <summary>
        /// src[0..15] -> r/m16[0..31]
        /// int _mm_cvtsi128_si32 (__m128i a)
        /// MOVD reg/m32, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target width</param>
        /// <param name="t">A target type representative</param>
        /// <remarks>
        /// vmovupd xmm0,[rcx] |> vmovd eax,xmm0 |> movsx rax,ax |>
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static short vlo16i(Vector128<short> src)
            => (short)vlo32i(v32i(src));

        /// <summary>
        /// src[0..15] -> r/m16[0..31]
        /// int _mm_cvtsi128_si32 (__m128i a)
        /// MOVD reg/m32, xmm
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target width</param>
        /// <param name="t">A target type representative</param>
        /// <remarks>
        /// vmovupd xmm0,[rcx] |> vmovd eax,xmm0 |> movsx eax,ax
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static ushort vlo16u(Vector128<ushort> src)
            => (ushort)ConvertToUInt32(v32u(src));
    }
}