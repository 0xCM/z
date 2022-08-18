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
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), NonImpl, Closures(Integers)]
        public static Vector128<T> vnonimpl<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => vnonimpl_u(x,y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), NonImpl, Closures(Integers)]
        public static Vector256<T> vnonimpl<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => vnonimpl_u(x,y);

        /// <summary>
        /// Computes the material nomimplication, ~x & y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), NonImpl, Closures(Integers)]
        public static Vector512<T> vnonimpl<T>(in Vector512<T> x, in Vector512<T> y)
            where T : unmanaged
                => (vnonimpl(x.Lo, y.Lo), (vnonimpl(x.Hi, y.Hi)));

        [MethodImpl(Inline)]
        static Vector128<T> vnonimpl_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vnonimpl(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vnonimpl(v16u(x),v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vnonimpl(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vnonimpl(v64u(x), v64u(y)));
            else
                return vnonimpl_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vnonimpl_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vnonimpl(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vnonimpl(v16i(x),v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vnonimpl(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vnonimpl(v64i(x), v64i(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vnonimpl_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vnonimpl(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vnonimpl(v16u(x),v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vnonimpl(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vnonimpl(v64u(x), v64u(y)));
            else
                return vnonimpl_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vnonimpl_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vnonimpl(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vnonimpl(v16i(x),v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vnonimpl(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vnonimpl(v64i(x), v64i(y)));
            else
                throw no<T>();
        }
    }
}