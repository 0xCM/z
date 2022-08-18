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

    partial class gmath
    {
        /// <summary>
        /// Defines the test t:bit = src < 0
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Negative, Closures(Integers | Floats)]
        public static bit negative<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return math.negative(int8(src));
            else if(typeof(T) == typeof(short))
                return math.negative(int16(src));
            else if(typeof(T) == typeof(int))
                return math.negative(int32(src));
            else if(typeof(T) == typeof(long))
                return math.negative(int64(src));
            else if(typeof(T) == typeof(float))
                return fmath.negative(float32(src));
            else if(typeof(T) == typeof(double))
                return fmath.negative(float64(src));
            else
                 return false;
       }
    }
}