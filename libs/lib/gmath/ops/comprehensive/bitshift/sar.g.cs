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
        [MethodImpl(Inline), SraAttribute, Closures(Integers)]
        public static T sra<T>(T src, byte offset)
            where T : unmanaged
                => sra_u(src,offset);

        [MethodImpl(Inline)]
        static T sra_u<T>(T src, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.sra(uint8(src), offset));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.sra(uint16(src), offset));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.sra(uint32(src), offset));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.sra(uint64(src), offset));
            else
                return sra_i(src,offset);
        }

        [MethodImpl(Inline)]
        static T sra_i<T>(T src, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.sra(int8(src), offset));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.sra(int16(src), offset));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.sra(int32(src), offset));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.sra(int64(src), offset));
            else
                throw Unsupported.define<T>();
        }
    }
}