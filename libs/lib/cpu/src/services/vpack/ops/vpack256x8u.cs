//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// (16x16u,16x16u) -> 32x8u
        /// </summary>
        /// <param name="a">The first source vector</param>
        /// <param name="b">The second source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vpack256x8u(Vector256<ushort> a, Vector256<ushort> b)
            => vperm4x64(vpack.vpackus(a,b), Perm4L.ACBD);

        /// <summary>
        /// (8x32u,8x32u,8x32u,8x32u) -> 32x8w
        /// </summary>
        /// <param name="a">The first source vector</param>
        /// <param name="b">The second source vector</param>
        /// <param name="c">The third source vector</param>
        /// <param name="d">The fourth source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vpack256x8u(Vector256<uint> a, Vector256<uint> b, Vector256<uint> c, Vector256<uint> d)
            => vpack256x8u(vpack256x16u(a, b), vpack256x16u(c, d));

        /// <summary>
        /// __m256i _mm256_packus_epi16 (__m256i a, __m256i b)VPACKUSWB ymm, ymm, ymm/m256
        /// (16x8w,16x8w) -> 32x8w
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        /// <param name="w">The target component width</param>
        /// <param name="w">Specifies a zero-extended target</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vpack256x8u(Vector256<short> a, Vector256<short> b)
            => vpack.vpackus(a,b);
    }
}