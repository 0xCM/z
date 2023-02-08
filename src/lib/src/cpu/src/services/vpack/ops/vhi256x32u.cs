//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        ///  __m256i _mm256_cvtepu8_epi32 (__m128i a)
        /// VPMOVZXBD ymm, xmm
        /// Zero extends 8 8-bit integers from the low 8 bytes of the source to 8 32-bit integers in the target
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vhi256x32u(Vector128<byte> src)
            => v32u(ConvertToVector256Int32(vshi(src)));
    }
}