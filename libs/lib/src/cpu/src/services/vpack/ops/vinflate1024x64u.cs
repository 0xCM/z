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
        /// 16x16u -> 16x64u
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target cell type representative</param>
        [MethodImpl(Inline), Op]
        public static void vinflate1024x64u(Vector256<ushort> src, out Vector512<ulong> lo, out Vector512<ulong> hi)
        {
            lo = vinflate512x64u(vlo(src));
            hi = vinflate512x64u(vhi(src));
        }
    }
}