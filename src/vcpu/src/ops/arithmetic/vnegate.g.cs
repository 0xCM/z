//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial class vgcpu
{
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static Vector128<T> vnegate<T>(Vector128<T> src)
        where T : unmanaged
            => vnegate_u(src);

    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static Vector256<T> vnegate<T>(Vector256<T> src)
        where T : unmanaged
            => vnegate_u(src);

    [MethodImpl(Inline)]
    static Vector128<T> vnegate_u<T>(Vector128<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vnegate(v8u(x)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vnegate(v16u(x)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vnegate(v32u(x)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vnegate(v64u(x)));
        else
            return vnegate_i(x);
    }

    [MethodImpl(Inline)]
    static Vector128<T> vnegate_i<T>(Vector128<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vnegate(v8i(x)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vnegate(v16i(x)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vnegate(v32i(x)));
        else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vnegate(v64i(x)));
        else
            return gfcpu.vnegate(x);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vnegate_i<T>(Vector256<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
                return generic<T>(vcpu.vnegate(v8i(x)));
        else if(typeof(T) == typeof(short))
                return generic<T>(vcpu.vnegate(v16i(x)));
        else if(typeof(T) == typeof(int))
                return generic<T>(vcpu.vnegate(v32i(x)));
        else if(typeof(T) == typeof(long))
                return generic<T>(vcpu.vnegate(v64i(x)));
        else
            return gfcpu.vnegate(x);
    }


    [MethodImpl(Inline)]
    static Vector256<T> vnegate_u<T>(Vector256<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vnegate(v8u(x)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vnegate(v16u(x)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vnegate(v32u(x)));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vnegate(v64u(x)));
        else
            return vnegate_i(x);
    }
}
