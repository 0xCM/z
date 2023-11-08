namespace Z0;

using static sys;
using static vcpu;

partial class vgcpu
{
    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector128<T> vternlog<T>(Vector128<T> x, Vector128<T> y, Vector128<T> z, byte spec)
        where T : unmanaged
            => vternlog_u(x,y,z,spec);

    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector256<T> vternlog<T>(Vector256<T> x, Vector256<T> y, Vector256<T> z, byte spec)
        where T : unmanaged
            => vternlog_u(x,y,z,spec);

    [MethodImpl(Inline), Op, Closures(Integers)]
    public static Vector512<T> vternlog<T>(Vector512<T> x, Vector512<T> y, Vector512<T> z, byte spec)
        where T : unmanaged
            => vternlog_u(x,y,z,spec);

    [MethodImpl(Inline)]
    static Vector128<T> vternlog_u<T>(Vector128<T> x, Vector128<T> y, Vector128<T> z, byte spec)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vternlog(v8u(x), v8u(y), v8u(z), spec));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vternlog(v16u(x), v16u(y), v16u(z), spec));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vternlog(v32u(x), v32u(y), v32u(z), spec));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vternlog(v64u(x), v64u(y), v64u(z), spec));
        else
            return vternlog_i(x, y, z, spec);
    }

    [MethodImpl(Inline)]
    static Vector128<T> vternlog_i<T>(Vector128<T> x, Vector128<T> y, Vector128<T> z, byte spec)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vternlog(v8i(x), v8i(y), v8i(z), spec));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vternlog(v16i(x), v16i(y), v16i(z), spec));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vternlog(v32i(x), v32i(y), v32i(z), spec));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vternlog(v64i(x), v64i(y), v64i(z), spec));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static Vector256<T> vternlog_u<T>(Vector256<T> x, Vector256<T> y, Vector256<T> z, byte spec)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vternlog(v8u(x), v8u(y), v8u(z), spec));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vternlog(v16u(x), v16u(y), v16u(z), spec));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vternlog(v32u(x), v32u(y), v32u(z), spec));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vternlog(v64u(x), v64u(y), v64u(z), spec));
        else
            return vternlog_i(x, y, z, spec);
    }

    [MethodImpl(Inline)]
    static Vector256<T> vternlog_i<T>(Vector256<T> x, Vector256<T> y, Vector256<T> z, byte spec)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vternlog(v8i(x), v8i(y), v8i(z), spec));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vternlog(v16i(x), v16i(y), v16i(z), spec));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vternlog(v32i(x), v32i(y), v32i(z), spec));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vternlog(v64i(x), v64i(y), v64i(z), spec));
        else
            throw no<T>();
    }

    [MethodImpl(Inline)]
    static Vector512<T> vternlog_u<T>(Vector512<T> x, Vector512<T> y, Vector512<T> z, byte spec)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(vcpu.vternlog(v8u(x), v8u(y), v8u(z), spec));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(vcpu.vternlog(v16u(x), v16u(y), v16u(z), spec));
        else if(typeof(T) == typeof(uint))
            return generic<T>(vcpu.vternlog(v32u(x), v32u(y), v32u(z), spec));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(vcpu.vternlog(v64u(x), v64u(y), v64u(z), spec));
        else
            return vternlog_i(x, y, z, spec);
    }

    [MethodImpl(Inline)]
    static Vector512<T> vternlog_i<T>(Vector512<T> x, Vector512<T> y, Vector512<T> z, byte spec)
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>(vcpu.vternlog(v8i(x), v8i(y), v8i(z), spec));
        else if(typeof(T) == typeof(short))
            return generic<T>(vcpu.vternlog(v16i(x), v16i(y), v16i(z), spec));
        else if(typeof(T) == typeof(int))
            return generic<T>(vcpu.vternlog(v32i(x), v32i(y), v32i(z), spec));
        else if(typeof(T) == typeof(long))
            return generic<T>(vcpu.vternlog(v64i(x), v64i(y), v64i(z), spec));
        else
            throw no<T>();
    }
}
