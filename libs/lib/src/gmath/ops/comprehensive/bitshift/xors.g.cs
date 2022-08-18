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
        /// Computes a ^ ((a << offset) ^ (a >> offset));
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value leftwards</param>
        [MethodImpl(Inline), Xors, Closures(Integers)]
        public static T xors<T>(T a, byte offset)
            where T : unmanaged
                => xors_u(a,offset);

        [MethodImpl(Inline)]
        static T xors_u<T>(T a, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.xors(uint8(a), offset));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.xors(uint16(a), offset));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.xors(uint32(a), offset));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.xors(uint64(a), offset));
            else
                return xors_i(a,offset);
        }

        [MethodImpl(Inline)]
        static T xors_i<T>(T a, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(math.xors(int8(a), offset));
            else if(typeof(T) == typeof(short))
                return generic<T>(math.xors(int16(a), offset));
            else if(typeof(T) == typeof(int))
                return generic<T>(math.xors(int32(a), offset));
            else if(typeof(T) == typeof(long))
                return generic<T>(math.xors(int64(a), offset));
            else
                throw Unsupported.define<T>();
        }
    }
}