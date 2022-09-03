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
        /// Extracts the upper 4 bits from the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Hi]
        public static byte hi(byte src)
            => (byte)(src >> 4);

        /// <summary>
        /// Extracts the upper 8 bits from the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Hi]
        public static ushort hi(ushort src)
            => (byte)(src >> 8);

        /// <summary>
        /// Extracts the upper 16 bits from the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Hi]
        public static uint hi(uint src)
            => (ushort)(src >> 16);

        /// <summary>
        /// Extracts the upper 16 bits from the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Hi]
        public static ulong hi(ulong src)
            => (uint)(src >> 32);
    }
}