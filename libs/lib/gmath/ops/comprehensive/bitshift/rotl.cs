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
        /// Rotates the source bits leftward by a specified shift amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl, Closures(UnsignedInts)]
        public static T rotl<T>(T src, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.rotl(uint8(src), offset));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.rotl(uint16(src), offset));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.rotl(uint32(src), offset));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.rotl(uint64(src), offset));
            else
                throw no<T>();
        }
    }
}