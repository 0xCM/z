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

    partial class BitGrid
    {
        /// <summary>
        /// Extracts a sequence of bits
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The offset</param>
        /// <param name="index">The bit count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Slice, Closures(UInt8x16x32k)]
        public static ScalarBits<T> slice<T>(BitGrid32<T> g, byte index, byte length)
            where T : unmanaged
                => generic<T>(gbits.slice(g.Data, ScalarCast.uint8(index*length), length));

        /// <summary>
        /// Extracts a sequence of bits
        /// </summary>
        /// <param name="g">The source grid</param>
        /// <param name="index">The offset</param>
        /// <param name="index">The bit count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Slice, Closures(UnsignedInts)]
        public static ScalarBits<T> slice<T>(BitGrid64<T> g, byte index, byte length)
            where T : unmanaged
                => generic<T>(gbits.slice(g.Data, ScalarCast.uint8(index*length), length));
    }
}