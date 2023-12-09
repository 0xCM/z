//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial class vgcpu
{
    /// <summary>
    /// Rotates the full 128 bits of a vector rightward at bit-level resolution
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The number of bits to shift</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vrorx<T>(Vector128<T> src, [Imm] byte count)
        where T : unmanaged
            => generic<T>(vcpu.vrorx(v64u(src), count));

    /// <summary>
    /// Rotates the each 128-bit lane rightward at bit-level resolution
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The number of bits to shift</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vrorx<T>(Vector256<T> src, [Imm] byte count)
        where T : unmanaged
            => generic<T>(vcpu.vrorx(v64u(src), count));
}
