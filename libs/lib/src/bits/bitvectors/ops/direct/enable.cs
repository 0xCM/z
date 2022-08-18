//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 enable(BitVector4 x, byte index)
            => bits.enable(x.State, index);

        /// <summary>
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 enable(BitVector8 x, byte index)
            => bits.enable(x.State, index);

        /// <summary>
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 enable(BitVector16 x, byte index)
            => bits.enable(x.State, index);

        /// <summary>
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 enable(BitVector32 x, byte index)
            => bits.enable(x.State, index);

        /// <summary>
        /// Enables a bit if it is disabled
        /// </summary>
        /// <param name="index">The position of the bit to enable</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 enable(BitVector64 x, byte index)
            => bits.enable(x.State, index);
    }
}