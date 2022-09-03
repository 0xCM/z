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
        /// Disables the least set bit in the source and is logically equivalent to the composite operation (src - 1) & src
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), LsbOff, Closures(Closure)]
        public static T lsboff<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.lsboff(uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.lsboff(uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.lsboff(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.lsboff(uint64(src)));
            else
                throw no<T>();
        }
    }
}