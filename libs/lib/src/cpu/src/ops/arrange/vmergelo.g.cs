//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector128<T> vmergelo<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vmergelo_u(x,y);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vmergelo_i(x,y);
            else
                throw no<T>();
        }

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector256<T> vmergelo<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vmergelo_u(x,y);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vmergelo_i(x,y);
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector128<T> vmergelo_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vmergelo(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vmergelo(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vmergelo(v32i(x), v32i(y)));
            else
                 return generic<T>(cpu.vmergelo(v64i(x), v64i(y)));
        }

        [MethodImpl(Inline)]
        static Vector128<T> vmergelo_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vmergelo(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vmergelo(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vmergelo(v32u(x), v32u(y)));
            else
                return generic<T>(cpu.vmergelo(v64u(x), v64u(y)));
        }

        [MethodImpl(Inline)]
        static Vector256<T> vmergelo_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vmergelo(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vmergelo(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vmergelo(v32i(x), v32i(y)));
            else
                 return generic<T>(cpu.vmergelo(v64i(x), v64i(y)));
        }

        [MethodImpl(Inline)]
        static Vector256<T> vmergelo_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vmergelo(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vmergelo(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vmergelo(v32u(x), v32u(y)));
            else
                return generic<T>(cpu.vmergelo(v64u(x), v64u(y)));
        }
    }
}