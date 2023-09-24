//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

/// <summary>
/// Generic intrinsics over floating-point domains
/// </summary>
[ApiHost]
public readonly struct gfcpu
{
    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vadd<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vadd(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vadd(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vadd<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vadd(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vadd(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vsub<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(fcpu.vsub(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(fcpu.vsub(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vsub<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(fcpu.vsub(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(fcpu.vsub(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vhadd<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(fcpu.vhadd(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(fcpu.vhadd(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vhadd<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(fcpu.vhadd(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(fcpu.vhadd(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vdiv<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(fcpu.vdiv(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(fcpu.vdiv(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vdiv<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(fcpu.vdiv(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(fcpu.vdiv(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vand<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vand(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vand(v64f(x), v64f(y)));
        else
            throw no<T>();

    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vand<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vand(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vand(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vor<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vor(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vor(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vor<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vor(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vor(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vxor<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vxor(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vxor(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vxor<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vxor(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vxor(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vxornot<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vxornot(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vxornot(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vxornot<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vxornot(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vxornot(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vmin<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vmin(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vmin(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vmin<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vmin(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vmin(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vmax<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vmax(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vmax(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vmax<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vmax(v32f(x), v32f(y)));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vmax(v64f(x), v64f(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector128<T> vnegate<T>(Vector128<T> src)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(fcpu.vnegate(v32f(src)));
        else if(typeof(T) == typeof(double))
            return generic<T>(fcpu.vnegate(v64f(src)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Op, Closures(Floats)]
    public static Vector256<T> vnegate<T>(Vector256<T> src)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(fcpu.vnegate(v32f(src)));
        else if(typeof(T) == typeof(double))
            return generic<T>(fcpu.vnegate(v64f(src)));
        else
            throw no<T>();
    }

    /// <summary>
    /// Defines a vector of 32 or 64-bit floating point values where each component has been intialized to the value -0.0
    /// </summary>
    /// <typeparam name="T">The floating point type</typeparam>
    [MethodImpl(Inline)]
    public static Vector256<T> vfpsign<T>(N256 n)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(vcpu.vbroadcast(w256,-0.0f));
        else if(typeof(T) == typeof(double))
            return generic<T>(vcpu.vbroadcast(w256,-0.0));
        else
            throw no<T>();
    }
}
