//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;

    partial struct vpack
    {
        /// <summary>
        /// 16x8i -> 16x32i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target cell type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector512<int> vinflate512x32i(Vector128<sbyte> src)
            => (vlo256x32i(src), vhi256x32i(src));

        /// <summary>
        /// 16x16i -> 16x32i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target vector width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector512<int> vinflate512x32i(Vector256<short> src)
            => (vlo256x32i(src), vhi256x32i(src));

        /// <summary>
        /// VPMOVSXWD ymm, m128
        /// 16x16u ->16x32u
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static unsafe Vector512<int> vinflate512x32i(SpanBlock128<short> src, uint offset)
            => (ConvertToVector256Int32(gptr(src[offset])),
                ConvertToVector256Int32(gptr(src[offset], 8)));
    }
}