//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost,Free]
    public class AsciBits
    {
        [MethodImpl(Inline), Op]
        public static asci4 render3(byte src, out asci4 dst)
        {
            dst = new asci4(
                BitRender.bitchar(src, 2),
                BitRender.bitchar(src, 1),
                BitRender.bitchar(src, 0)
            );
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static asci8 render3(byte src, out asci8 dst)
        {
            dst = new asci8(
                BitRender.bitchar(src, 2),
                BitRender.bitchar(src, 1),
                BitRender.bitchar(src, 0)
            );
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static asci4 render4(byte src, out asci4 dst)
        {
            dst = new asci4(
                BitRender.bitchar(src, 3),
                BitRender.bitchar(src, 2),
                BitRender.bitchar(src, 1),
                BitRender.bitchar(src, 0)
            )   ;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static asci8 render4(byte src, out asci8 dst)
        {
            dst = new asci8(
                BitRender.bitchar(src, 3),
                BitRender.bitchar(src, 2),
                BitRender.bitchar(src, 1),
                BitRender.bitchar(src, 0)
            )   ;
            return dst;
        }

    }
}