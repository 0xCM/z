//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial struct BitRender
    {
        /// <summary>
        /// Renders 32 1-bit values interspersed with 3 segment separators, consuming 35 characters in the target buffer
        /// </summary>
        /// <param name="sep">The segment separator</param>
        /// <param name="src">The source bits</param>
        /// <param name="i">The target offset</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static uint render32x8(char sep, uint src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var cells = sys.bytes(src);
            render8(skip(cells,3), ref i, dst);
            seek(dst,i++) = sep;

            render8(skip(cells,2), ref i, dst);
            seek(dst,i++) = sep;

            render8(skip(cells,1), ref i, dst);
            seek(dst,i++) = sep;

            render8(skip(cells,0), ref i, dst);

            return i-i0;
        }

        /// <summary>
        /// Renders 32 1-bit values interspersed with 3 segment separators, consuming 35 characters in the target buffer
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="dst">The target buffer</param>
        /// <param name="i">The target offset</param>
        [MethodImpl(Inline), Op]
        public static uint render32x8(uint src, ref uint i, Span<char> dst)
            => render32x8(Chars.Space, src, ref i, dst);

        /// <summary>
        /// Renders 32 1-bit values interspersed with 3 segment separators, consuming 35 characters in the target buffer
        /// </summary>
        /// <param name="sep">The segment separator</param>
        /// <param name="src">The source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static uint render32x8(char sep, uint src, Span<char> dst)
        {
            var i = 0u;
            return render32x8(sep, src, ref i, dst);
        }
    }
}