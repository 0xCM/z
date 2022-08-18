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
        /// Applies a logical left-shift to an integral value
        /// </summary>
        /// <param name="a">The value to shift</param>
        /// <param name="count">The number of bits to shift</param>
        /// <typeparam name="T">The primal integer type</typeparam>
        [MethodImpl(Inline), Sll, Closures(Integers)]
        public static T sll<T>(T a, byte count)
            where T : unmanaged
                => sll_u(a,count);

        [MethodImpl(Inline)]
        static T sll_u<T>(T a, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.sll(uint8(a), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.sll(uint16(a), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.sll(uint32(a), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.sll(uint64(a), count));
            else
                return sll_i(a,count);
        }

        [MethodImpl(Inline)]
        static T sll_i<T>(T a, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.sll(int8(a), count));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.sll(int16(a), count));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.sll(int32(a), count));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.sll(int64(a), count));
            else
                throw no<T>();
        }
    }
}