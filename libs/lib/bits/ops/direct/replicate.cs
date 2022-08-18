//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Replicates an index-identified segment [from..to] a target a specified number of times
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="from">The first source bit</param>
        /// <param name="to">The last source bit</param>
        /// <param name="count">The number of times replicate the segment</param>
        [MethodImpl(Inline), Replicate]
        public static byte replicate(byte src, byte from, byte to, byte count)
        {
            var width = to - from;
            var pattern = slice(src, from, to);
            byte dst = 0;
            for(var i=0; i<count; i++)
                dst |= (byte)(pattern << i*width);
            return dst;
        }

        /// <summary>
        /// Replicates source bits [from..to] a specified number of times subject to the constraints imposed by the source type
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="from">The first source bit</param>
        /// <param name="to">The last source bit</param>
        /// <param name="count">The number of times replicate the segment</param>
        [MethodImpl(Inline), Replicate]
        public static ushort replicate(ushort src, byte from, byte to, byte count)
        {
            var width = to - from;
            var pattern = slice(src, from, to);
            ushort dst = 0;
            for(var i=0; i<count; i++)
                dst |= (ushort)(pattern << i*width);
            return dst;
        }

        /// <summary>
        /// Replicates source bits [from..to] a specified number of times subject to the constraints imposed by the source type
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="from">The first source bit</param>
        /// <param name="to">The last source bit</param>
        /// <param name="count">The number of times replicate the segment</param>
        [MethodImpl(Inline), Replicate]
        public static uint replicate(uint src, byte from, byte to, byte count)
        {
            var width = to - from;
            var pattern = slice(src, from, to);
            var dst = 0u;
            for(var i=0; i<count; i++)
                dst |= (pattern << i*width);
            return dst;
        }

        /// <summary>
        /// Replicates source bits [from..to] a specified number of times subject to the constraints imposed by the source type
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="from">The first source bit</param>
        /// <param name="to">The last source bit</param>
        /// <param name="count">The number of times replicate the segment</param>
        [MethodImpl(Inline), Replicate]
        public static ulong replicate(ulong src, byte from, byte to, byte count)
        {
            var width = (byte)(to - from + 1);
            var pattern = slice(src, from, width);
            var dst = pattern;
            for(var i=1; i<count; i++)
                dst |= (pattern << i*width);
            return dst;
        }
    }
}