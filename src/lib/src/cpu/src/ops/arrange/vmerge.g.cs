//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcpu
    {
        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vmerge<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vmerge_u(x,y);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vmerge_i(x,y);
            else
                throw no<T>();
        }

        /// <summary>
        /// [A,B,C,D] x [E,F,G,H] -> [A,E,B,F,C,G,D,H]
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector512<T> vmerge<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vmerge_u(x,y);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vmerge_i(x,y);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector512<T> vmerge_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vmerge(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vmerge(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vmerge(v32i(x), v32i(y)));
            else
                 return generic<T>(cpu.vmerge(v64i(x), v64i(y)));
        }

        [MethodImpl(Inline)]
        static Vector512<T> vmerge_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vmerge(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vmerge(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vmerge(v32u(x), v32u(y)));
            else
                return generic<T>(cpu.vmerge(v64u(x), v64u(y)));
        }

        [MethodImpl(Inline)]
        static Vector256<T> vmerge_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vmerge(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vmerge(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vmerge(v32i(x), v32i(y)));
            else
                 return generic<T>(cpu.vmerge(v64i(x), v64i(y)));
        }

        [MethodImpl(Inline)]
        static Vector256<T> vmerge_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vmerge(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vmerge(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vmerge(v32u(x), v32u(y)));
            else
                return generic<T>(cpu.vmerge(v64u(x), v64u(y)));
        }
    }
}