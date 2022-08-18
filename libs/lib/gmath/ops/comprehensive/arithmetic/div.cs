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
        /// Divides the first value by the second
        /// </summary>
        /// <param name="a">The left value</param>
        /// <param name="b">The right value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Div, Closures(AllNumeric)]
        public static T div<T>(T a, T b)
            where T : unmanaged
                => div_u(a,b);

        [MethodImpl(Inline)]
        static T div_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.div(uint8(a), uint8(b)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.div(uint16(a), uint16(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.div(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.div(uint64(a), uint64(b)));
            else
                return div_i(a,b);
        }

        [MethodImpl(Inline)]
        static T div_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.div(int8(a), int8(b)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.div(int16(a), int16(b)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.div(int32(a), int32(b)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.div(int64(a), int64(b)));
            else
                return gfp.div(a,b);
        }
    }
}
