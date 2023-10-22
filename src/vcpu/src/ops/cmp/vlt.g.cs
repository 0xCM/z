//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using static vcpu;

partial class vgcpu
{
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector128<T> vlt<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
            => vlt_u(x,y);

    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector256<T> vlt<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
            => vlt_u(x,y);

    [MethodImpl(Inline)]
    static Vector128<T> vlt_u<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vlt(v8u(x), v8u(y)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vlt(v16u(x), v16u(y)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vlt(v32u(x), v32u(y)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vlt(v64u(x), v64u(y)));
        else
            return vlt_i(x,y);
    }

    [MethodImpl(Inline)]
    static Vector128<T> vlt_i<T>(Vector128<T> x, Vector128<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vlt(v8i(x), v8i(y)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vlt(v16i(x), v16i(y)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vlt(v32i(x), v32i(y)));
        else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vlt(v64i(x), v64i(y)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static Vector256<T> vlt_u<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vlt(v8u(x), v8u(y)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vlt(v16u(x), v16u(y)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vlt(v32u(x), v32u(y)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vlt(v64u(x), v64u(y)));
        else
            return vlt_i(x,y);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vlt_i<T>(Vector256<T> x, Vector256<T> y)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vlt(v8i(x), v8i(y)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vlt(v16i(x), v16i(y)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vlt(v32i(x), v32i(y)));
        else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vlt(v64i(x), v64i(y)));
        else
            throw no<T>();
    }
}
