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
        /// Defines the test nonz:bit := a != 0, succeeding if the source operand is nonzero
        /// </summary>
        /// <param name="src">The source operand</param>
        /// <typeparam name="T">The operand type</typeparam>
        [MethodImpl(Inline), Nonz, Closures(AllNumeric)]
        public static bit nonz<T>(T src)
            where T : unmanaged
                => nonz_u(src);

        [MethodImpl(Inline)]
        static bit nonz_u<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                 return math.nonz(uint8(a));
            else if(typeof(T) == typeof(ushort))
                 return math.nonz(uint16(a));
            else if(typeof(T) == typeof(uint))
                 return math.nonz(uint32(a));
            else if(typeof(T) == typeof(ulong))
                 return math.nonz(uint64(a));
            else
                return nonz_i(a);
        }

        [MethodImpl(Inline)]
        static bit nonz_i<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                 return math.nonz(int8(a));
            else if(typeof(T) == typeof(short))
                 return math.nonz(int16(a));
            else if(typeof(T) == typeof(int))
                 return math.nonz(int32(a));
            else if(typeof(T) == typeof(long))
                 return math.nonz(int64(a));
            else
                return gfp.nonz(a);
        }
    }
}