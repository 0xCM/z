//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;
using static CpuBytes;

partial class vgcpu
{
    /// <summary>
    /// Decrements each component by unit value
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The component type</typeparam>
    [MethodImpl(Inline), Dec, Closures(Integers)]
    public static Vector128<T> vdec<T>(Vector128<T> src)
        where T : unmanaged
            => vdec_u(src);

    /// <summary>
    /// Decrements each component by unit value
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The component type</typeparam>
    [MethodImpl(Inline), Dec, Closures(Integers)]
    public static Vector256<T> vdec<T>(Vector256<T> src)
        where T : unmanaged
            => vdec_u(src);

    /// <summary>
    /// Creates a 128-bit vector with components that decrease by unit step from an initial value
    /// </summary>
    /// <param name="first">The value of the first component</param>
    /// <param name="step">The distance between adjacent components</param>
    /// <typeparam name="T">The primal component type</typeparam>
    [MethodImpl(Inline), Dec, Closures(Integers)]
    public static Vector128<T> vdec<T>(N128 n, T first)
        where T : unmanaged
            => vsub(first, vdec<T>(n));

    /// <summary>
    /// Creates a 256-bit vector with components that decrease by unit step from an initial value
    /// </summary>
    /// <param name="first">The value of the first component</param>
    /// <param name="step">The distance between adjacent components</param>
    /// <typeparam name="T">The primal component type</typeparam>
    [MethodImpl(Inline), Dec, Closures(Integers)]
    public static Vector256<T> vdec<T>(N256 n, T first)
        where T : unmanaged
            => vsub(first, vdec<T>(n));

    /// <summary>
    /// Creates a 128-bit vector with component values k - 1, ..., 1, 0  where k is the length of the target vector
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector128<T> vdec<T>(N128 w)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
            return vgcpu.vload<T>(w, Dec128x8u);
        else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
            return vgcpu.vload<T>(w, Dec128x16u);
        else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int))
            return vgcpu.vload<T>(w, Dec128x32u);
        else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
            return vgcpu.vload<T>(w, Dec128x64u);
        else
            throw no<T>();
    }

    /// <summary>
    /// Creates a 256-bit vector with component values k - 1, ..., 1, 0  where k is the length of the target vector
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(Integers)]
    public  static Vector256<T> vdec<T>(N256 w)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte) || typeof(T) == typeof(sbyte))
            return vgcpu.vload<T>(w,Dec256x8u);
        else if(typeof(T) == typeof(ushort) || typeof(T) == typeof(short))
            return vgcpu.vload<T>(w,Dec256x16u);
        else if(typeof(T) == typeof(uint) || typeof(T) == typeof(int))
            return vgcpu.vload<T>(w,Dec256x32u);
        else if(typeof(T) == typeof(ulong) || typeof(T) == typeof(long))
            return vgcpu.vload<T>(w,Dec256x64u);
        else
            throw no<T>();
    }
    
    [MethodImpl(Inline)]
    static Vector128<T> vdec_u<T>(Vector128<T> src)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vdec(v8u(src)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vdec(v16u(src)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vdec(v32u(src)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vdec(v64u(src)));
        else
            return vdec_i(src);
    }

    [MethodImpl(Inline)]
    static Vector128<T> vdec_i<T>(Vector128<T> src)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vdec(v8i(src)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vdec(v16i(src)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vdec(v32i(src)));
        else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vdec(v64i(src)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static Vector256<T> vdec_u<T>(Vector256<T> src)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vdec(v8u(src)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vdec(v16u(src)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vdec(v32u(src)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vdec(v64u(src)));
        else
            return vdec_i(src);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vdec_i<T>(Vector256<T> src)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vdec(v8i(src)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vdec(v16i(src)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vdec(v32i(src)));
        else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vdec(v64i(src)));
        else
            throw no<T>();
    }
}
