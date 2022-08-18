//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class bits
    {
        /// <summary>
        /// Computes the next power of two
        /// </summary>
        /// <param name="src">The current power of two</param>
        [MethodImpl(Inline), Op]
        public static Pow2x16 next(Pow2x8 src)
            => (Pow2x16)(xmsb((byte)src) << 1);

        /// <summary>
        /// Computes the next power of two
        /// </summary>
        /// <param name="src">The current power of two</param>
        [MethodImpl(Inline), Op]
        public static Pow2x32 next(Pow2x16 src)
            => (Pow2x32)(xmsb((ushort)src) << 1);

        /// <summary>
        /// Computes the next power of two
        /// </summary>
        /// <param name="src">The current power of two</param>
        [MethodImpl(Inline), Op]
        public static Pow2x64 next(Pow2x32 src)
            => (Pow2x64)(xmsb((uint)src) << 1);

        /// <summary>
        /// Computes the next power of two
        /// </summary>
        /// <param name="src">The current power of two</param>
        [MethodImpl(Inline), Op]
        public static Pow2x64 next(Pow2x64 src)
            => (Pow2x64)(xmsb((ulong)src) << 1);
    }
}