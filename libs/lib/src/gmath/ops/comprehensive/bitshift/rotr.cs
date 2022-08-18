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
        /// Rotates bits in the source rightwards by a specified shift amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The magnitude of the rotation</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Rotr, Closures(UnsignedInts)]
        public static T rotr<T>(T src, byte offset)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.rotr(uint8(src), offset));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.rotr(uint16(src), offset));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.rotr(uint32(src), offset));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.rotr(uint64(src), offset));
            else
                throw no<T>();
        }
    }
}