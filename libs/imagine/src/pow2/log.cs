//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Numerics;

    partial struct Pow2
    {
        /// <summary>
        /// Computes the corresponding <see cref='Log2x2'/> literal
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Log2x2 log(Pow2x2 src)
            => (Log2x2)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes the corresponding <see cref='Log2x3'/> literal
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Log2x3 log(Pow2x3 src)
            => (Log2x3)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes the corresponding <see cref='Log2x4'/> literal
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Log2x4 log(Pow2x4 src)
            => (Log2x4)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes the corresponding <see cref='Log2x8'/> literal
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Log2x8 log(Pow2x8 src)
            => (Log2x8)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes the corresponding <see cref='Log2x16'/> literal
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Log2x16 log(Pow2x16 src)
            => (Log2x16)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes the corresponding <see cref='Log2x32'/> literal
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Log2x32 log(Pow2x32 src)
            => (Log2x32)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes the corresponding <see cref='Log2x64'/> literal
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static Log2x64 log(Pow2x64 src)
            => (Log2x64)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes floor(log(src,2))
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte log(byte src)
            => (byte)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes floor(log(src,2))
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort log(ushort src)
            => (ushort)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes floor(log(src,2))
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static uint log(uint src)
            => (uint)BitOperations.Log2(src);

        /// <summary>
        /// Computes floor(log(src,2))
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ulong log(ulong src)
            => (ulong)BitOperations.Log2(src);
    }
}