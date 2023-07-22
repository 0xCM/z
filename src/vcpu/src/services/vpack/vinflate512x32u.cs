//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static sys;
    using static vcpu;

    partial struct vpack
    {
        /// <summary>
        /// 16x16u -> 16x32u
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target vector width</param>
        /// <param name="t">A target type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector512<uint> vinflate512x32u(Vector256<ushort> src)
            => Vector512.Create(vlo256x32u(src), vhi256x16u(src));

        /// <summary>
        /// 16x8u -> 16x32u
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="w">The target width</param>
        /// <param name="t">A target component type representative</param>
        [MethodImpl(Inline), Op]
        public static Vector512<uint> vinflate512x32u(Vector128<byte> src)
            => Vector512.Create(vlo256x32u(src), vhi256x32u(src));                
    }
}