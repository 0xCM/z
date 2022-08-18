//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitGrid
    {
        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static BitGrid16<T> define<T>(N16 w, ushort data)
            where T : unmanaged
                => new BitGrid16<T>(data);

        [MethodImpl(Inline), Op, Closures(UInt8x16x32k)]
        public static BitGrid32<T> define<T>(N32 w, uint data)
            where T : unmanaged
                => new BitGrid32<T>(data);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public static BitGrid64<T> define<T>(N64 w, ulong data)
            where T : unmanaged
                => new BitGrid64<T>(data);

        /// <summary>
        /// Derives a 4x4 bitgrid from a permutation of length 4
        /// </summary>
        /// <param name="spec">The permutaton spec</param>
        /// <example>
        /// Permutation: [11 10 00 01] (ABCD -> BACD)
        /// Grid: [1000 | 0000 | 0100 | 1100]
        /// </example>
        [MethodImpl(Inline), Op]
        public static BitGrid16<N4,N4,ushort> define(Perm4L spec)
            => (ushort)spec;

        [MethodImpl(Inline), Op]
        public static BitGrid16<N4,N4,ushort> define(NatPerm<N4> spec)
            => define(spec.ToLiteral());

        [MethodImpl(Inline), Op]
        public static BitGrid64<N16,N4,ulong> define(Perm16L p)
            => (ulong)p;

        [MethodImpl(Inline), Op]
        public static BitGrid64<N16,N4,ulong> define(NatPerm<N16> p)
            => define(p.ToLiteral());
    }
}