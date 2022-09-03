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
        /// Returns 1 if the source value is a power of 2 and 0 otherwise
        /// </summary>
        /// <param name="x">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool ispow2(sbyte x)
            => (x & (x - 1)) == 0;

        /// <summary>
        /// Returns 1 if the source value is a power of 2 and 0 otherwise
        /// </summary>
        /// <param name="x">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool ispow2(byte x)
            => (x & (x - 1)) == 0;

        /// <summary>
        /// Returns 1 if the source value is a power of 2 and 0 otherwise
        /// </summary>
        /// <param name="x">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool ispow2(short x)
            => (x & (x - 1)) == 0;

        /// <summary>
        /// Returns 1 if the source value is a power of 2 and 0 otherwise
        /// </summary>
        /// <param name="x">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool ispow2(ushort x)
            => (x & (x - 1)) == 0;

        /// <summary>
        /// Returns 1 if the source value is a power of 2 and 0 otherwise
        /// </summary>
        /// <param name="x">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool ispow2(int x)
            => (x & (x - 1)) == 0;

        /// <summary>
        /// Returns 1 if the source value is a power of 2 and 0 otherwise
        /// </summary>
        /// <param name="x">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool ispow2(uint x)
            => (x & (x - 1)) == 0;

        /// <summary>
        /// Returns 1 if the source value is a power of 2 and 0 otherwise
        /// </summary>
        /// <param name="x">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool ispow2(long x)
            => (x & (x - 1)) == 0;

        /// <summary>
        /// Returns 1 if the source value is a power of 2 and 0 otherwise
        /// </summary>
        /// <param name="x">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool ispow2(ulong x)
            => (x & (x - 1)) == 0;
    }
}