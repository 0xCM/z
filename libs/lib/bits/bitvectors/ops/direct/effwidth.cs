//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), EffWidth]
        public static uint effwidth(BitVector4 x)
            => x.Width - nlz(x);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), EffWidth]
        public static uint effwidth(BitVector8 x)
            => x.Width - nlz(x);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), EffWidth]
        public static uint effwidth(BitVector16 x)
            => x.Width - nlz(x);

        /// <summary>
        /// Computes the effective width of the bitvector as determined by the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), EffWidth]
        public static uint effwidth(BitVector64 x)
            => x.Width - nlz(x);
    }
}