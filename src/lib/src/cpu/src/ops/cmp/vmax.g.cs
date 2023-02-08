//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcpu
    {
        [MethodImpl(Inline), Max, Closures(AllNumeric)]
        public static Vector128<T> vmax<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => vmax_u(x,y);

        [MethodImpl(Inline), Max, Closures(AllNumeric)]
        public static Vector256<T> vmax<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => vmax_u(x,y);

        [MethodImpl(Inline)]
        static Vector128<T> vmax_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vmax(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vmax(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vmax(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vmax(v64u(x), v64u(y)));
            else
                return vmax_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vmax_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vmax(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vmax(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vmax(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(cpu.vmax(v64i(x), v64i(y)));
            else
                return gfcpu.vmax(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vmax_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vmax(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vmax(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vmax(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vmax(v64u(x), v64u(y)));
            else
                return vmax_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vmax_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vmax(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vmax(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vmax(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(cpu.vmax(v64i(x), v64i(y)));
            else
                return gfcpu.vmax(x,y);
        }
    }
}