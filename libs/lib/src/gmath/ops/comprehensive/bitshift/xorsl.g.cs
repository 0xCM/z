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
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSl, Closures(UnsignedInts)]
        public static T xorsl<T>(T a, byte offset)
            where T : unmanaged
                => xorsl_u(a,offset);

        [MethodImpl(Inline)]
        static T xorsl_u<T>(T a, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.xorsl(uint8(a), offset));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.xorsl(uint16(a), offset));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.xorsl(uint32(a), offset));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.xorsl(uint64(a), offset));
            else
                return xorsl_i(a,offset);
        }

        [MethodImpl(Inline)]
        static T xorsl_i<T>(T a, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(math.xorsl(int8(a), offset));
            else if(typeof(T) == typeof(short))
                return generic<T>(math.xorsl(int16(a), offset));
            else if(typeof(T) == typeof(int))
                return generic<T>(math.xorsl(int32(a), offset));
            else if(typeof(T) == typeof(long))
                return generic<T>(math.xorsl(int64(a), offset));
            else
                throw Unsupported.define<T>();
        }
    }
}