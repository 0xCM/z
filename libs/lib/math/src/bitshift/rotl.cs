//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl]
        public static byte rotl(byte src, byte offset)
            => (byte)((src << offset) | (src >> (8 - offset)));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl]
        public static ushort rotl(ushort src, byte offset)
            => (ushort)((src << offset) | (src >> (16 - offset)));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl]
        public static uint rotl(uint src, byte offset)
            => (src << offset) | (src >> (32 - offset));

        /// <summary>
        /// Rotates the source bits leftward by a specified offset amount
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="offset">The magnitude of the rotation</param>
        [MethodImpl(Inline), Rotl]
        public static ulong rotl(ulong src, byte offset)
            => (src << offset) | (src >> (64 - offset));
    }
}