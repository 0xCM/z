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
        public static uint render3(byte src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = bitchar(src, 2);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static ref asci4 render3(byte src, out asci4 dst)
        {
            dst = new asci4(
                bitchar(src, 2),
                bitchar(src, 1),
                bitchar(src, 0)
            );
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref asci8 render3(byte src, out asci8 dst)
        {
            dst = new asci8(
                bitchar(src, 2),
                bitchar(src, 1),
                bitchar(src, 0)
            );
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static uint render3(byte src, ref uint i, Span<C> dst, N3 n = default)
            => render(n, src, ref i, dst);
    }
}