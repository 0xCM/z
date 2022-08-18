//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Counts the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(BitVector4 x)
            => (byte)(bits.nlz(x.State) - (byte)x.Width);

        /// <summary>
        /// Counts the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(BitVector8 x)
            => (byte)bits.nlz(x.State);

        /// <summary>
        /// Counts the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(BitVector16 x)
            => (byte)bits.nlz(x.State);

        /// <summary>
        /// Counts the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(BitVector32 x)
            => (byte)bits.nlz(x.State);

        /// <summary>
        /// Counts the number of leading zero bits
        /// </summary>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(BitVector64 x)
            => (byte)bits.nlz(x.State);
    }
}