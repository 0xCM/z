//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 gather(BitVector4 src, BitVector4 spec)
            => bits.gather(src.State, spec.State);

        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 gather(BitVector8 src, BitVector8 spec)
            => bits.gather(src.State, spec.State);

        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 gather(BitVector16 src, BitVector16 spec)
            => bits.gather(src.State, spec.State);

        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 gather(BitVector32 src, BitVector32 spec)
            => bits.gather(src.State, spec.State);

        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 gather(BitVector64 src, BitVector64 spec)
            => bits.gather(src.State, spec.State);
    }
}