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
        /// Returns an alternate value if the nonz test succeeds for the source value
        /// </summary>
        /// <param name="src">The test value</param>
        /// <param name="alt">The alternative value to return if the test succeeds</param>
        /// <typeparam name="T">The source numeric type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T nonz<T>(T src, T alt)
            where T : unmanaged
                => nonz_u(src, alt);

        [MethodImpl(Inline)]
        static T nonz_u<T>(T a, T alt)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                 return generic<T>(math.nonz(uint8(a), uint8(alt)));
            else if(typeof(T) == typeof(ushort))
                 return generic<T>(math.nonz(uint16(a), uint16(alt)));
            else if(typeof(T) == typeof(uint))
                 return generic<T>(math.nonz(uint32(a), uint32(alt)));
            else if(typeof(T) == typeof(ulong))
                 return generic<T>(math.nonz(uint64(a), uint64(alt)));
            else
                return nonz_i(a, alt);
        }

        [MethodImpl(Inline)]
        static T nonz_i<T>(T a, T alt)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.nonz(int8(a), int8(alt)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.nonz(int16(a), int16(alt)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.nonz(int32(a), int32(alt)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.nonz(int64(a), int64(alt)));
            else
                return nonz_f(a,alt);
        }

        [MethodImpl(Inline)]
        static T nonz_f<T>(T a, T alt)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.nonz(float32(a),float32(alt)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.nonz(float64(a),float64(alt)));
            else
                throw no<T>();
        }
    }
}