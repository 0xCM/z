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

    partial class gbits
    {
        /// <summary>
        /// Blends alternating even operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Mix, Closures(Closure)]
        public static T mix<T>(N0 parity, T x, T y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.mix(parity,uint8(x), uint8(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.mix(parity,uint16(x), uint16(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.mix(parity,uint32(x), uint32(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.mix(parity,uint64(x), uint64(y)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Blends alternating odd operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Mix, Closures(Closure)]
        public static T mix<T>(N1 parity, T x, T y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.mix(parity,uint8(x), uint8(y)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.mix(parity,uint16(x), uint16(y)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.mix(parity,uint32(x), uint32(y)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.mix(parity,uint64(x), uint64(y)));
            else
                throw no<T>();
        }
    }
}