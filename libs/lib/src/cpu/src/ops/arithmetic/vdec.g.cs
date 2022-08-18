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
        /// Decrements each component by unit value
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Dec, Closures(Integers)]
        public static Vector128<T> vdec<T>(Vector128<T> src)
            where T : unmanaged
                => vdec_u(src);

        /// <summary>
        /// Decrements each component by unit value
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Dec, Closures(Integers)]
        public static Vector256<T> vdec<T>(Vector256<T> src)
            where T : unmanaged
                => vdec_u(src);

        /// <summary>
        /// Creates a 128-bit vector with components that decrease by unit step from an initial value
        /// </summary>
        /// <param name="first">The value of the first component</param>
        /// <param name="step">The distance between adjacent components</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Dec, Closures(Integers)]
        public static Vector128<T> vdec<T>(N128 n, T first)
            where T : unmanaged
                => vsub(first, vdec<T>(n));

        /// <summary>
        /// Creates a 256-bit vector with components that decrease by unit step from an initial value
        /// </summary>
        /// <param name="first">The value of the first component</param>
        /// <param name="step">The distance between adjacent components</param>
        /// <typeparam name="T">The primal component type</typeparam>
        [MethodImpl(Inline), Dec, Closures(Integers)]
        public static Vector256<T> vdec<T>(N256 n, T first)
            where T : unmanaged
                => vsub(first, vdec<T>(n));

        [MethodImpl(Inline)]
        static Vector128<T> vdec_u<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vdec(v8u(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vdec(v16u(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vdec(v32u(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vdec(v64u(src)));
            else
                return vdec_i(src);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vdec_i<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vdec(v8i(src)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vdec(v16i(src)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vdec(v32i(src)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(cpu.vdec(v64i(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vdec_u<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vdec(v8u(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vdec(v16u(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vdec(v32u(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vdec(v64u(src)));
            else
                return vdec_i(src);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vdec_i<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vdec(v8i(src)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vdec(v16i(src)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vdec(v32i(src)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(cpu.vdec(v64i(src)));
            else
                throw no<T>();
        }
    }
}