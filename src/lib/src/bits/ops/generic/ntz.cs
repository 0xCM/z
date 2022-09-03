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
        /// Counts the number of trailing zero bits in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Ntz, Closures(Closure)]
        public static T ntz<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                 return generic<T>(bits.ntz(uint8(src)));
            else if(typeof(T) == typeof(ushort))
                 return generic<T>(bits.ntz(uint16(src)));
            else if(typeof(T) == typeof(uint))
                 return generic<T>(bits.ntz(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                 return generic<T>(bits.ntz(uint64(src)));
            else
                throw no<T>();
        }
    }
}