//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class math
    {
        /// <summary>
        /// Applies a logical left shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift leftwards</param>
        [MethodImpl(Inline), Sll]
        public static sbyte sll(sbyte src, byte offset)
            => (sbyte)(src << offset);

        /// <summary>
        /// Applies a logical left shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift leftwards</param>
        [MethodImpl(Inline), Sll]
        public static byte sll(byte src, byte offset)
            => (byte)(src << offset);

        /// <summary>
        /// Applies a logical left shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift leftwards</param>
        [MethodImpl(Inline), Sll]
        public static short sll(short src, byte offset)
            => (short)(src << offset);

        /// <summary>
        /// Applies a logical left shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift leftwards</param>
        [MethodImpl(Inline), Sll]
        public static ushort sll(ushort src, byte offset)
            => (ushort)(src << offset);

        /// <summary>
        /// Applies a logical left shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift leftwards</param>
        [MethodImpl(Inline), Sll]
        public static int sll(int src, byte offset)
            => src << offset;

        /// <summary>
        /// Applies a logical left shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift leftwards</param>
        [MethodImpl(Inline), Sll]
        public static uint sll(uint src, byte offset)
            => src << offset;

        /// <summary>
        /// Applies a logical left shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift leftwards</param>
        [MethodImpl(Inline), Sll]
        public static long sll(long src, byte offset)
            => src << offset;

        /// <summary>
        /// Applies a logical left shift to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The number of bits to shift leftwards</param>
        [MethodImpl(Inline), Sll]
        public static ulong sll(ulong src, byte offset)
            => src << offset;
   }
}