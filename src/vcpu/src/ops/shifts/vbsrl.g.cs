//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial class vgcpu
{

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector512<T> vbsrl<T>(Vector512<T> x, [Imm] byte count)
        where T : unmanaged
            => vbsrl_u(x,count);

    /// <summary>
    /// Applies a rightward shift over the full 128 vector bits at byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    /// <typeparam name="T">THe primal component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vbsrl<T>(Vector128<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vbsrl(v8u(x), count));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vbsrl(v16u(x), count));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vbsrl(v32u(x), count));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vbsrl(v64u(x), count));
        else
            throw no<T>();
    }

    /// <summary>
    /// Applies a rightward shift to each 128-bit lane at byte-level resolution
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    /// <typeparam name="T">THe primal component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vbsrl<T>(Vector256<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vbsrl(v8u(x), count));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vbsrl(v16u(x), count));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vbsrl(v32u(x), count));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vbsrl(v64u(x), count));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    static Vector512<T> vbsrl_u<T>(Vector512<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vbsrl(v8u(x), count));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vbsrl(v16u(x), count));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vbsrl(v32u(x), count));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vbsrl(v64u(x), count));
        else
            return vbsrl_i(x, count);
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    static Vector512<T> vbsrl_i<T>(Vector512<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vbsrl(v8i(x), count));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vbsrl(v16i(x), count));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vbsrl(v32i(x), count));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vbsrl(v64i(x), count));
        else
            throw no<T>();
    }

}
