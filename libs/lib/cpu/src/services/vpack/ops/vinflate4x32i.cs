//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial struct vpack
    {
        /// <summary>
        /// 4x32w -> 4x64w
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op(inflate)]
        public static Vector256<long> vinflate4x32i(Vector128<int> src, out Vector256<long> dst)
             => dst = ConvertToVector256Int64(src);
    }
}