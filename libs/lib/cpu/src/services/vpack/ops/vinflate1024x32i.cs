//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// 32x8i -> (8x32i, 8x32i, 8x32i, 8x32i)
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="x1">A target cell type representative</param>
        [MethodImpl(Inline), Op]
        public static void vinflate1024x32i(Vector256<sbyte> src, out Vector512<int> lo, out Vector512<int> hi)
        {
            (var x0, var x1) = vinflate512x16i(src);
            lo = (vlo256x32i(x0), vhi256x32i(x0));
            hi = (vlo256x32i(x1), vhi256x32i(x1));
        }
    }
}