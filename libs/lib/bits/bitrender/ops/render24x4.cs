//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Refs;

    partial struct BitRender
    {
        /// <summary>
        /// Renders 24 1-bit values interspersed with 5 separators consuming 29 characters in the target buffer
        /// </summary>
        /// <param name="sep"></param>
        /// <param name="src"></param>
        /// <param name="i"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static uint render24x4(char sep, uint src, ref uint i, Span<char> dst)
        {
            var i0=i;
            seek(dst, i++) = bitchar(src, 23);
            seek(dst, i++) = bitchar(src, 22);
            seek(dst, i++) = bitchar(src, 21);
            seek(dst, i++) = bitchar(src, 20);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 19);
            seek(dst, i++) = bitchar(src, 18);
            seek(dst, i++) = bitchar(src, 17);
            seek(dst, i++) = bitchar(src, 16);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 15);
            seek(dst, i++) = bitchar(src, 14);
            seek(dst, i++) = bitchar(src, 13);
            seek(dst, i++) = bitchar(src, 12);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 11);
            seek(dst, i++) = bitchar(src, 10);
            seek(dst, i++) = bitchar(src, 9);
            seek(dst, i++) = bitchar(src, 8);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 7);
            seek(dst, i++) = bitchar(src, 6);
            seek(dst, i++) = bitchar(src, 5);
            seek(dst, i++) = bitchar(src, 4);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 3);
            seek(dst, i++) = bitchar(src, 2);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            return i - i0;
        }
    }
}