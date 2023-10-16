//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;

    partial class vgcpu
    {
        /// <summary>
        /// Shuffles unsigned 8-bit source segments according to the shuffle spec
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vshuf16x8<T>(Vector128<T> src, Vector128<byte> spec)
            where T : unmanaged
                => generic<T>(vcpu.vshuffle(v8u(src), spec));

        /// <summary>
        /// Shuffles unsigned 8-bit source segments within 128-bit lanes according to the shuffle spec
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vshuf16x8<T>(Vector256<T> src, Vector256<byte> spec)
            where T : unmanaged
                => generic<T>(vcpu.vshuffle(v8u(src), spec));
    }
}