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
        /// Calculates the number of bits set up to and including the specified position
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="pos">The position of the bit for which rank will be calculated</param>
        [MethodImpl(Inline), Rank]
        public static uint rank(byte src, int pos)
            => pop(extract(src,0,(byte)pos));

        /// <summary>
        /// Calculates the number of bits set up to and including the specified position
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="pos">The position of the bit for which rank will be calculated</param>
        [MethodImpl(Inline), Rank]
        public static uint rank(ushort src, int pos)
            => pop(extract(src,0,(byte)pos));

        /// <summary>
        /// Calculates the number of bits set up to and including the specified position
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="pos">The position of the bit for which rank will be calculated</param>
        [MethodImpl(Inline), Rank]
        public static uint rank(uint src, int pos)
            => pop(extract(src,0,(byte)pos));

        /// <summary>
        /// Calculates the number of bits set up to and including the specified position
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="pos">The position of the bit for which rank will be calculated</param>
        [MethodImpl(Inline), Rank]
        public static uint rank(ulong src, int pos)
            => pop(extract(src,0,(byte)pos));
    }
}