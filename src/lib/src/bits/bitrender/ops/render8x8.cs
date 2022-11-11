//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using static sys;

    partial struct BitRender
    {
        public static Index<char> render8x8(ReadOnlySpan<byte> src)
        {
            var dst = sys.alloc<char>(src.Length*8);
            render8x8(src, dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint render8x8(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var k=0u;
            var count = src.Length;
            for(var i=0u; i<count; i++)
                render8(skip(src,i), ref k, dst);
            return k;
        }

        [MethodImpl(Inline), Op]
        public static uint render8x8(ReadOnlySpan<byte> src, uint limit, Span<char> dst)
        {
            var k=0u;
            var count = src.Length;
            for(var i=0u; i<count && k < limit; i++)
                render8(skip(src,i), limit, ref k, dst);
            return k;
        }

        [MethodImpl(Inline), Op]
        public static uint render8(byte src, uint limit, ref uint i, Span<char> dst)
        {
            var i0 = i;
            for(byte k=0; k<8 && i<limit; k++)
                seek(dst, i++) = bit.test(src, k).ToChar();
            return i - i0;
        }

        public static uint bitstring<N>(HexVector8<N> src, uint i, Span<char> dst, N count = default)
            where N : unmanaged, ITypeNat
                => render8x8(bytes(src.View), i, dst, count);

        public static uint render8x8<N>(ReadOnlySpan<byte> src, uint offset, Span<char> dst, N k = default)
            where N : unmanaged, ITypeNat
        {
            var counter = 0u;
            var count = (int)k.NatValue;
            seek(dst, counter + offset) = Chars.Lt;
            counter++;
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref src[i];
                if(i != 0)
                    counter += separate(counter + offset, dst);

                counter += render8(cell, counter + offset, dst);
            }
            seek(dst, counter + offset) = Chars.Gt;
            counter++;
            return counter;
        }
    }
}