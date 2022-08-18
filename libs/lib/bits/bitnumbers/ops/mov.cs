//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitNumbers
    {
        [MethodImpl(Inline), Op]
        public static uint8b movlo(uint4 src, uint8b dst)
            => movzx(dst.Hi, w8) | movzx(src, w8);

        [MethodImpl(Inline), Op]
        public static uint8b movhi(uint4 src, uint8b dst)
            => movzx(dst.Lo, w8) | movzx(src, w8);
    }
}