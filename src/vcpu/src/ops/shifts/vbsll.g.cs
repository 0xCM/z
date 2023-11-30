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
    /// Applies a leftward shift over the full 128 vector bits at byte-level resolution
    /// gcpu::vbsll[T]:v128xT->imm8->v128xT
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    /// <typeparam name="T">THe primal component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector128<T> vsll128<T>(Vector128<T> x, [Imm] byte count)
        where T : unmanaged
            => vsll128_u(x,count);

    /// <summary>
    /// Applies a leftward shift to each 128-bit lane at byte-level resolution
    /// gcpu::vbsll[T]:v256xT->imm8->v256xT
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="count">The number of bytes to shift</param>
    /// <typeparam name="T">THe primal component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector256<T> vsll2x128<T>(Vector256<T> x, [Imm] byte count)
        where T : unmanaged
            => vsll2x128_u(x,count);

    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector512<T> vsll4x128<T>(Vector512<T> x, [Imm] byte count)
        where T : unmanaged
            => vsll4x128_u(x,count);

    [MethodImpl(Inline)]
    static Vector128<T> vsll128_u<T>(Vector128<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vsll128(v8u(x), count));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vsll128(v16u(x), count));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vsll128(v32u(x), count));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vsll128(v64u(x), count));
        else
            return vsll128_i(x,count);
    }

    [MethodImpl(Inline)]
    static Vector128<T> vsll128_i<T>(Vector128<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vsll128(v8i(x), count));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vsll128(v16i(x), count));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vsll128(v32i(x), count));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vsll128(v64i(x), count));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static Vector256<T> vsll2x128_u<T>(Vector256<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vsll2x128(v8u(x), count));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vsll2x128(v16u(x), count));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vsll2x128(v32u(x), count));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vsll2x128(v64u(x), count));
        else
            return vsll2x128_i(x,count);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vsll2x128_i<T>(Vector256<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vsll2x128(v8i(x), count));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vsll2x128(v16i(x), count));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vsll2x128(v32i(x), count));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vsll2x128(v64i(x), count));
        else
            throw no<T>();
    }


    [MethodImpl(Inline)]
    static Vector512<T> vsll4x128_u<T>(Vector512<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vsll4x128(v8u(x), count));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vsll4x128(v16u(x), count));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vsll4x128(v32u(x), count));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vsll4x128(v64u(x), count));
        else
            return vsll4x128_i(x,count);
    }

    [MethodImpl(Inline)]
    static Vector512<T> vsll4x128_i<T>(Vector512<T> x, [Imm] byte count)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vsll4x128(v8i(x), count));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vsll4x128(v16i(x), count));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vsll4x128(v32i(x), count));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vsll4x128(v64i(x), count));
        else
            throw no<T>();
    }
}
