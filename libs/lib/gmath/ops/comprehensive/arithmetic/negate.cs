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
        /// If the source value is signed, negates it; otherwise, computes
        /// the two's complement negation
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The primal type</typeparam>
        /// <remarks>See https://en.wikipedia.org/wiki/Two%27s_complement</remarks>
        [MethodImpl(Inline), Negate, Closures(AllNumeric)]
        public static T negate<T>(T src)
            where T : unmanaged
                => negate_u(src);

        [MethodImpl(Inline)]
        static T negate_u<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.negate(uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.negate(uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.negate(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.negate(uint64(src)));
            else
                return negate_i(src);
        }

        [MethodImpl(Inline)]
        static T negate_i<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return generic<T>(math.negate(int8(src)));
            else if(typeof(T) == typeof(short))
                 return generic<T>(math.negate(int16(src)));
            else if(typeof(T) == typeof(int))
                 return generic<T>(math.negate(int32(src)));
            else if(typeof(T) == typeof(long))
                 return generic<T>(math.negate(int64(src)));
            else
                return gfp.negate(src);
        }
    }
}