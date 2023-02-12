//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu 
    {
        /// <summary>
        /// __m128i _mm_mpsadbw_epu8 (__m128i a, __m128i b, const int imm8)
        /// MPSADBW xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="mask"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vmpsadbw(Vector128<byte> a, Vector128<byte> b, byte mask)
            => MultipleSumAbsoluteDifferences(a,b,mask);

        /// <summary>
        /// __m256i _mm256_mpsadbw_epu8 (__m256i a, __m256i b, const int imm8)
        /// VMPSADBW ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="mask"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vmpsadbw(Vector256<byte> a, Vector256<byte> b, byte mask)
            => MultipleSumAbsoluteDifferences(a,b,mask);
    }
}