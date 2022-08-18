//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Numerics;

    partial class math
    {
        /// <summary>
        /// Computes floor(log(src,2))
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Log2]
        public static byte log2(byte src)
            => (byte)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes floor(log(src,2))
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Log2]
        public static ushort log2(ushort src)
            => (ushort)BitOperations.Log2((uint)src);

        /// <summary>
        /// Computes floor(log(src,2))
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Log2]
        public static uint log2(uint src)
            => (uint)BitOperations.Log2(src);

        /// <summary>
        /// Computes floor(log(src,2))
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Log2]
        public static ulong log2(ulong src)
            => (ulong)BitOperations.Log2(src);
    }
}