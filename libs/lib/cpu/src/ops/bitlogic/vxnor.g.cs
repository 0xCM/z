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
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor, Closures(AllNumeric)]
        public static Vector128<T> vxnor<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => vxnor_u(x,y);

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xnor, Closures(AllNumeric)]
        public static Vector256<T> vxnor<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => vxnor_u(x,y);

        /// <summary>
        /// Computes ~ (x ^ y) for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Xnor, Closures(NumericKind.Integers)]
        public static Vector512<T> vxnor<T>(in Vector512<T> x, in Vector512<T> y)
            where T : unmanaged
                => (vxnor(x.Lo,y.Lo), (vxnor(x.Hi, y.Hi)));

        [MethodImpl(Inline)]
        static Vector128<T> vxnor_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vxnor(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vxnor(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vxnor(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vxnor(v64u(x), v64u(y)));
            else
                return vxnor_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vxnor_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vxnor(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vxnor(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vxnor(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vxnor(v64i(x), v64i(y)));
            else
                return vxnor_f(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vxnor_f<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vxnor(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vxnor(v64f(x), v64f(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vxnor_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vxnor(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vxnor(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vxnor(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vxnor(v64u(x), v64u(y)));
            else
                return vxnor_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vxnor_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vxnor(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vxnor(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vxnor(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vxnor(v64i(x), v64i(y)));
            else
                return vxnor_f(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vxnor_f<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vxnor(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vxnor(v64f(x), v64f(y)));
            else
                throw no<T>();
        }
    }
}