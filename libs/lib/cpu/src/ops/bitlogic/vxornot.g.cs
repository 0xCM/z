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
        /// Computes x ^ ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), XorNot, Closures(AllNumeric)]
        public static Vector128<T> vxornot<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => vxornot_u(x,y);

        /// <summary>
        /// Computes x ^ ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), XorNot, Closures(AllNumeric)]
        public static Vector256<T> vxornot<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => vxornot_u(x,y);

        [MethodImpl(Inline)]
        static Vector128<T> vxornot_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vxornot(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vxornot(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vxornot(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vxornot(v64u(x), v64u(y)));
            else
                return vxornot_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vxornot_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vxornot(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vxornot(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vxornot(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vxornot(v64i(x), v64i(y)));
            else
                return vxornot_f(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vxornot_f<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vxornot(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vxornot(v64f(x), v64f(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vxornot_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vxornot(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vxornot(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vxornot(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vxornot(v64u(x), v64u(y)));
            else
                return vxornot_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vxornot_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vxornot(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vxornot(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vxornot(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vxornot(v64i(x), v64i(y)));
            else
                return vxornot_f(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vxornot_f<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vxornot(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vxornot(v64f(x), v64f(y)));
            else
                throw Unsupported.define<T>();
        }
    }
}