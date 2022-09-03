//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Reverse]
        public static BitVector4 reverse(BitVector4 x)
            => bits.reverse(x.State);

        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Reverse]
        public static BitVector8 reverse(BitVector8 x)
            => bits.reverse(x.State);

        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Reverse]
        public static BitVector16 reverse(BitVector16 x)
            => bits.reverse(x.State);

        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Reverse]
        public static BitVector32 reverse(BitVector32 x)
            => bits.reverse(x.State);

        /// <summary>
        /// Reverses the bits in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Reverse]
        public static BitVector64 reverse(BitVector64 x)
            => bits.reverse(x.State);
    }
}