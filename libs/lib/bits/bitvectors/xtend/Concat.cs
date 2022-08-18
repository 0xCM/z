//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        /// <summary>
        /// Creates a new vector via concatenation
        /// </summary>
        /// <param name="tail">The lower bits of the new vector</param>
        [MethodImpl(Inline)]
        public static BitVector8 Concat(this BitVector4 head, BitVector4 tail)
            => BitVectors.join(tail,head);

        /// <summary>
        /// Concatenates two 8-bit vectors to produce a 16-bit vector
        /// </summary>
        /// <param name="tail">The lower bits of the new vector</param>
        [MethodImpl(Inline)]
        public static BitVector16 Concat(this BitVector8 head, BitVector8 tail)
            => BitVectors.join(tail,head);

        /// <summary>
        /// Concatenates two 16-bit vectors to produce a 32-bit vector
        /// </summary>
        /// <param name="tail">The lower bits of the new vector</param>
        [MethodImpl(Inline)]
        public static BitVector32 Concat(this BitVector16 head, BitVector16 tail)
            => BitVectors.join(tail,head);

        /// <summary>
        /// Creates a new vector via concatenation
        /// </summary>
        /// <param name="tail">The lower bits of the new vector</param>
        [MethodImpl(Inline)]
        public static BitVector64 Concat(this BitVector32 head, BitVector32 tail)
            => BitVectors.join(tail,head);
    }
}