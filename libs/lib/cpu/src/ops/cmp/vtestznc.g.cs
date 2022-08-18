//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcpu
    {
        [MethodImpl(Inline), TestZnC, Closures(AllNumeric)]
        public static bit vtestznc<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
                => vtestznc_u(src,mask);

        [MethodImpl(Inline), TestZnC, Closures(AllNumeric)]
        public static bit vtestznc<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
                => vtestznc_u(src,mask);

        [MethodImpl(Inline)]
        static bit vtestznc_u<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return cpu.vtestznc(v8u(src), v8u(mask));
            else if(typeof(T) == typeof(ushort))
                return cpu.vtestznc(v16u(src), v16u(mask));
            else if(typeof(T) == typeof(uint))
                return cpu.vtestznc(v32u(src), v32u(mask));
            else if(typeof(T) == typeof(ulong))
                return cpu.vtestznc(v64u(src), v64u(mask));
            else
                return vtestznc_i(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestznc_i<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return cpu.vtestznc(v8i(src), v8i(mask));
            else if(typeof(T) == typeof(short))
                return cpu.vtestznc(v16i(src), v16i(mask));
            else if(typeof(T) == typeof(int))
                return cpu.vtestznc(v32i(src), v32i(mask));
            else if(typeof(T) == typeof(long))
                return cpu.vtestznc(v64i(src), v64i(mask));
            else
                return vtestznc_f(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestznc_f<T>(Vector128<T> src, Vector128<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return cpu.vtestznc(v32f(src), v32f(mask));
            else if(typeof(T) == typeof(double))
                return cpu.vtestznc(v64f(src), v64f(mask));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static bit vtestznc_u<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return cpu.vtestznc(v8u(src), v8u(mask));
            else if(typeof(T) == typeof(ushort))
                return cpu.vtestznc(v16u(src), v16u(mask));
            else if(typeof(T) == typeof(uint))
                return cpu.vtestznc(v32u(src), v32u(mask));
            else if(typeof(T) == typeof(ulong))
                return cpu.vtestznc(v64u(src), v64u(mask));
            else
                return vtestznc_i(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestznc_i<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return cpu.vtestznc(v8i(src), v8i(mask));
            else if(typeof(T) == typeof(short))
                return cpu.vtestznc(v16i(src), v16i(mask));
            else if(typeof(T) == typeof(int))
                return cpu.vtestznc(v32i(src), v32i(mask));
            else if(typeof(T) == typeof(long))
                return cpu.vtestznc(v64i(src), v64i(mask));
            else
                return vtestznc_f(src,mask);
        }

        [MethodImpl(Inline)]
        static bit vtestznc_f<T>(Vector256<T> src, Vector256<T> mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return cpu.vtestznc(v32f(src), v32f(mask));
            else if(typeof(T) == typeof(double))
                return cpu.vtestznc(v64f(src), v64f(mask));
            else
                throw no<T>();
        }
    }
}