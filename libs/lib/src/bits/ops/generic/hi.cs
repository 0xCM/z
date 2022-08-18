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
        /// Extracts the upper source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Hi, Closures(Closure)]
        public static T hi<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.hi(uint8(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.hi(uint16(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.hi(uint32(src)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.hi(uint64(src)));
            else
                throw no<T>();
        }
    }
}