//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct gfp
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T pow<T>(T b, uint exp)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
               return generic<T>(fmath.pow(float32(b), exp));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.pow(float64(b), exp));
            else
               throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T sin<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.sin(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.sin(float64(src)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Raises e to a specified exponent
        /// </summary>
        /// <param name="src">The soruce value</param>
        /// <typeparam name="T">The FP type</typeparam>
        [MethodImpl(Inline), Closures(Closure)]
        public static T exp<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.exp(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.exp(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T sqrt<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.sqrt(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.sqrt(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Sqrt, Closures(Floats)]
        public static Span<T> sqrt<T>(Span<T> src)
            where T : unmanaged
        {
            for(var i=0; i<src.Length; i++)
                seek(src,i) = sqrt(skip(src,i));
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cos<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.cos(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.cos(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T tan<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.tan(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.tan(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T sinh<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.sinh(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.sinh(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cosh<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.cosh(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.cosh(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T tanh<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.tanh(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.tanh(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T asin<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.asin(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.asin(float64(src)));
            else
                throw no<T>();
        }


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T acos<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.acos(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.acos(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T atan<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.atan(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.atan(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T asinh<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.asinh(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.asinh(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T acosh<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.acosh(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.acosh(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T atanh<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.atanh(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.atanh(float64(src)));
            else
                throw no<T>();
        }
    }
}