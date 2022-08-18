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
        /// Computes the Hamming distance between two bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static uint hamming(BitVector4 x, BitVector4 y)
            => pop(xor(x,y));

        /// <summary>
        /// Computes the Hamming distance between two bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static uint hamming(BitVector8 x, BitVector8 y)
            => pop(xor(x,y));

        /// <summary>
        /// Computes the Hamming distance between two bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static uint hamming(BitVector16 x, BitVector16 y)
            => pop(xor(x,y));

        /// <summary>
        /// Computes the Hamming distance between two bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static uint hamming(BitVector32 x, BitVector32 y)
            => pop(xor(x,y));

        /// <summary>
        /// Computes the Hamming distance between two bitvectors
        /// </summary>
        /// <param name="x">The left bitvector</param>
        /// <param name="y">The right bitvector</param>
        [MethodImpl(Inline), Op]
        public static uint hamming(BitVector64 x, BitVector64 y)
            => pop(xor(x,y));
    }
}