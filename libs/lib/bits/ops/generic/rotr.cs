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
        /// Rotates bits in the source rightwards by a specified shift amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Rotr, Closures(Closure)]
        public static T rotr<T>(T src, byte count)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.rotr(uint8(src), count));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.rotr(uint16(src), count));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.rotr(uint32(src), count));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.rotr(uint64(src), count));
            else
                throw no<T>();
        }

        /// <summary>
        /// Rotates bits in the source rightwards by a specified shift amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Rotr, Closures(Closure)]
        public static T rotr<T>(T src, byte count, byte width)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(bits.rotr(uint8(src), count, width));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(bits.rotr(uint16(src), count, width));
            else if(typeof(T) == typeof(uint))
                return generic<T>(bits.rotr(uint32(src), count, width));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(bits.rotr(uint64(src), count, width));
            else
                throw no<T>();
        }
    }
}