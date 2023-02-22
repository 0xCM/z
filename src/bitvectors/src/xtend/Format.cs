//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XBv
    {
        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Bitstring formatting specifications</param>
        [MethodImpl(Inline)]
        public static string Format(this BitVector4 src, BitFormat? fmt = null)
            => BitVectors.format(src,fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Bitstring formatting specifications</param>
        [MethodImpl(Inline)]
        public static string Format(this BitVector8 src, BitFormat? fmt = null)
            => BitVectors.format(src,fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Bitstring formatting specifications</param>
        [MethodImpl(Inline)]
        public static string Format(this BitVector32 src, BitFormat? fmt = null)
            => BitVectors.format(src, fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Bitstring formatting specifications</param>
        [MethodImpl(Inline)]
        public static string Format(this BitVector16 src, BitFormat? fmt = null)
            => BitVectors.format(src, fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Bitstring formatting specifications</param>
        [MethodImpl(Inline)]
        public static string Format(this BitVector24 src, BitFormat? fmt = null)
            => BitVectors.format(src, fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="fmt">Bitstring formatting specifications</param>
        public static string Format(this BitVector64 src, BitFormat? fmt = null)
            => BitVectors.format(src, fmt);
    }
}