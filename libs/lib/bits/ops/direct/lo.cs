//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Extracts the lower 4 bits from the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Lo]
        public static byte lo(byte src)
            => (byte)(0xF & src);

        /// <summary>
        /// Extracts the lower 8 bits from the source
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Lo]
        public static ushort lo(ushort src)
            => (byte)src;

        /// <summary>
        /// Extracts the lower 16 bits from the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Lo]
        public static uint lo(uint src)
            => (ushort)src;

        /// <summary>
        /// Extracts the lower half of the bits from the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Lo]
        public static ulong lo(ulong src)
            => (uint)src;
    }
}