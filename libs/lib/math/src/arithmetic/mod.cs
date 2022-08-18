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
        /// Computes b := a % m
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), Mod]
        public static sbyte mod(sbyte a, sbyte m)
            => (sbyte)(a % m);

        /// <summary>
        /// Computes b := a % m
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), Mod]
        public static byte mod(byte a, byte m)
            => (byte)(a % m);

        /// <summary>
        /// Computes b := a % m
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), Mod]
        public static short mod(short a, short m)
            => (short)(a % m);


        /// <summary>
        /// Computes b := a % m
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), Mod]
        public static ushort mod(ushort a, ushort m)
            => (ushort)(a % m);

        /// <summary>
        /// Computes b := a % m
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), Mod]
        public static int mod(int a, int m)
            => a % m;

        /// <summary>
        /// Computes b := a % m
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), Mod]
        public static uint mod(uint a, uint m)
            => a % m;

        /// <summary>
        /// Computes b := a % m
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), Mod]
        public static long mod(long a, long m)
            => a % m;

        /// <summary>
        /// Computes b := a % m
        /// </summary>
        /// <param name="a">The source value</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), Mod]
        public static ulong mod(ulong a, ulong m)
            => a % m;
    }
}