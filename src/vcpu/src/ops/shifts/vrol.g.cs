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
    /// Rotates each component the source vector leftwards by a constant amount
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vrol<T>(Vector128<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vrol(v8u(x), count));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vrol(v16u(x), count));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vrol(v32u(x), count));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vrol(v64u(x), count));
        else
            throw no<T>();
    }

    /// <summary>
    /// Rotates each component the source vector leftwards by a constant count
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vrol<T>(Vector256<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vrol(v8u(x), count));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vrol(v16u(x), count));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vrol(v32u(x), count));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vrol(v64u(x), count));
        else
            throw no<T>();
    }
}
