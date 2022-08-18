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
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Clamp, Closures(Integers)]
        public static T clamp<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.clamp(uint8(a), uint8(b)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.clamp(uint16(a), uint16(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.clamp(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.clamp(uint64(a), uint64(b)));
            else
                return clamp_i(a,b);
        }

        [MethodImpl(Inline)]
        static T clamp_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(math.clamp(int8(a), int8(b)));
            else if(typeof(T) == typeof(short))
                return generic<T>(math.clamp(int16(a), int16(b)));
            else if(typeof(T) == typeof(int))
                return generic<T>(math.clamp(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                return generic<T>(math.clamp(int64(a), int64(b)));
            else
                return clamp_f(a,b);
        }

        [MethodImpl(Inline)]
        static T clamp_f<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.clamp(float32(a), float32(b)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.clamp(float64(a), float64(b)));
            else
                throw no<T>();
        }
    }
}
