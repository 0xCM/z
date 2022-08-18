//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 disable(BitVector4 x, byte pos)
            => bits.disable(x.State, pos);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 disable(BitVector8 x, byte pos)
            => bits.disable(x.State, pos);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 disable(BitVector16 x, byte pos)
            => bits.disable(x.State, pos);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 disable(BitVector32 x, byte pos)
            => bits.disable(x.State, pos);

        /// <summary>
        /// Disables a bit if it is enabled
        /// </summary>
        /// <param name="pos">The bit position</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 disable(BitVector64 x, byte pos)
            => bits.disable(x.State, pos);
    }
}