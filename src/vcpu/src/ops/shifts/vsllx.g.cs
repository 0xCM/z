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
        /// Shifts the full 128 bits of a vector leftward at bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to shift</param>
        [MethodImpl(Inline), Sllx, Closures(Closure)]
        public static Vector128<T> vsllx<T>(Vector128<T> src, [Imm] byte count)
            where T : unmanaged
                => generic<T>(vcpu.vsllx(v64u(src), count));

        /// <summary>
        /// Shifts each 128 bit lane leftward at bit-level resolution
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to shift</param>
        [MethodImpl(Inline), Sllx, Closures(Closure)]
        public static Vector256<T> vsllx<T>(Vector256<T> src, [Imm] byte count)
            where T : unmanaged
                => generic<T>(vcpu.vsllx(v64u(src), count));
    }
}