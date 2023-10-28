
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
    /// Moves the hi 64 bits of the source vector the the lo 64 bits of a target vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <typeparam name="T">The vector component type</typeparam>
    [MethodImpl(Inline), Op, Closures(AllNumeric)]
    public static Vector128<T> vhi<T>(Vector128<T> src)
        where T : unmanaged
            => generic<T>(vcpu.vscalar(w128, vcpu.vcell(v64u(src),1)));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> vhi<T>(Vector256<T> src)
        where T : unmanaged
            => Vector256.GetUpper(src);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector256<T> vhi<T>(Vector512<T> src)
        where T : unmanaged
            => vhi_i(src);

    [MethodImpl(Inline)]
    static Vector256<T> vhi_i<T>(Vector512<T> src)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vhi(v8i(src)));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vhi(v16i(src)));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vhi(v32i(src)));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vhi(v64i(src)));
        else
            return vhi_u(src);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vhi_u<T>(Vector512<T> src)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vhi(v8u(src)));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vhi(v16u(src)));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vhi(v32u(src)));
        else  if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vhi(v64u(src)));
        else 
            throw no<T>();
    }

}
