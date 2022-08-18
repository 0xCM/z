//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitMaskLiterals;

    partial class BitVectors
    {
        /// <summary>
        /// Creates a bitvector with uniformly alternating states where the state of
        /// the first bit is determine by a parity bit
        /// </summary>
        /// <param name="parity">The state of the first bit</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> alt<T>(bit parity)
            where T : unmanaged
                => parity ? convert<T>(Even64) : convert<T>(Odd64);

        /// <summary>
        /// Creates a bitvector with uniformly alternating states where the state of
        /// the first bit is determined by a parity bit
        /// </summary>
        /// <param name="parity">The state of the first bit</param>
        /// <param name="n">The width selector</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> alt<N,T>(bit parity, N n = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => natural<N,T>(parity ? convert<T>(Even64) : convert<T>(Odd64));
    }
}