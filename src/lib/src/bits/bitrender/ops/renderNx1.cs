//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint renderNx1(ReadOnlySpan<bit> src, Span<char> dst, uint offset)
        {
            var j = 0u;
            var k = min(src.Length + offset, dst.Length);
            for(uint i=offset; i<k; i++, j++)
                seek(dst,i) = skip(src,j).ToChar();
            return j;
        }

        [MethodImpl(Inline), Op]
        public static void renderNx1(ReadOnlySpan<bit> src, Span<char> dst)
        {
            var count = min(src.Length,dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = skip(src,i).ToChar();
        }
    }
}