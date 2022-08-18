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
        /// Computes the average of unsigned integral operands, rounding toward zero
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Avgz, Closures(UnsignedInts)]
        public static T avgz<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.avgz(uint8(a), uint8(b)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.avgz(uint16(a), uint16(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.avgz(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.avgz(uint64(a), uint64(b)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Computes the average of unsigned integral operands, rounding toward infinity
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static T avgi<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.avgi(uint8(a), uint8(b)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.avgi(uint16(a), uint16(b)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.avgi(uint32(a), uint32(b)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.avgi(uint64(a), uint64(b)));
            else
                throw no<T>();
        }
    }
}
