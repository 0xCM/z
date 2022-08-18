//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    
    partial class math
    {
        /// <summary>
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSr]
        public static byte xorsr(byte a, byte offset)
            => (byte)xorsr((uint)a, offset);

        /// <summary>
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSr]
        public static sbyte xorsr(sbyte a, byte offset)
            => (sbyte)xorsr((int)a, offset);

        /// <summary>
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSr]
        public static short xorsr(short a, byte offset)
            => (short)xorsr((int)a, offset);

        /// <summary>
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSr]
        public static ushort xorsr(ushort a, byte offset)
            => (ushort)xorsr((uint)a, offset);

        /// <summary>
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSr]
        public static int xorsr(int a, byte offset)
            => a^(a >> offset);

        /// <summary>
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSr]
        public static uint xorsr(uint a, byte offset)
            => a^(a >> offset);

        /// <summary>
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSr]
        public static long xorsr(long a, byte offset)
            => a^(a >> offset);

        /// <summary>
        /// Computes a^(a >> offset)
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="offset">The number of bits to shift the source value rightwards</param>
        [MethodImpl(Inline), XorSr]
        public static ulong xorsr(ulong a, byte offset)
            => a^(a >> offset);
    }
}