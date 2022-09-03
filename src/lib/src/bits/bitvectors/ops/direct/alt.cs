//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;

    partial class BitVectors
    {
        /// <summary>
        /// Creates a bitvector with uniformly alternating states where the state of the
        /// first bit is determine by a specified parity bit
        /// </summary>
        /// <param name="n">The width selector</param>
        /// <param name="parity">The state of the first bit</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 alt(N8 n, bit parity)
            => parity ? Even8 : Odd8;

        /// <summary>
        /// Creates a bitvector with uniformly alternating states where the state of the
        /// first bit is determine by a specified parity bit
        /// </summary>
        /// <param name="n">The width selector</param>
        /// <param name="parity">The state of the first bit</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 alt(N16 n, bit parity)
            => parity ? Even16 : Odd16;

        /// <summary>
        /// Creates a bitvector with uniformly alternating states where the state of the
        /// first bit is determine by a specified parity bit
        /// </summary>
        /// <param name="n">The width selector</param>
        /// <param name="parity">The state of the first bit</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 alt(N32 n, bit parity)
            => parity ? Even32 : Odd32;

        /// <summary>
        /// Creates a bitvector with uniformly alternating states where the state of the
        /// first bit is determine by a specified parity bit
        /// </summary>
        /// <param name="n">The width selector</param>
        /// <param name="parity">The state of the first bit</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 alt(N64 n, bit parity)
            => parity ? Even64 : Odd64;
    }
}