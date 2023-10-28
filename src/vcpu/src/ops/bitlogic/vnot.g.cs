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
    /// Computes the bitwise complement ~x for a vector x
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The component type</typeparam>
    [MethodImpl(Inline), Not, Closures(Integers)]
    public static Vector128<T> vnot<T>(Vector128<T> x)
        where T : unmanaged
            => vnot_u(x);

    /// <summary>
    /// Computes the bitwise complement ~x for a vector x
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The component type</typeparam>
    [MethodImpl(Inline), Not, Closures(Integers)]
    public static Vector256<T> vnot<T>(Vector256<T> x)
        where T : unmanaged
            => vnot_u(x);

    /// <summary>
    /// Computes the bitwise complement ~x for a vector x
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The component type</typeparam>
    [MethodImpl(Inline), Not, Closures(Integers)]
    public static Vector512<T> vnot<T>(Vector512<T> x)
        where T : unmanaged
            => vnot_u(x);

    [MethodImpl(Inline)]
    static Vector128<T> vnot_u<T>(Vector128<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vnot(v8u(x)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vnot(v16u(x)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vnot(v32u(x)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vnot(v64u(x)));
        else
            return vnot_i(x);
    }

    [MethodImpl(Inline)]
    static Vector128<T> vnot_i<T>(Vector128<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vnot(v8i(x)));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vnot(v16i(x)));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vnot(v32i(x)));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vnot(v64i(x)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static Vector256<T> vnot_u<T>(Vector256<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vnot(v8u(x)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vnot(v16u(x)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vnot(v32u(x)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vnot(v64u(x)));
        else
            return vnot_i(x);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vnot_i<T>(Vector256<T> x)
        where T : unmanaged
    {
            if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vnot(v8i(x)));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vnot(v16i(x)));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vnot(v32i(x)));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vnot(v64i(x)));
        else
            throw no<T>();
    }


    [MethodImpl(Inline)]
    static Vector512<T> vnot_u<T>(Vector512<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vnot(v8u(x)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vnot(v16u(x)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vnot(v32u(x)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vnot(v64u(x)));
        else
            return vnot_i(x);
    }

    [MethodImpl(Inline)]
    static Vector512<T> vnot_i<T>(Vector512<T> x)
        where T : unmanaged
    {
            if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vnot(v8i(x)));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vnot(v16i(x)));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vnot(v32i(x)));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vnot(v64i(x)));
        else
            throw no<T>();
    }

}
