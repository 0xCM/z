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
        [MethodImpl(Inline), Divides, Closures(Integers)]
        public static bit divides<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return divides_u(a,b);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return divides_i(a,b);
            else
                return gfp.divides(a,b);
        }

        [MethodImpl(Inline)]
        static bit divides_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return math.divides(int8(a), int8(b));
            else if(typeof(T) == typeof(short))
                 return math.divides(int16(a), int16(b));
            else if(typeof(T) == typeof(int))
                 return math.divides(int32(a), int32(b));
            else
                 return math.divides(int64(a), int64(b));
        }

        [MethodImpl(Inline)]
        static bit divides_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return math.divides(uint8(a), uint8(b));
            else if(typeof(T) == typeof(ushort))
                return math.divides(uint16(a), uint16(b));
            else if(typeof(T) == typeof(uint))
                return math.divides(uint32(a), uint32(b));
            else
                return math.divides(uint64(a), uint64(b));
        }

    }
}