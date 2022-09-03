//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Block-formats the vector, e.g. [01010101 01010101 ... 01010101] where by default the size of each block is the bit-width of a component
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        public static string FormatBlockedBits<T>(this Vector128<T> src, int width, uint? maxbits = null)
            where T : unmanaged
                => text.bracket(src.ToBitString((int?)maxbits).Format(BitFormat.blocked(width, Chars.Space, maxbits)));

        /// <summary>
        /// Block-formats the vector, e.g. [01010101 01010101 ... 01010101] where default the size of each block is the bit-width of a component
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        public static string FormatBlockedBits<T>(this Vector256<T> src, int width, uint? maxbits = null)
            where T : unmanaged
                => text.bracket(src.ToBitString((int?)maxbits).Format(BitFormat.blocked(width, Chars.Space, maxbits)));
    }
}