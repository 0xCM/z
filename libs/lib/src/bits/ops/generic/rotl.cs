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
        /// Rotates the source bits leftward by a specified shift amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl, Closures(Closure)]
        public static T rotl<T>(T src, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.rotl(uint8(src), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.rotl(uint16(src), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.rotl(uint32(src), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.rotl(uint64(src), count));
            else
                throw no<T>();
        }

        /// <summary>
        /// Rotates the source bits leftward by a specified shift amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotl, Closures(Closure)]
        public static T rotl<T>(T src, byte count, int width)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.rotl(uint8(src), count, width));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.rotl(uint16(src), count, width));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.rotl(uint32(src), count, width));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.rotl(uint64(src), count, width));
            else
                throw no<T>();
        }
    }
}