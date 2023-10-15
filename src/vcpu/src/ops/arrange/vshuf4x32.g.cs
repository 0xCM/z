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
    /// Shuffles unsigned 32-bit source segments to/from arbitrary locations according to the shuffle spec
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector128<T> vshuf4x32<T>(Vector128<T> src, [Imm] byte spec)
        where T : unmanaged
            => generic<T>(vcpu.vshuf4x32(v32u(src), spec));

    /// <summary>
    /// Shuffles unsigned 32-bit source segments within 128-bit lanes according to the shuffle spec
    /// </summary>
    /// <param name="src">The content vector</param>
    /// <param name="spec">The shuffle spec</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector256<T> vshuf4x32<T>(Vector256<T> src, [Imm] byte spec)
        where T : unmanaged
            => generic<T>(vcpu.vshuf4x32(v32u(src), spec));

    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector128<T> vshuf4x32<T>(Vector128<T> src, [Imm] Arrange4L spec)
        where T : unmanaged
            => generic<T>(vcpu.vshuf4x32(v32u(src), spec));

    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector256<T> vshuf4x32<T>(Vector256<T> src, [Imm] Arrange4L spec)
        where T : unmanaged
            => generic<T>(vcpu.vshuf4x32(v32u(src), spec));
}
