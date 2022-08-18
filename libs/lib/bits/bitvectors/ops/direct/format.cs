//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op]
        public static string format(BitVector4 src, BitFormat? fmt = null)
            => bitstring(src).Format(fmt);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op]
        public static string format(BitVector8 x, BitFormat? fmt = null)
            => BitRender.formatter<byte>(fmt).Format(x);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op]
        public static string format(BitVector16 x, BitFormat? fmt = null)
            => BitRender.formatter<ushort>(fmt).Format(x);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op]
        public static string format(BitVector24 x, BitFormat? fmt = null)
            => BitRender.formatter<uint>(fmt).Format(x);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op]
        public static string format(BitVector32 x, BitFormat? fmt = null)
            => BitRender.formatter<uint>(fmt).Format(x);

        /// <summary>
        /// Formats the bitvector as a bitstring
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="fmt">Optional formatting style</param>
        [MethodImpl(Inline), Op]
        public static string format(BitVector64 x, BitFormat? fmt = null)
            => BitRender.formatter<ulong>(fmt).Format(x);
    }
}