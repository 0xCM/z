//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Rotates the source bits rightward by a specified number of bits
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static byte rotr(byte src, byte count)
            => (byte)((src >> count) | (src << (8 - count)));

        /// <summary>
        /// Rotates the source bits rightward by a specified number of bits
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static ushort rotr(ushort src, byte count)
            => (ushort)((src  >> count) | (src << (16 - count)));

        /// <summary>
        /// Rotates the source bits rightward by a specified number of bits
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static uint rotr(uint src, byte count)
            => (src >> count) | (src << (32 - count));

        /// <summary>
        /// Rotates the source bits rightward by a specified number of bits
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotr]
        public static ulong rotr(ulong src, byte count)
            => (src >> count) | (src << (64 - count));

        /// <summary>
        /// Rotates the source bits rightward by a specified offset
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotr]
        public static byte rotr(byte src, int count, int width)
            => (byte)((src >> count) | (src << (width - count)));

        /// <summary>
        /// Rotates the source bits rightward by a specified offset
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotr]
        public static ushort rotr(ushort src, int count, int width)
            => (ushort)((src  >> count) | (src << (width - count)));

        /// <summary>
        /// Rotates the source bits rightward by a specified offset
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotr]
        public static uint rotr(uint src, int count, int width)
            => (src >> count) | (src << (width - count));

        /// <summary>
        /// Rotates the source bits rightward by a specified offset
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotr]
        public static ulong rotr(ulong src, int count, int width)
            => (src >> count) | (src << (width - count));
    }
}