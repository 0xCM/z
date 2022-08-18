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
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Impl, Closures(Integers)]
        public static Vector128<T> vimpl<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => vimpl_u(x,y);

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Impl, Closures(Integers)]
        public static Vector256<T> vimpl<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => vimpl_u(x,y);

        /// <summary>
        /// Computes the material implication, x | ~y for vectors x and y
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Impl, Closures(Integers)]
        public static Vector512<T> vimpl<T>(in Vector512<T> x, in Vector512<T> y)
            where T : unmanaged
                => (vimpl(x.Lo, y.Lo), (vimpl(x.Hi, y.Hi)));

        [MethodImpl(Inline)]
        static Vector128<T> vimpl_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vimpl(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vimpl(v16u(x),v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vimpl(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vimpl(v64u(x), v64u(y)));
            else
                return vimpl_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vimpl_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
             if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vimpl(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vimpl(v16i(x),v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vimpl(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vimpl(v64i(x), v64i(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vimpl_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vimpl(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vimpl(v16u(x),v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vimpl(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vimpl(v64u(x), v64u(y)));
            else
                return vimpl_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vimpl_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
             if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vimpl(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vimpl(v16i(x),v16i(y)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vimpl(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vimpl(v64i(x), v64i(y)));
            else
                throw no<T>();
        }
    }
}