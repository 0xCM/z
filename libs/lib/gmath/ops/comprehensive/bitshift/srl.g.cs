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
        /// Applies a logical right-shift to an integral value
        /// </summary>
        /// <param name="a">The value to shift</param>
        /// <param name="count">The number of bits to shift</param>
        /// <typeparam name="T">The primal integer type</typeparam>
        [MethodImpl(Inline), Srl, Closures(Integers)]
        public static T srl<T>(T a, byte count)
            where T : unmanaged
                => srl_u(a,count);

        [MethodImpl(Inline)]
        static T srl_u<T>(T a, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.srl(uint8(a), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.srl(uint16(a), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.srl(uint32(a), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.srl(uint64(a), count));
            else
                return srl_i(a,count);
        }

        [MethodImpl(Inline)]
        static T srl_i<T>(T a, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.srl(int8(a), count));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.srl(int16(a), count));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.srl(int32(a), count));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.srl(int64(a), count));
            else
                throw Unsupported.define<T>();
        }
    }
}