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
        /// Counts the number of leading zero bits the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Nlz, Closures(Closure)]
        public static byte nlz<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                 return bits.nlz(uint8(src));
            else if(typeof(T) == typeof(ushort))
                 return bits.nlz(uint16(src));
            else if(typeof(T) == typeof(uint))
                 return bits.nlz(uint32(src));
            else if(typeof(T) == typeof(ulong))
                 return bits.nlz(uint64(src));
            else
                throw no<T>();
        }
    }
}