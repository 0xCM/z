//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial class vgcpu
{
    [MethodImpl(Inline), Abs, Closures(SignedInts)]
    public static Vector128<T> vabs<T>(Vector128<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vabs(v8i(x)));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vabs(v16i(x)));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vabs(v32i(x)));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vabs(v64i(x)));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Abs, Closures(SignedInts)]
    public static Vector256<T> vabs<T>(Vector256<T> x)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vabs(v8i(x)));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vabs(v16i(x)));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vabs(v32i(x)));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vabs(v64i(x)));
        else
            throw no<T>();
    }
}

