//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVectors
    {
        /// <summary>
        /// Computes the bitvector z := x | y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector4 or(BitVector4 x, BitVector4 y)
            => gmath.or(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x | y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector8 or(BitVector8 x, BitVector8 y)
            => math.or(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x | y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector16 or(BitVector16 x, BitVector16 y)
            => math.or(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x | y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector32 or(BitVector32 x, BitVector32 y)
            => math.or(x.State, y.State);

        /// <summary>
        /// Computes the bitvector z := x | y from bitvectors x and y
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline)]
        public static BitVector64 or(BitVector64 x, BitVector64 y)
            => math.or(x.State, y.State);
    }
}