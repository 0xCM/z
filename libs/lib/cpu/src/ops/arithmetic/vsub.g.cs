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
        /// Computes the component-wise difference between two vectors
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Sub, Closures(AllNumeric)]
        public static Vector128<T> vsub<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
                => vsub_u(x,y);

        /// <summary>
        /// Computes the component-wise difference between two vectors
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Sub, Closures(AllNumeric)]
        public static Vector256<T> vsub<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
                => vsub_u(x,y);

        /// <summary>
        /// Subtracts a constant value from each vector component
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="a">The value to add to each component</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Sub, Closures(AllNumeric)]
        public static Vector128<T> vsub<T>(Vector128<T> x, T a)
            where T : unmanaged
                => vsub(x, gcpu.vbroadcast(w128, a));

        /// <summary>
        /// Subtracts each vector component from a constant value
        /// </summary>
        /// <param name="a">The constant</param>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Sub, Closures(AllNumeric)]
        public static Vector128<T> vsub<T>(T a, Vector128<T> x)
            where T : unmanaged
                => vsub(gcpu.vbroadcast(n128,a), x);

        /// <summary>
        /// Subtracts a constant value from each vector component
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="a">The value to add to each component</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Sub, Closures(AllNumeric)]
        public static Vector256<T> vsub<T>(Vector256<T> x, T a)
            where T : unmanaged
                => vsub(x, gcpu.vbroadcast(n256,a));

        /// <summary>
        /// Subtracts each vector component from a constant value
        /// </summary>
        /// <param name="a">The constant</param>
        /// <param name="x">The source vector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Sub, Closures(AllNumeric)]
        public static Vector256<T> vsub<T>(T a, Vector256<T> x)
            where T : unmanaged
                => vsub(gcpu.vbroadcast(w256,a), x);

        [MethodImpl(Inline)]
        static Vector128<T> vsub_u<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vsub(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vsub(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vsub(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vsub(v64u(x), v64u(y)));
            else
                return vsub_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsub_i<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vsub(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vsub(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vsub(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(cpu.vsub(v64i(x), v64i(y)));
            else
                return gfcpu.vsub(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsub_u<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vsub(v8u(x), v8u(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vsub(v16u(x), v16u(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vsub(v32u(x), v32u(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vsub(v64u(x), v64u(y)));
            else
                return vsub_i(x,y);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsub_i<T>(Vector256<T> x, Vector256<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(cpu.vsub(v8i(x), v8i(y)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(cpu.vsub(v16i(x), v16i(y)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(cpu.vsub(v32i(x), v32i(y)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vsub(v64i(x), v64i(y)));
            else
                return gfcpu.vsub(x,y);
        }
    }
}