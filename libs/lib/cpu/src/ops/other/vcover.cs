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

    partial struct cpu
    {
        /// <summary>
        /// 8x16w -> 16x8w
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vcover(Vector128<ushort> src, out Vector128<byte> dst)
            => dst = v8u(vor(vsll(src,8),src));

        /// <summary>
        /// 16x16w -> 32x8w
        /// [0, 1, ... 14, 15] -> [0, 0, 1, 1, ... 14, 14, 15, 15]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vcover(Vector256<ushort> src, out Vector256<byte> dst)
            => dst = v8u(vor(vsll(src,8),src));

        /// <summary>
        /// 4x8w -> 8x16w
        /// [0, 1, 2, 3] -> [0, 0, 1, 1, 2, 2, 3, 3]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vcover(Vector128<uint> src, out Vector128<ushort> dst)
            => dst = v16u(vor(vsll(src,16),src));

        /// <summary>
        /// 8x32w -> 16x16w
        /// [0, 1, 2, 3, 4, 5, 6, 7] -> [0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vcover(Vector256<uint> src, out Vector256<ushort> dst)
             => dst = v16u(vor(vsll(src,16),src));

        /// <summary>
        /// 2x64w -> 4x32w
        /// [0, 1] -> [0, 0, 1, 1]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vcover(Vector128<ulong> src, out Vector128<uint> dst)
            => dst = v32u(vor(vsll(src,32),src));

        /// <summary>
        /// 4x64w -> 8x32w
        /// [0, 1, 2, 3] -> [0, 0, 1, 1, 2, 2, 3, 3]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vcover(Vector256<ulong> src, out Vector256<uint> dst)
            => dst = v32u(vor(vsll(src,32),src));

        /// <summary>
        /// 4x32w -> 16x8w
        /// [0, 1, 2, 3] -> [0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vcover(Vector128<uint> src, out Vector128<byte> dst)
            => dst = vcover(v16u(vxor(vsll(src,16), src)), out dst);

        /// <summary>
        /// 8x32w -> 32x8w
        /// [0, 1, 2, 3, 4, 5, 6, 7] -> [0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vcover(Vector256<uint> src, out Vector256<byte> dst)
            => dst = vcover(v16u(vxor(vsll(src, 16), src)), out dst);

        /// <summary>
        /// 2x64w -> 16x8w
        /// [0,1] -> [0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vcover(Vector128<ulong> src, out Vector128<byte> dst)
            => dst = vcover(v32u(vxor(vsll(src,32), src)), out dst);

        /// <summary>
        /// 4x64w -> 32x8w
        /// [0, 1, 2, 3] -> [0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3]
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vcover(Vector256<ulong> src, out Vector256<byte> dst)
            => dst = vcover(v32u(vxor(vsll(src,32), src)), out dst);
    }
}