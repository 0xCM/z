//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitRender
    {
        /// <summary>
        /// Renders 64 1-bit values interspersed with 14 segment separators consuming 88 characters in the target buffer
        /// </summary>
        /// <param name="sep">The segment separator</param>
        /// <param name="src">The source bits</param>
        /// <param name="i">The target offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static uint render64x4(char sep, ulong src, ref uint i, Span<char> dst)
        {
            var i0=i;
            render32x4(sep, (uint)(src >> 32), ref i, dst);
            i += separate(i, sep, dst);
            render32x4(sep, (uint)src, ref i, dst);
            return i - i0;
         }

        /// <summary>
        /// Renders 64 1-bit values interspersed with 14 segment separators consuming 88 characters in the target buffer
        /// </summary>
        /// <param name="sep">The segment separator</param>
        /// <param name="src">The source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static uint render64x4(char sep, ulong src, Span<char> dst)
        {
            var i=0u;
            return render64x4(sep, src, ref i, dst);
        }
    }
}