//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct vpack
    {
        /// <summary>
        /// 32x8u -> (8x32u, 8x32u, 8x32u, 8x32u)
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="x1">A target cell type representative</param>
        [MethodImpl(Inline), Op]
        public static void vinflate1024x32u(Vector256<byte> src, out Vector512<uint> lo, out Vector512<uint> hi)
        {
            (var x0, var x1) = vinflate512x16u(src);
            lo = vinflate512x32u(x0);
            hi = vinflate512x32u(x1);
        }
    }
}