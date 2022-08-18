//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static bit;

    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render(N16 n, ushort src, ref uint i, Span<char> dst)
            => render16(src, ref i,dst);


        [MethodImpl(Inline), Op]
        public static uint render(N16 n, ushort src, ref uint i, Span<C> dst)
        {
            var i0  = i;
            seek(dst, i++) = code(src, 15);
            seek(dst, i++) = code(src, 14);
            seek(dst, i++) = code(src, 13);
            seek(dst, i++) = code(src, 12);
            seek(dst, i++) = code(src, 11);
            seek(dst, i++) = code(src, 10);
            seek(dst, i++) = code(src, 9);
            seek(dst, i++) = code(src, 8);
            seek(dst, i++) = code(src, 7);
            seek(dst, i++) = code(src, 6);
            seek(dst, i++) = code(src, 5);
            seek(dst, i++) = code(src, 4);
            seek(dst, i++) = code(src, 3);
            seek(dst, i++) = code(src, 2);
            seek(dst, i++) = code(src, 1);
            seek(dst, i++) = code(src, 0);
            return i - i0;
        }
    }
}