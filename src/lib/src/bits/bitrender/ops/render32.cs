//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render32(uint src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = bitchar(src, 31);
            seek(dst, i++) = bitchar(src, 30);
            seek(dst, i++) = bitchar(src, 29);
            seek(dst, i++) = bitchar(src, 28);
            seek(dst, i++) = bitchar(src, 27);
            seek(dst, i++) = bitchar(src, 26);
            seek(dst, i++) = bitchar(src, 25);
            seek(dst, i++) = bitchar(src, 24);
            seek(dst, i++) = bitchar(src, 23);
            seek(dst, i++) = bitchar(src, 22);
            seek(dst, i++) = bitchar(src, 21);
            seek(dst, i++) = bitchar(src, 20);
            seek(dst, i++) = bitchar(src, 19);
            seek(dst, i++) = bitchar(src, 18);
            seek(dst, i++) = bitchar(src, 17);
            seek(dst, i++) = bitchar(src, 16);
            seek(dst, i++) = bitchar(src, 15);
            seek(dst, i++) = bitchar(src, 14);
            seek(dst, i++) = bitchar(src, 13);
            seek(dst, i++) = bitchar(src, 12);
            seek(dst, i++) = bitchar(src, 11);
            seek(dst, i++) = bitchar(src, 10);
            seek(dst, i++) = bitchar(src, 9);
            seek(dst, i++) = bitchar(src, 8);
            seek(dst, i++) = bitchar(src, 7);
            seek(dst, i++) = bitchar(src, 6);
            seek(dst, i++) = bitchar(src, 5);
            seek(dst, i++) = bitchar(src, 4);
            seek(dst, i++) = bitchar(src, 3);
            seek(dst, i++) = bitchar(src, 2);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render32(uint src, ref uint i, Span<C> dst, N32 n = default)
            => render(n, src, ref i, dst);
    }
}