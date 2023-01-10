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
        public static uint renderNx16(ushort src, uint maxbits, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = 16;
            for(byte k=0; k<count; k++, i++)
            {
                if(i>=maxbits)
                    break;

                seek(dst, (uint)i) = bit.test(src, k).ToChar();
            }
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint renderNx16(ReadOnlySpan<ushort> src, uint maxbits, Span<char> dst)
        {
            var k=0u;
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                renderNx16(skip(src,i), maxbits, ref k, dst);
                if(k >= maxbits)
                    break;
            }
            return k;
        }

        [MethodImpl(Inline), Op]
        public static uint renderNx16(ReadOnlySpan<ushort> src, Span<char> dst)
            => renderNx16(src, (uint)(src.Length)*16,dst);
    }
}