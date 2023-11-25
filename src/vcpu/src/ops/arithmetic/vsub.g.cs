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
    /// Computes the component-wise difference between two vectors
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Sub, Closures(Integers)]
    public static Vector128<T> vsub<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
            => vsub_u(x,y);

    /// <summary>
    /// Computes the component-wise difference between two vectors
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Sub, Closures(Integers)]
    public static Vector256<T> vsub<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
            => vsub_u(x,y);

    /// <summary>
    /// Computes the component-wise difference between two vectors
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Sub, Closures(Integers)]
    public static Vector512<T> vsub<T>(Vector512<T> x, Vector512<T> y)
        where T : unmanaged
            => vsub_u(x,y);

    /// <summary>
    /// Subtracts a constant value from each vector component
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="a">The value to add to each component</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Sub, Closures(Integers)]
    public static Vector128<T> vsub<T>(Vector128<T> x, T a)
        where T : unmanaged
            => vsub(x, vbroadcast(w128, a));

    /// <summary>
    /// Subtracts each vector component from a constant value
    /// </summary>
    /// <param name="a">The constant</param>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Sub, Closures(Integers)]
    public static Vector128<T> vsub<T>(T a, Vector128<T> x)
        where T : unmanaged
            => vsub(vbroadcast(n128,a), x);

    /// <summary>
    /// Subtracts a constant value from each vector component
    /// </summary>
    /// <param name="x">The source vector</param>
    /// <param name="a">The value to add to each component</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Sub, Closures(Integers)]
    public static Vector256<T> vsub<T>(Vector256<T> x, T a)
        where T : unmanaged
            => vsub(x, vbroadcast(n256,a));

    /// <summary>
    /// Subtracts each vector component from a constant value
    /// </summary>
    /// <param name="a">The constant</param>
    /// <param name="x">The source vector</param>
    /// <typeparam name="T">The cell type</typeparam>
    [MethodImpl(Inline), Sub, Closures(Integers)]
    public static Vector256<T> vsub<T>(T a, Vector256<T> x)
        where T : unmanaged
            => vsub(vbroadcast(w256,a), x);

    [MethodImpl(Inline)]
    static Vector128<T> vsub_u<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vsub(v8u(x), v8u(y)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vsub(v16u(x), v16u(y)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vsub(v32u(x), v32u(y)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vsub(v64u(x), v64u(y)));
        else
            return vsub_i(x,y);
    }

    [MethodImpl(Inline)]
    static Vector128<T> vsub_i<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsub(v8i(x), v8i(y)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsub(v16i(x), v16i(y)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsub(v32i(x), v32i(y)));
        else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vsub(v64i(x), v64i(y)));
        else
            return gfcpu.vsub(x,y);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vsub_u<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vsub(v8u(x), v8u(y)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vsub(v16u(x), v16u(y)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vsub(v32u(x), v32u(y)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vsub(v64u(x), v64u(y)));
        else
            return vsub_i(x,y);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vsub_i<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsub(v8i(x), v8i(y)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsub(v16i(x), v16i(y)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsub(v32i(x), v32i(y)));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vsub(v64i(x), v64i(y)));
        else
            return gfcpu.vsub(x,y);
    }


    [MethodImpl(Inline)]
    static Vector512<T> vsub_u<T>(Vector512<T> x, Vector512<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vsub(v8u(x), v8u(y)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vsub(v16u(x), v16u(y)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vsub(v32u(x), v32u(y)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vsub(v64u(x), v64u(y)));
        else
            return vsub_i(x,y);
    }

    [MethodImpl(Inline)]
    static Vector512<T> vsub_i<T>(Vector512<T> x, Vector512<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vsub(v8i(x), v8i(y)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vsub(v16i(x), v16i(y)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vsub(v32i(x), v32i(y)));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vsub(v64i(x), v64i(y)));
        else
            throw no<T>();
    }
}
