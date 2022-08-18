//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Saturates a 16-bit signed integer to an 8-bit unsigned integer
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The saturation width width</param>
        [MethodImpl(Inline), Op]
        public static byte usat(short src, W8 dst)
            => src > byte.MaxValue ? byte.MaxValue : (byte)src;

        /// <summary>
        /// Saturates a 32-bit signed integer to a 16-bit unsigned integer
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The saturation width width</param>
        [MethodImpl(Inline), Op]
        public static ushort usat(int src, W16 dst)
            => src > ushort.MaxValue ? ushort.MaxValue : (ushort)src;

        /// <summary>
        /// Saturates a 16-bit signed integer to an 8-bit unsigned integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static byte usat8(short src)
            => usat(src,w8);

        /// <summary>
        /// Saturates a 32-bit signed integer to a 16-bit unsigned integer
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static ushort usat16(int src)
            => usat(src,w16);
    }
}