//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl]
        public static byte rotl(byte src, byte count)
            => (byte)((src << count) | (src >> (8 - count)));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl]
        public static ushort rotl(ushort src, byte count)
            => (ushort)((src << count) | (src >> (16 - count)));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl]
        public static uint rotl(uint src, byte count)
            => (src << count) | (src >> (32 - count));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl]
        public static ulong rotl(ulong src, byte count)
            => (src << count) | (src >> (64 - count));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotl]
        public static byte rotl(byte src, byte count, int width)
            => (byte)((src << count) | (src >> (width - count)));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotl]
        public static ushort rotl(ushort src, byte count, int width)
            => (ushort)((src << count) | (src >> (width - count)));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotl]
        public static uint rotl(uint src, byte count, int width)
            => (src << count) | (src >> (width - count));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="count">The magnitude of the rotation</param>
        /// <param name="width">The effective bit-width of the source value</param>
        [MethodImpl(Inline), Rotl]
        public static ulong rotl(ulong src, byte count, int width)
            => (src << count) | (src >> (width - count));
    }
}