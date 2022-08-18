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
        [MethodImpl(Inline), Concat, Closures(Closure)]
        public static Vector512<T> vconcat<T>(Vector256<T> a, Vector256<T> b)
            where T : unmanaged
                => new Vector512<T>(a,b);

        [MethodImpl(Inline), Concat, Closures(Closure)]
        public static Vector512<T> vconcat<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c, Vector128<T> d)
            where T : unmanaged
                => new Vector512<T>(a,b,c,d);

        /// <summary>
        /// Creates a 256-bit vector from two 128-bit vectors
        /// This mimics the _mm256_set_m128i intrinsic which does not appear to be available
        /// </summary>
        /// <param name="lo">The lo part</param>
        /// <param name="hi">The hi part</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vconcat<T>(Vector128<T> lo, Vector128<T> hi)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vconcat(v8u(lo), v8u(hi)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vconcat(v16u(lo), v16u(hi)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vconcat(v32u(lo), v32u(hi)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vconcat(v64u(lo), v64u(hi)));
            else
                return vconcat_i(lo,hi);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vconcat_i<T>(Vector128<T> lo, Vector128<T> hi)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vconcat(v8i(lo), v8i(hi)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vconcat(v16i(lo), v16i(hi)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vconcat(v32i(lo), v32i(hi)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vconcat(v64i(lo), v64i(hi)));
            else
                return vconcat_f(lo,hi);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vconcat_f<T>(Vector128<T> lo, Vector128<T> hi)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(cpu.vconcat(v32f(lo), v32f(hi)));
            else if(typeof(T) == typeof(double))
                return generic<T>(cpu.vconcat(v64f(lo), v64f(hi)));
            else
                throw no<T>();
        }
    }
}