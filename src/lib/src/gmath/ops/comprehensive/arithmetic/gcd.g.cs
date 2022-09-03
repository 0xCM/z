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
        [MethodImpl(Inline), Closures(Integers)]
        public static T gcd<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return gcd_u(a,b);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return gcd_i(a,b);
            else
                return gcd_f(a,b);
        }

        [MethodImpl(Inline), Closures(UnsignedInts)]
        public static T gcdbin<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>((math.gcdbin(uint8(a), uint8(b))));
            else if(typeof(T) == typeof(ushort))
                return generic<T>((math.gcdbin(uint16(a), uint16(b))));
            else if(typeof(T) == typeof(uint))
                return generic<T>((math.gcdbin(uint32(a), uint32(b))));
            else if(typeof(T) == typeof(ulong))
                return generic<T>((math.gcdbin(uint64(a), uint64(b))));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static T gcd_i<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>((math.gcd(int8(a), int8(b))));
            else if(typeof(T) == typeof(short))
                return generic<T>((math.gcd(int16(a), int16(b))));
            else if(typeof(T) == typeof(int))
                return generic<T>((math.gcd(int32(a), int32(b))));
            else
                return generic<T>((math.gcd(int64(a), int64(b))));
        }

        [MethodImpl(Inline)]
        static T gcd_u<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>((math.gcd(uint8(a), uint8(b))));
            else if(typeof(T) == typeof(ushort))
                return generic<T>((math.gcd(uint16(a), uint16(b))));
            else if(typeof(T) == typeof(uint))
                return generic<T>((math.gcd(uint32(a), uint32(b))));
            else
                return generic<T>((math.gcd(uint64(a), uint64(b))));
        }

        [MethodImpl(Inline)]
        static T gcd_f<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>((fmath.gcd(float32(a), float32(b))));
            else if(typeof(T) == typeof(double))
                return generic<T>((fmath.gcd(float64(a), float64(b))));
            else
                throw Unsupported.define<T>();
        }


   }

}