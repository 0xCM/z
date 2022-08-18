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
        /// Applies an arithmetic left-shift to an integer
        /// </summary>
        /// <param name="src">The value to shift</param>
        /// <param name="offset">The number of bits to shift</param>
        /// <typeparam name="T">The primal integer type</typeparam>
        [MethodImpl(Inline), Sal, Closures(Integers)]
        public static T sal<T>(T src, byte offset)
            where T : unmanaged
                => sal_u(src,offset);

        [MethodImpl(Inline)]
        static T sal_u<T>(T src, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.sal(uint8(src), offset));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.sal(uint16(src), offset));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.sal(uint32(src), offset));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.sal(uint64(src), offset));
            else
                return sal_i(src,offset);
        }

        [MethodImpl(Inline)]
        static T sal_i<T>(T src, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.sal(int8(src), offset));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.sal(int16(src), offset));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.sal(int32(src), offset));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.sal(int64(src), offset));
            else
                throw no<T>();
        }
    }
}