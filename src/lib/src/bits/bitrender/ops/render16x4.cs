//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct BitRender
    {
        /// <summary>
        /// Renders 16 1-bit values interspersed with 3 separators consuming 19 characters in the target buffer
        /// </summary>
        /// <param name="sep"></param>
        /// <param name="src"></param>
        /// <param name="i"></param>
        /// <param name="dst"></param>
        [MethodImpl(Inline), Op]
        public static uint render16x4(char sep, ushort src, ref uint i, Span<char> dst)
        {
            var i0=i;
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