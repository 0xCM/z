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
        /// Computes the position of the highest enabled source bit, a number in the inclusive range [0 , bitsize[T] - 1]
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Msb, Closures(Closure)]
        public static byte msb<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return bits.msb(uint8(src));
            else if(typeof(T) == typeof(ushort))
                return bits.msb(uint16(src));
            else if(typeof(T) == typeof(uint))
                return bits.msb(uint32(src));
            else if(typeof(T) == typeof(ulong))
                return bits.msb(uint64(src));
            else
                throw no<T>();
        }
    }
}